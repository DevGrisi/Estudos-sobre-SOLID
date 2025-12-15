using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_InterfaceSegregationPrinciple
{
    /// <summary>Conta corrente que pode sacar e depositar.</summary>
    public class ContaCorrente : IContaDeposito, IContaSaque
    {
        private double Saldo;

        /// <summary>Realiza o depósito na conta corrente.</summary>
        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        /// <summary>Realiza o saque na conta corrente.</summary>
        public void Sacar(double valor)
        {
            if (valor <= Saldo)
                Saldo -= valor;
            else
                throw new InvalidOperationException("Saldo insuficiente na conta!");
        }

        public double ObterSaldo() => Saldo;
    }
}