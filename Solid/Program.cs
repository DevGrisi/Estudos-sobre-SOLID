using Solid.Entidades;
using Solid.Services;
using Solid.Services.Implementações;
using Solid.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Solid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cria uma implementação concreta do repositório de contas.
            // IContaRepository define:
            // void Salvar(Conta conta);
            // Conta Obter(int numero);
            // List<Conta> Listar();
            IContaRepository repo = new ArquivoContaRepository();

            // Cria o serviço de domínio e injeta o repositório.
            // ContaService(IContaRepository repositorio)
            // Métodos úteis:
            //   void CriarConta(Conta conta)             -> salva a conta no repositório
            //   void Depositar(int numero, decimal v)   -> obtém, deposita e salva
            //   void AplicarTaxasMensais()               -> aplica taxa em todas e salva
            //   List<Conta> ListarContas()               -> retorna todas as contas
            var contaService = new ContaService(repo);

            // Serviço responsável por gerar relatórios (apresentação).
            // RelatorioService:
            //   void ImprimirResumo(Conta conta)                 -> imprime dados da conta
            //   void ImprimirResumoDeTodasAsContas(List<Conta>)  -> imprime todas as contas
            var relatorio = new RelatorioService();

            // Menu interativo para o usuário:
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Gestão de Contas (SOLID) ===");
                Console.WriteLine("1) Criar nova conta");
                Console.WriteLine("2) Pesquisar conta por número");
                Console.WriteLine("3) Depositar");
                Console.WriteLine("4) Sacar");
                Console.WriteLine("5) Imprimir relatório de todas as contas");
                Console.WriteLine("6) Imprimir relatório de uma conta específica");
                Console.WriteLine("0) Sair");
                Console.Write("Escolha uma opção: ");

                var opc = Console.ReadLine();

                Console.WriteLine();

                if (opc == "0")
                    break;

                try
                {
                    switch (opc)
                    {
                        case "1":
                            CriarContaInteractiva(contaService);
                            break;
                        case "2":
                            PesquisarConta(repo, relatorio);
                            break;
                        case "3":
                            DepositarInteractivo(contaService);
                            break;
                        case "4":
                            SacarInteractivo(contaService);
                            break;
                        case "5":
                            relatorio.ImprimirResumoDeTodasAsContas(contaService.ListarContas());
                            break;
                        case "6":
                            ImprimirRelatorioContaEspecifica(repo, relatorio);
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Tratamento simples de erros para o demo.
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
            repo.ExcluirContas();
            Console.WriteLine("Excluindo todas as contas do sistema. Até mais!");
        }

        // Cria uma conta perguntando número, titular e saldo inicial.
        // Usa apenas a classe Conta (não há mais distinção entre tipos de conta).
        // Conta constructor: Conta(int numero, string titular, decimal saldo)
        private static void CriarContaInteractiva(ContaService contaService)
        {
            Console.WriteLine("Criar nova conta");

            Console.Write("Número da conta (inteiro): ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Número inválido.");
                return;
            }

            Console.Write("Titular: ");
            var titular = Console.ReadLine() ?? string.Empty;

            Console.Write("Saldo inicial (ex: 1000.50): ");
            if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal saldo))
            // permite ponto como separador decimal (independente da cultura) e aceita sinais e notação científica
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            // Instancia uma Conta simples (não há ContaCorrente / ContaPoupanca)
            var nova = new Conta(numero, titular, saldo);

            // ContaService.CriarConta(Conta conta)
            contaService.CriarConta(nova);
            Console.WriteLine($"Conta criada: {numero} - {titular} (Saldo: {nova.Saldo:C})");
            Console.Clear();
        }

        // Pesquisa uma conta pelo número e imprime resumo (se existir).
        // Usa IContaRepository.Obter(int numero) e RelatorioService.ImprimirResumo(Conta)
        private static void PesquisarConta(IContaRepository repo, RelatorioService relatorio)
        {
            Console.Write("Número da conta a pesquisar: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Número inválido.");
                return;
            }

            var conta = repo.Obter(numero); // pode ser null se não existir
            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada.");
                return;
            }

            relatorio.ImprimirResumo(conta);
            Console.Clear();
        }

        // Interação para depositar: pede número e valor e delega a ContaService.Depositar
        // ContaService.Depositar(int numero, decimal valor) -> obtém, deposita e salva.
        private static void DepositarInteractivo(ContaService contaService)
        {
            Console.Write("Número da conta para depósito: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Número inválido.");
                return;
            }

            Console.Write("Valor a depositar: ");
            if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            contaService.Depositar(numero, valor);
            Console.WriteLine("Depósito realizado.");
            Console.Clear();
        }

        // Interação para saque: delega a ContaService.Sacar(int numero, decimal valor)
        // ContaService.Sacar deve validar existência e regras internas da Conta (lança exceção em erro).
        private static void SacarInteractivo(ContaService contaService)
        {
            Console.Write("Número da conta para saque: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Número inválido.");
                return;
            }

            Console.Write("Valor a sacar: ");
            if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            contaService.Sacar(numero, valor);
            Console.WriteLine("Saque realizado.");
            Console.Clear();
        }

        // Imprime relatório de uma conta específica pedida pelo usuário.
        private static void ImprimirRelatorioContaEspecifica(IContaRepository repo, RelatorioService relatorio)
        {
            Console.Write("Número da conta para relatório: ");
            if (!int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine("Número inválido.");
                return;
            }

            var conta = repo.Obter(numero);
            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada.");
                return;
            }

            relatorio.ImprimirResumo(conta);
            Console.Clear();
        }
        
    }
}
