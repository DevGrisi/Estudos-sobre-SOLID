using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Entidades
{
    /// <summary>
    /// Representa uma entidade de conta bancária genérica que
    /// define estado e comportamentos comuns a todas as contas.
    /// </summary>
    public class Conta
    {
        /// <summary>Número da conta[</summary>
        public int Numero { get; }

        /// <summary>Nome do titular da conta</summary>
        public string Titular { get; }

        /// <summary>Saldo atual da conta</summary>
        public decimal Saldo { get; set; }


        /// <summary>
        /// Construtor da conta
        /// </summary>
        public Conta(int numero, string titular, decimal saldo)
        {
            Numero = numero;
            Titular = titular;
            Saldo = saldo;
        }


        /// <summary>Realiza um depósito na conta</summary>
        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }


        /// <summary>Realiza um saque, respeitando regras comuns</summary>
        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor inválido.");

            if (valor > Saldo)
                throw new InvalidOperationException("Saldo insuficiente.");

            Saldo -= valor;
        }
    }


}
