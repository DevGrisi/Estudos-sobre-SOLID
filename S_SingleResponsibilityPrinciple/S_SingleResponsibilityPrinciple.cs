using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace S_SingleResponsibilityPrinciple
{
    /// <summary>
    /// Princípio da Responsabilidade Única (Single Responsibility Principle)
    /// Cada classe deve ter uma única responsabilidade ou propósito, ou seja, um único motivo para mudar
    /// Em outras palavras, toda classe deve tratar de apenas um aspecto do sistema.
    /// Isso aumenta a coesão interna da classe e reduz o acoplamento entre diferentes funcionalidades.
    /// Quando violado, tendemos a ter classes “deus” que fazem de tudo, dificultando testes e manutenção.
    /// Por exemplo, uma classe que gerencia dados da conta e imprime o extrato ao mesmo tempo estaria
    /// violando este princípio.
    /// 
    /// 
    /// Representa uma conta bancária com funcionalidades básicas.
    ///                     |
    ///                     V
    /// </summary>
    public static class S_SingleResponsibilityPrinciple
    {
        // Arquivo mantido para documentação/descrição do princípio.
        // As classes foram movidas para arquivos separados afim de se guiar pelas boas praticas:
        // * S_ContaBancaria.cs
        // * ImpressoraExtrato.cs
        // * S_ContaBancariaErrada.cs
    }
}