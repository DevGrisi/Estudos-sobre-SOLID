using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace O_OpenClosedPrinciple
{
    /// <summary>Conta corrente com taxa mensal fixa.</summary>
    public class ContaCorrente : O_ContaBancaria
    {
        /// <summary>Calcula e aplica a taxa mensal para conta corrente.</summary>
        public override void AplicarTaxaMensal()
        {
            Saldo -= 10; // taxa fixa de R$10
        }
    }
}