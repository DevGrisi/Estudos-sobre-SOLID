using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace S_SingleResponsibilityPrinciple
{
    /// <summary>
    /// Clase que representa uma conta bancária, afim de exemplificar.
    /// </summary>
    public class S_ContaBancaria
    {
        /// <summary>Propriedade do saldo atual da conta.</summary>
        public double Saldo { get; set; }

        /// <summary>metodo que realiza o depósito de um valor na conta.</summary>
        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        /// <summary>metodo que realiza a retirada de um valor da conta.</summary>
        public void Sacar(double valor)
        {
            // Verifica saldo suficiente
            if (Saldo >= valor)
            {
                Saldo -= valor;
            }
            else
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }
        }
    }
}