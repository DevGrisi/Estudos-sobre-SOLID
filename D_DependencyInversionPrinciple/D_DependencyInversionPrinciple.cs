using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
namespace D_DependencyInversionPrinciple
{
    public class D_DependencyInversionPrinciple
    {
        /// <summary>
        /// Princípio da Inversão de Dependência (Dependency Inversion Principle)
        /// O DIP estabelece que módulos de alto nível não devem depender de módulos de baixo nível.
        /// Ambos devem depender de abstrações (por exemplo, interfaces).
        /// Além disso, abstrações não devem depender de detalhes; detalhes devem depender de abstrações.
        /// 
        /// 
        /// D_ServicoDeConta (módulo de alto nível) utiliza apenas a abstração IRepositorioDeContas.
        /// RepositorioSqlDeContas e RepositorioEmMemoria são implementações concretas (detalhes).
        /// A injeção de dependência via construtor permite trocar a implementação concreta sem alterar o serviço.
        /// Isso reduz acoplamento, facilita testes (por exemplo, usar RepositorioEmMemoria em testes) e torna o código mais flexível.
        /// </summary>
        public class ContaBancaria
        {
            // Representa uma entidade simples de conta bancária.
            public string NumeroConta { get; set; }
        }

        /// <summary>
        /// Abstração do repositório de contas
        /// O serviço de domínio depende desta interface em vez de uma implementação concreta.
        /// Isso permite cumprir o DIP: depender de abstrações, não de implementações.
        /// </summary>
        public interface IRepositorioDeContas
        {
            /// <summary>
            /// Salva a conta bancária no repositório.
            /// Implementações concretas tratarão os detalhes de persistência
            /// </summary>
            void Salvar(ContaBancaria conta);
        }

        /// <summary>
        /// Implementação concreta: repositório que persiste em "SQL"
        /// É um detalhe que depende da abstração IRepositorioDeContas
        /// podemos sbstituir por outra implementação sem alterar D_ServicoDeConta
        /// </summary>
        public class RepositorioSqlDeContas : IRepositorioDeContas
        {
            public void Salvar(ContaBancaria conta)
            {
                // Simulação de persistência SQL
                Console.WriteLine($"Conta salva no banco de dados SQL - Número: {conta?.NumeroConta}");
            }
        }

        /// <summary>
        /// Implementação para testes: repositório em memória,
        /// util em testes atomatizados para evitar dependência de banco de dados.
        /// Também implementa IRepositorioDeContas, portanto pode ser injtado no serviço.
        /// </summary>
        public class RepositorioEmMemoria : IRepositorioDeContas
        {
            public ContaBancaria UltimaContaSalva { get; set; }

            public void Salvar(ContaBancaria conta)
            {
                UltimaContaSalva = conta;
                Console.WriteLine($"Conta salva em memória -Número: {conta?.NumeroConta}");
            }
        }

        /// <summary>
        /// Serviço de domínio que depende da abstração IRepositorioDeContas (Dependency Inversion).
        /// O serviço não conhece detalhes de persistência (SQL, memória, arquivo, etc.).
        /// A implementação concreta é fornecida externamente (injeção de dependência via construtor),
        /// permitindo substituir facilmente o repositório usado sem alterar este serviço.
        /// torna o serviço testável e menos acoplado.
        /// </summary>
        public class D_ServicoDeConta
        {
            private readonly IRepositorioDeContas _repositorio;

            //                                   ^
            //                                   |
            // Injeção de dependência via construtor
            // Recebe uma abstração IRepositorioDeContas em vez de instanciar uma implementação concreta.
            // Assim, o serviço obedece ao DIP.
            //                                      |
            //                                      V
            public D_ServicoDeConta(IRepositorioDeContas repositorio)
            {
                _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            }

            public void AdicionarConta(ContaBancaria conta)
            {
                // Não importa qual implementação concreta foi injetada.
                _repositorio.Salvar(conta);
            }
        }
        /// <summary>
        /// Exemplo ERRADO que NÃO obedece ao Princípio da Inversão de Dependência (DIP).
        /// Este serviço instancia diretamente uma implementação concreta (RepositorioSqlDeContas),
        /// criando acoplamento forte entre módulo de alto nível e detalhe de baixo nível.
        /// E torna difícil trocar a implementação sem modificar o serviço.
        /// </summary>
        public class ServicoDeContaErrado
        {
            // Acoplamento direto à implementação concreta (errado)
            private readonly RepositorioSqlDeContas _repositorioSql;

            // instancia diretamente o repositório concreto no construtor
            public ServicoDeContaErrado()
            {
                // Aqui o serviço escolhe um detalhe concreto por conta própria.
                // Se quiser trocar para RepositorioEmMemoria, é necessário editar este código.
                _repositorioSql = new RepositorioSqlDeContas();
            }

            // Método que realiza a operação delegando ao repositório concreto.
            public void AdicionarConta(ContaBancaria conta)
            {
                // O serviço depende da implementação concreta, não de uma abstração.
                _repositorioSql.Salvar(conta);
            }

            // Exemplo de uso que demonstra porque isso é ruim para testes/versatilidade.
            public static void ExemploDeUsoErrado()
            {
                var servico = new ServicoDeContaErrado();
                servico.AdicionarConta(new ContaBancaria { NumeroConta = "ERR-123" });
                // Não é possível, a partir daqui, substituir facilmente o repositório por uma implementação de teste
                // sem alterar o código de ServicoDeContaErrado, Ex: usar RepositorioEmMemoria
            }
        }

    }
}