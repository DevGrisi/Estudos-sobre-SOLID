using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_InterfaceSegregationPrinciple
{
    /// <summary>
    /// Princípio da Segregação de Interfaces (Interface Segregation Principle)
    /// O ISP diz que não devemos forçar uma classe a implementar interfaces que não usa.
    /// É melhor criar interfaces específicas para cada cliente (comportamento) do que uma
    /// interface única e genérica. Isso evita que implementações sejam obrigadas a incluir
    /// métodos irrelevantes.
    ///
    /// Este arquivo mantém a documentação do princípio. As interfaces e classes foram separadas em:
    /// * IContaDeposito.cs
    /// * IContaSaque.cs
    /// * ContaCorrente.cs
    /// * ContaPoupanca.cs
    /// 
    /// </summary>
    public static class I_InterfaceSegregationPrinciple
    {
        // Arquivo de documentação/descrição do princípio.
    }
}