using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_InterfaceSegregationPrinciple
{
    public class I_InterfaceSegregationPrinciple
    { 
        /// <summary>
        /// Princípio da Segregação de Interfaces (Interface Segregation Principle)
        /// O ISP diz que não devemos forçar uma classe a implementar interfaces que não usa.
        /// É melhor criar interfaces específicas para cada cliente (comportamento) do que uma 
        /// interface única e genérica.Isso evita que implementações sejam obrigadas a incluir 
        /// métodos irrelevantes.
        /// 
        /// 
        /// Vamos supor que algumas contas permitem depósito e saque, enquanto outras permitem apenas
        /// depósito(por exemplo, uma conta bloqueada que não permite saques). Em vez de uma única
        /// interface, dividimos em IContaDeposito e IContaSaque. Assim, ContaCorrente implementa ambas, mas
        /// a ContaPoupanca(que não permite saques especiais) implementa apenas IContaDeposito.
        /// 
        /// 
        /// 
        /// Interfaces segregadas: separa operações de depósito e saque.
        ///                     |
        ///                     V
        /// </summary>
        public interface IContaDeposito
        {
            /// <summary>Realiza o depósito de um valor na conta.</summary>
            void Depositar(double valor);
        }

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

            public double ObterSaldo() => Saldo;
        }

        /// <summary>
        /// Conta poupança que só permite depósitos (ex.: conta bloqueada que não autoriza saques).
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
        // Exemplo que NÃO aplica o Princípio da Segregação de Interfaces (ISP):
        // - Mostra uma interface genérica que força implementações a criar métodos que não usam.
        // - Demonstra por que interfaces mais específicas (IContaDeposito / IContaSaque) são preferíveis.

        /// <summary>
        /// Interface "grande" que combina depósito e saque — exemplo de má prática para demonstrar violação do ISP.
        /// </summary>
        public interface IContaUnica
        {
            /// <summary>Realiza o depósito de um valor na conta.</summary>
            void Depositar(double valor);

            /// <summary>Realiza a retirada de um valor da conta.</summary>
            void Sacar(double valor);
        }

        /// <summary>
        /// Implementação ERRADA: ContaPoupancaErrada representa uma conta que só deveria aceitar depósitos,
        /// mas é forçada a implementar Sacar pela interface IContaUnica.
        /// Em vez de segregar as interfaces, esta abordagem obriga a implementação a lançar exceções
        /// </summary>
        public class ContaPoupancaErrada : IContaUnica
        {
            private double Saldo;

            /// <summary>Realiza o depósito na conta poupança</summary>
            public void Depositar(double valor)
            {
                Saldo += valor;
            }

            /// <summary>
            /// Método sacrifical: só existe porque a interface exige.
            /// Lança NotSupportedException para indicar que esta conta não permite saque.
            /// Isso evidencia a violação do ISP: a classe é obrigada a implementar algo que não deveria.
            /// </summary>
            public void Sacar(double valor)
            {
                throw new NotSupportedException("ContaPoupancaErrada não permite saques — exemplo de violação do ISP.");
            }

            public double ObterSaldo() => Saldo;
        }

    }
}