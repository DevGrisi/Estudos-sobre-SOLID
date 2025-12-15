using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DependencyInversionPrinciple
{
    /// <summary>
    /// Implementação concreta: repositório que persiste em "SQL"
    /// É um detalhe que depende da abstração IRepositorioDeContas
    /// podemos substituir por outra implementação sem alterar D_ServicoDeConta
    /// </summary>
    public class RepositorioSqlDeContas : IRepositorioDeContas
    {
        public void Salvar(D_ContaBancaria conta)
        {
            // Simulação de persistência SQL
            Console.WriteLine($"Conta salva no banco de dados SQL - Número: {conta?.NumeroConta}");
        }
    }
}