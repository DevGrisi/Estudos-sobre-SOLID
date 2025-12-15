using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_InterfaceSegregationPrinciple
{
    /// <summary>Interface para operações de saque em conta.</summary>
    public interface IContaSaque
    {
        /// <summary>Realiza a retirada de um valor da conta.</summary>
        void Sacar(double valor);
    }
}