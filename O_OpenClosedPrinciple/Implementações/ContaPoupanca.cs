using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace O_OpenClosedPrinciple
{
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