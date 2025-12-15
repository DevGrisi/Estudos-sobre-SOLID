using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DependencyInversionPrinciple
{
    /// <summary>
    /// Implementação para testes: repositório em memória,
    /// útil em testes automatizados para evitar dependência de banco de dados.
    /// Também implementa IRepositorioDeContas, portanto pode ser injetado no serviço.
    /// </summary>
    public class RepositorioEmMemoria : IRepositorioDeContas
    {
        public D_ContaBancaria UltimaContaSalva { get; set; }

        public void Salvar(D_ContaBancaria conta)
        {
            UltimaContaSalva = conta;
            Console.WriteLine($"Conta salva em memória - Número: {conta?.NumeroConta}");
        }
    }
}