using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DependencyInversionPrinciple
{
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

        // Injeção de dependência via construtor
        // Recebe uma abstração IRepositorioDeContas em vez de instanciar uma implementação concreta.
        public D_ServicoDeConta(IRepositorioDeContas repositorio)
        {
            _repositorio = repositorio;
        }

        public void AdicionarConta(D_ContaBancaria conta)
        {
            // Não importa qual implementação concreta foi injetada.
            _repositorio.Salvar(conta);
        }
    }
}