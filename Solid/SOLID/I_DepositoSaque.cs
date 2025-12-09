using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.SOLID
{
    public class I_DepositoSaque
    {

        //Vamos supor que algumas contas permitem depósito e saque, enquanto outras permitem apenas
        //depósito(por exemplo, uma conta bloqueada que não permite saques). Em vez de uma única
        //interface, dividimos em IContaDeposito e IContaSaque. Assim, ContaCorrente implementa ambas, mas
        //a ContaPoupanca(que não permite saques especiais) implementa apenas IContaDeposito.



        /// <summary>Interface para operações de depósito em conta.</summary>
        public interface IContaDeposito
        {
            /// <summary>Realiza o depósito de um valor na conta.</summary>
            void Depositar(double valor);
        }


        /// <summary>Interface para operações de saque em conta.</summary>
        public interface IContaSaque
        {
            /// <summary>Realiza a retirada de um valor da conta.</summary>
            void Sacar(double valor);
        }

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
        }

        /// <summary>
        /// Conta poupança que só permite depósitos (por exemplo, conta bloqueada que não autoriza saques).
        /// </summary>
        public class ContaPoupanca : IContaDeposito
        {
            private double Saldo;

            /// <summary>Realiza o depósito na conta poupança.</summary>
            public void Depositar(double valor)
            {
                Saldo += valor;
            }
        }

    }
}
