using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_LiskovSubstitutionPrinciple
{
    /// <summary>Conta corrente que permite saques comuns.</summary>
    public class ContaCorrente_ : L_ContaBancaria
    {
        /// <summary>Realiza a retirada de um valor, obedecendo as regras da conta corrente</summary>
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
}