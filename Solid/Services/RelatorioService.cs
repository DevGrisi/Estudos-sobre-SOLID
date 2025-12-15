using Solid.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Services
{
    /// <summary>
    /// Serviço responsável pela geração de relatórios.
    /// </summary>
    public class RelatorioService
    {
        public void ImprimirResumo(Conta conta)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Conta: {conta.Numero}");
            Console.WriteLine($"Titular: {conta.Titular}");
            Console.WriteLine($"Saldo: {conta.Saldo:C}");
            Console.WriteLine("-----------------------------");
        }


        public void ImprimirResumoDeTodasAsContas(List<Conta> contas)
        {
            foreach (var conta in contas)
            {
                ImprimirResumo(conta);
            }
        }
    }
}
