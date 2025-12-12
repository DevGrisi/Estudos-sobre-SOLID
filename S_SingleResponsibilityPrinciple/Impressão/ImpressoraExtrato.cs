using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace S_SingleResponsibilityPrinciple
{
    /// <summary>
    /// Classe responsável apenas por imprimir extratos de contas bancárias.
    /// Demonstrando o principio da responsabilidade única
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