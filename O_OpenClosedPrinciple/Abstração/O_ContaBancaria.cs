using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace O_OpenClosedPrinciple
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
}