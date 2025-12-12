using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_LiskovSubstitutionPrinciple
{
    /// <summary>
    /// Conta bancária abstrata que define operações básicas.
    /// </summary>
    public abstract class L_ContaBancaria
    {
        /// <summary>Saldo atual da conta.</summary>
        public double Saldo { get; set; }

        /// <summary>Realiza a retirada de um valor da conta</summary>
        public abstract void Sacar(double valor);
    }
}