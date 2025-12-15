using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_InterfaceSegregationPrinciple
{
    /// <summary>
    /// Conta poupança que só permite depósitos (por exemplo, conta bloqueada que não autoriza saques).
    /// Implementa apenas a interface necessária (IContaDeposito) — segue o ISP.
    /// </summary>
    public class ContaPoupanca : IContaDeposito
    {
        private double Saldo;

        /// <summary>Realiza o depósito na conta poupança.</summary>
        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public double ObterSaldo() => Saldo;
    }
}