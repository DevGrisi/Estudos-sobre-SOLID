using Solid.Entidades;
using Solid.Services;
using Solid.Services.Implementações;
using Solid.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cria uma implementação concreta do repositório de contas.
            // IContaRepository define:
            // void Salvar(Conta conta);
            // Conta Obter(int numero);
            // List<Conta> Listar();
            IContaRepository repo = new ArquivoContaRepository();

            // Cria o serviço de domínio e injeta o repositório.
            var contaService = new ContaService(repo);

            // Serviço responsável por gerar relatórios (apenas apresentação).
            var relatorio = new RelatorioService();

            // Criação de instâncias de contas concretas.
            // Ambos derivam de Conta (abstract) que expõe:int Numero { get; } || string Titular { get; }
            // decimal Saldo { get; set; } || void Depositar(decimal valor){} || virtual void Sacar(decimal valor){}
            // abstract void AplicarTaxaMensal(){}
            var conta1 = new Conta(1, "Joao", 1000m);
            var conta2 = new Conta(2, "Maria", 1500m);

            // Persistência: salva as contas via ContaService -> ArquivoContaRepository.Salvar()
            // ArquivoContaRepository.Salvar(Conta conta) sobrescreve/atualiza a lista no arquivo JSON.
            contaService.CriarConta(conta1);
            contaService.CriarConta(conta2);
          
            contaService.Depositar(1, 500m); // Operação de negócio: deposita R$500 na conta 1

            contaService.Sacar(2, 200m); // Operaçõa de negócio: saca R$200 da conta 2

            // Apresentação: percorre todas as contas e imprime resumo via RelatorioService.ImprimirResumo(Conta)
            relatorio.ImprimirResumoDeTodasAsContas(contaService.ListarContas());

            var conta3 = new Conta(3, "Carlos", 2000m);
            contaService.CriarConta(conta3);
            relatorio.ImprimirResumo(conta3); // Imprime resumo de uma conta especifica

            // Mantém a janela aberta para visualização
            Console.ReadKey();
        }
    }
}
