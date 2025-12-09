using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    /// <summary>
    /// Representa uma conta bancária com funcionalidades básicas.
    /// </summary>
    public class S_ContaBancaria
    {
        /// <summary>Saldo atual da conta.</summary>
        public double Saldo { get; set; }

        /// <summary>Realiza o depósito de um valor na conta.</summary>
        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        /// <summary>Realiza a retirada de um valor da conta.</summary>
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

    /// <summary>
    /// Classe responsável apenas por imprimir extratos de contas bancárias.
    /// </summary>
    public class ImpressoraExtrato
    {
        /// <summary>Imprime o extrato para a conta fornecida.</summary>
        public void ImprimirExtrato(S_ContaBancaria conta)
        {
            Console.WriteLine($"Saldo atual: {conta.Saldo:C}");
        }
    }

}
