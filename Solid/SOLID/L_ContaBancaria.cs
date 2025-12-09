using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
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

    /// <summary>Conta corrente que permite saques comuns </summary>
    public class ContaCorrente_ : L_ContaBancaria
    {
        /// <summary>Realiza a retirada de um valor, obedecendo as regras da conta corrente.</summary>
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

    /// <summary>Conta poupança que possui restrições adicionais em saques </summary>
    public class ContaPoupanca_ : L_ContaBancaria
    {
        /// <summary>Realiza a retirada de um valor, obedecendo as regras da conta poupança </summary>
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
