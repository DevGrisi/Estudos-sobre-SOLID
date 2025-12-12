using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace O_OpenClosedPrinciple
{
    /// <summary>
    /// Princípio Aberto-Fechado (Open/Closed Principle)
    /// O princípio Aberto-Fechado estabelece que entidades de software devem estar 
    /// abertas para extensão, mas fechadas para modificação. Ou seja, não devemos alterar 
    /// o código-fonte existente ao adicionar novas funcionalidades; em vez disso, estendemos 
    /// o sistema por meio de herança ou composição. Isso reduz o risco de introduzir bugs 
    /// em código testado.
    /// 
    /// Este arquivo mantém a documentação do princípio. As classes concretas e a abstração
    /// foram separadas em arquivos distintos:
    /// * O_ContaBancaria.cs (abstração)
    /// * ContaCorrente.cs (implementação)
    /// * ContaPoupanca.cs (implementação)
    /// 
    /// </summary>
    public static class O_OpenClosedPrinciple
    {
        // Arquivo de documentação/descrição do princípio.
    }
}