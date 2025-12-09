using System;
using Solid.SOLID;

namespace Solid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Apresentacao("SOLID -> demonstração usando as classes do projeto");

            // S — Single Responsibility
            MostrarTitulo("S — Single Responsibility (Responsabilidade Única)");
            DemonstrarSingleResponsibility();

            // O — Open/Closed
            MostrarTitulo("O — Open/Closed (Aberto para extensão, fechado para modificação)");
            DemonstrarOpenClosed();

            // L — Liskov Substitution
            MostrarTitulo("L — Liskov Substitution (Substituição de Liskov)");
            DemonstrarLiskov();

            // I — Interface Segregation
            MostrarTitulo("I — Interface Segregation (Segregação de Interfaces)");
            DemonstrarInterfaceSegregation();

            // D — Dependency Inversion
            MostrarTitulo("D — Dependency Inversion (Inversão de Dependência)");
            DemonstrarDependencyInversion();

            Console.WriteLine();
            Console.WriteLine("Demonstração concluída. Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        private static void Apresentacao(string texto)
        {
            Console.WriteLine(new string('=', 80));
            Console.WriteLine(texto);
            Console.WriteLine(new string('=', 80));
            Console.WriteLine();
        }

        private static void MostrarTitulo(string titulo)
        {
            Console.WriteLine(titulo);
            Console.WriteLine(new string('-', titulo.Length));
        }

        // S — exemplo: S_ContaBancaria e ImpressoraExtrato (cada classe tem uma unica responsabilidade)
        private static void DemonstrarSingleResponsibility()
        {
            var conta = new S_ContaBancaria();
            conta.Depositar(150.0);
            Console.WriteLine("Operação: Deposito de R$150 realizada na conta (classe S_ContaBancaria).");
            var impressora = new ImpressoraExtrato();
            Console.Write("Impressão do extrato (classe ImpressoraExtrato): ");
            impressora.ImprimirExtrato(conta);
            Console.WriteLine();
        }

        // O — exemplo: O_ContaBancaria (aberta para extensao: novas contas; fechada para modificação)
        private static void DemonstrarOpenClosed()
        {
            O_ContaBancaria cc = new ContaCorrente { Saldo = 100.0 };
            O_ContaBancaria cp = new ContaPoupanca { Saldo = 100.0 };

            Console.WriteLine("Antes da taxa:");
            Console.WriteLine($"ContaCorrente Saldo: {cc.Saldo:C}");
            Console.WriteLine($"ContaPoupanca  Saldo: {cp.Saldo:C}");

            cc.AplicarTaxaMensal();
            cp.AplicarTaxaMensal();


            Console.WriteLine("Depois de AplicarTaxaMensal():");
            Console.WriteLine($"ContaCorrente Saldo: {cc.Saldo:C} (taxa aplicada pela classe derivada)");
            Console.WriteLine($"ContaPoupanca  Saldo: {cp.Saldo:C} (taxa aplicada pela classe derivada)");
            Console.WriteLine();
        }

        // L — exemplo: L_ContaBancaria e substituição por classes derivadas
        private static void DemonstrarLiskov()
        {
            L_ContaBancaria corrente = new ContaCorrente_ { Saldo = 200.0 };
            L_ContaBancaria poupanca = new ContaPoupanca_ { Saldo = 50.0 };

            Console.WriteLine("Tentando sacar R$50 de ambas as contas usando metodo que aceita L_ContaBancaria:");
            Sacar(corrente, 50.0);
            Sacar(poupanca, 50.0);

            Console.WriteLine("Saque bem sucedido demonstra que objetos derivados podem substituir a classe base sem quebrar");
            Console.WriteLine();
        }

        private static void Sacar(L_ContaBancaria conta, double valor)
        {
            try
            {
                conta.Sacar(valor);
                Console.WriteLine($"Saque de {valor:C} realizado. Saldo restante: {conta.Saldo:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao sacar {valor:C}: {ex.Message}");
            }
        }

        // I — exemplo: segregação de interfaces (I_DepositoSaque.IContaDeposito / IContaSaque)
        private static void DemonstrarInterfaceSegregation()
        {
            // ContaCorrente implementa deposito e saque
            var contaCorrente = new I_DepositoSaque.ContaCorrente();
            contaCorrente.Depositar(300.0);
            Console.WriteLine("I — ContaCorrente: implementa IContaDeposito e IContaSaque (pode depositar e sacar).");
            contaCorrente.Sacar(100.0);
            Console.WriteLine("Operações realizadas: depsoito 300, saqe 100 (interno).");

            // ContaPoupanca implementa apenas depósito
            var contaPoupanca = new I_DepositoSaque.ContaPoupanca();
            contaPoupanca.Depositar(200.0);
            Console.WriteLine("I — ContaPoupanca: implementa apenas IContaDeposito (não tem metodo Sacar).");
            Console.WriteLine("Operação realizada: deposito 200 (não é possível sacar dessa implementação).");
            Console.WriteLine();
        }

        // D — exemplo: inversão de dependência (D_ServicoDeConta depende da abstração IRepositorioDeContas)
        private static void DemonstrarDependencyInversion()
        {
            // Criamos um repositório concreto e injetamos na classe de serviço
            var repositorio = new RepositorioSqlDeContas();
            var servico = new D_ServicoDeConta(repositorio);

            var conta = new Solid.SOLID.ContaBancaria { NumeroConta = "12345-6" };
            servico.AdicionarConta(conta);

            Console.WriteLine("D — O serviço D_ServicoDeConta depende da abstração IRepositorioDeContas");
            Console.WriteLine("Ao injetar RepositorioSqlDeContas, o serviço persiste sem conhecer detalhes da implementação concreta");
            Console.WriteLine();
        }
    }
}
