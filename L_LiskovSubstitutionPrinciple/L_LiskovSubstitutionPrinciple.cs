using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_LiskovSubstitutionPrinciple
{
    public class L_LiskovSubstitutionPrinciple
    {
        /// <summary>
        /// Princípio da Substituição de Liskov (Liskov Substitution Principle)
        /// Segundo Liskov, uma classe derivada deve ser substituível por sua classe base.
        /// Ou seja, objetos de classes filhas devem funcionar como se fossem objetos da 
        /// classe pai, sem comportamento inesperado. Respeitar o LSP garante que possamos usar 
        /// o polimorfismo de forma segura: qualquer código que opere sobre a classe base 
        /// funcionará corretamente com subclasses.
        /// 
        /// 
        /// Demonstração do princípio Liskov Substitution: subclasses devem poder substituir a base.
        /// Conta bancária abstrata que define operações básicas.
        ///                             |
        ///                             V
        /// </summary>
        public abstract class L_ContaBancaria
        {
            /// <summary>Saldo atual da conta.</summary>
            public double Saldo { get; set; }

            /// <summary>Realiza a retirada de um valor da conta.</summary>
            public abstract void Sacar(double valor);
        }

        /// <summary>Conta corrente que permite saques comuns.</summary>
        public class ContaCorrente_ : L_ContaBancaria
        {
            public override void Sacar(double valor)
            {
                if (valor <= Saldo)
                {
                    Saldo -= valor;
                }
                else
                {
                    throw new InvalidOperationException("Saldo insuficiente na conta corrente!");
                }
            }
        }

        /// <summary>Conta poupança que também permite saques (mesmo contrato da base).</summary>
        public class ContaPoupanca_ : L_ContaBancaria
        {
            public override void Sacar(double valor)
            {
                if (valor <= Saldo)
                {
                    Saldo -= valor;
                }
                else
                {
                    throw new InvalidOperationException("Saldo insuficiente na conta poupança!");
                }
            }
        }

        /// <summary>
        /// EXEMPLO ERRADO: Conta que só aceita depósito. Violação do LSP porque impede uma operação
        /// que a classe base declara e que clientes esperam poder chamar.
        /// - Chamadas a Sacar em código que manipula L_ContaBancaria podem falhar inesperadamente.
        /// </summary>
        public class ContaSomenteDeposito_ : L_ContaBancaria
        {
            public override void Sacar(double valor)
            {
                // Violação: em vez de seguir o contrato (tentar sacar ou lançar InvalidOperationException
                // quando saldo insuficiente), esta subclasse nega completamente a operação,
                // lançando NotSupportedException, alterando o comportamento esperado.
                throw new NotSupportedException("Conta de só depósito não permite saques.");
            }
        }

        /// <summary>
        /// Demonstrando a violação do LSP
        /// Código que usa L_ContaBancaria espera poder chamar Sacar.
        /// Ao passar uma ContaSomenteDeposito_, a chamada falha de forma inesperada.
        /// </summary>
        public static void ExecutarExemploErrado()
        {
            var contas = new List<L_ContaBancaria>
                {
                    new ContaCorrente_ { Saldo = 500.0 },
                    new ContaSomenteDeposito_ { Saldo = 500.0 } // Subclasse que viola LSP
                };

            foreach (var conta in contas)
            {
                Console.WriteLine("Tentando sacar 100 da conta do tipo: " + conta.GetType().Name);
                try
                {
                    // Código cliente trata L_ContaBancaria de forma genérica
                    conta.Sacar(100.0);
                    Console.WriteLine("Saque realizado. Saldo restante: " + conta.Saldo);
                }
                catch (Exception ex)
                {
                    // Aqui vemos o comportamento inesperado: uma subclasse que deveria ser substituível
                    // lança NotSupportedException, quebrando a suposição do cliente.
                    Console.WriteLine("Exceção ao sacar: " + ex.GetType().Name + " - " + ex.Message);
                }
            }
        }
    }
}