using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_InterfaceSegregationPrinciple
{
    /// <summary>Interface para operações de depósito em conta</summary>
    public interface IContaDeposito
    {
        /// <summary>Realiza o depósito de um valor na conta</summary>
        void Depositar(double valor);
    }
}