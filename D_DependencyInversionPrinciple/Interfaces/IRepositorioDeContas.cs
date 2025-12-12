using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DependencyInversionPrinciple
{
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
        void Salvar(D_ContaBancaria conta);
    }
}