using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_LiskovSubstitutionPrinciple
{
    /// <summary>Conta poupança que possui restrições adicionais em saques</summary>
    public class ContaPoupanca_ : L_ContaBancaria
    {
        /// <summary>Realiza a retirada de um valor, obedecendo as regras da conta poupança.</summary>
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
}