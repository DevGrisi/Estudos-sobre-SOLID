using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    /// <summary>
    /// Classe base para contas bancárias, aberta para extensão (novos tipos de conta) e fechada para modificação.
    /// </summary>
    public abstract class O_ContaBancaria
    {
        /// <summary>Número da conta.</summary>
        public string NumeroConta { get; set; }

        /// <summary>Saldo atual da conta.</summary>
        public double Saldo { get; set; }

        /// <summary>
        /// Calcula e aplica a taxa de manutenção mensal da conta.
        /// Esse método pode ser estendido nas classes derivadas.
        /// </summary>
        public abstract void AplicarTaxaMensal();
    }


    /// <summary>Conta corrente com taxa mensal fixa.</summary>
    public class ContaCorrente : O_ContaBancaria
    {
        /// <summary>Calcula e aplica a taxa mensal para conta corrente.</summary>
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
