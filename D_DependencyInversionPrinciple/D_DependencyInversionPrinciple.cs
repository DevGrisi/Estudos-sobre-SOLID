using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DependencyInversionPrinciple
{
    /// <summary>
    /// Princípio da Inversão de Dependência (Dependency Inversion Principle)
    /// O DIP estabelece que módulos de alto nível não devem depender de módulos de baixo nível.
    /// Ambos devem depender de abstrações (por exemplo, interfaces).
    /// Além disso, abstrações não devem depender de detalhes; detalhes devem depender de abstrações.
    /// 
    /// As classes foram movidas para arquivos separados:
    /// * ContaBancaria.cs
    /// * IRepositorioDeContas.cs
    /// * RepositorioSqlDeContas.cs
    /// * RepositorioEmMemoria.cs
    /// * D_ServicoDeConta.cs
    /// 
    /// </summary>
    public static class D_DependencyInversionPrinciple
    {
        // Arquivo de documentação/descrição do princípio.
    }
}