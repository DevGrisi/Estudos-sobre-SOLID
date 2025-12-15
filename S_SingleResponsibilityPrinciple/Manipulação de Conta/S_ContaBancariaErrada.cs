using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_SingleResponsibilityPrinciple
{
    /// <summary>
    /// EXEMPLO ERRADO: Violando o Princípio da Responsabilidade Única.
    /// Esta classe faz várias coisas: gerencia saldo, imprime extrato e grava em arquivo.
    /// Classes assim são difíceis de testar e manter.
    /// </summary>
    public class S_ContaBancariaErrada
    {
        /// <summary>Propriedade do saldo atual da conta.</summary>
        public double Saldo { get; set; }

        /// <summary>Realiza depósito e imprimi a informação no mesmo metodo e classe</summary>
        public void Depositar(double valor)
        {
            // Lógica de negócio
            Saldo += valor;

            // Lógica de apresentação misturada aqui (Errado)
            Console.WriteLine($" Depósito de {valor:C} realizado. Novo saldo: {Saldo:C}");
        }

        /// <summary>Realiza saque e também envia email e imprime mensagens na tela.</summary>
        public void Sacar(double valor)
        {

            if (Saldo < valor)
            {
                // Decisão de negocio misturada com apresentação e exceção textual
                Console.WriteLine(" Tentativa de saque com saldo insuficiente.");
                throw new InvalidOperationException("Saldo insuficiente.");
            }

            Saldo -= valor; // Lógica de negócio misturada com outras responsabilidades (Errado)
            Console.WriteLine($"Saque de {valor:C} realizado. Novo saldo: {Saldo:C}");

            // Envio de e-mail diretamente daqui (altamente acoplado e difícil de testar)
            try
            {
                EnviarExtratoPorEmailSimulado("cliente@exemplo.com", $"Seu saque de {valor:C} foi realizado. Saldo: {Saldo:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO AO ENVIAR EMAIL {ex.Message}");
            }
        }

        /// <summary>
        /// Método que imprime o extrato no console —> responsabilidade de apresentação
        /// embutida na classe de domínio (Errado)
        /// </summary>
        public void ImprimirExtrato()
        {
            Console.WriteLine("===== EXTRATO =====");
            Console.WriteLine($"Saldo atual: {Saldo:C}");
            Console.WriteLine("===================");
        }

        /// <summary>
        /// Simula o envio de e-mail diretamente a partir da classe de conta (Errado).
        /// </summary>
        private void EnviarExtratoPorEmailSimulado(string destinatario, string mensagem)
        {
            // Aqui poderíamos usar System.Net.Mail, mas até a simulação acopla a conta a infraestrutura de envio.
            Console.WriteLine($"EMAIL Para: {destinatario}\nMensagem: {mensagem}");
        }
    }
}