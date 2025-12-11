using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace O_OpenClosedPrinciple
{
    public class O_OpenClosedPrinciple
    {
        /// <summary>
        /// Princípio Aberto-Fechado (Open/Closed Principle)
        /// O princípio Aberto-Fechado estabelece que entidades de software devem estar 
        /// abertas para extensão, mas fechadas para modificação. Ou seja, não devemos alterar 
        /// o código fonte existente ao adicionar novas funcionalidades; em vez disso, estendemos 
        /// o sistema por meio de herança ou composição.Isso reduz o risco de introduzir bugs 
        /// em código testado.
        /// 
        /// Este princípio é aplicado quando
        /// Definino uma abstração (O_ContaBancaria) que expõe um contrato público (propriedades e o método abstrato AplicarTaxaMensal).
        /// Com esse contrato, adicionano novos comportamentos criando classes derivadas que implementam 
        /// AplicarTaxaMensal por exemplo, ContaCorrente, ContaPoupanca e quando adiciono 
        /// novos tipos de conta, não preciso alterar o código existente da classe base nem das 
        /// outras contas; basta criar uma nova subclasse ou compor um comportamento novo.
        /// 
        /// Classe base para contas bancárias, aberta para extensão e fechada para modificação.
        ///                         |
        ///                         V
        /// </summary>
        public abstract class O_ContaBancaria
        {
            /// <summary>Número da conta.</summary>
            public string NumeroConta { get; set; }

            /// <summary>Saldo atual da conta.</summary>
            public double Saldo { get; set; }

            /// <summary>
            /// Calcula e aplica a taxa de manutenção mensal da conta.
            /// Deve ser implementado pelas classes derivadas
            /// </summary>
            public abstract void AplicarTaxaMensal();
        }

        /// <summary>Conta corrente com taxa mensal fixa</summary>
        public class ContaCorrente : O_ContaBancaria
        {
            /// <summary>Calcula e aplica a taxa mensal para conta corrente</summary>
            public override void AplicarTaxaMensal()
            {
                Saldo -= 10; // taxa fixa de R$10
            }
        }

        /// <summary>Conta poupança com taxa mensal reduzida.</summary>
        public class ContaPoupanca : O_ContaBancaria
        {
            /// <summary>Calcula e aplica a taxa mensal para conta poupança.</summary>
            public override void AplicarTaxaMensal()
            {
                Saldo -= 2; // taxa fixa de R$2
            }
        }
    }
}