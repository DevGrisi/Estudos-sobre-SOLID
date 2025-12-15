using Solid.Entidades;
using Solid.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace Solid.Services.Implementações
{
    public class ArquivoContaRepository : IContaRepository
    {
        private const string Arquivo = "contas.json";

        /// <summary>
        /// Método auxiliar para carregar as contas do arquivo JSON.
        /// </summary>
        private List<Conta> CarregarArquivo()
        {
            if (!File.Exists(Arquivo))    // Verifica se o arquivo existe
                return new List<Conta>(); // Retorna uma lista vazia se o arquivo não existir


            var json = File.ReadAllText(Arquivo);                // Lê o conteúdo do arquivo
            return JsonSerializer.Deserialize<List<Conta>>(json) ?? new List<Conta>();// Retorna uma lista vazia se a desserialização resultar em null
            // IncludeFields significa que todos os campos (mesmo privados) serão considerados na serialização/deserialização
            // Normalmente não é utilizado, mas aqui é necessário para que o JsonSerializer funcione corretamente com os campos das classes derivadas de Conta.
        }

        /// <summary>
        /// Método para salvar uma conta
        /// </summary>
        public void Salvar(Conta conta)
        {
            // Carrega todas as contas existentes
            var contas = CarregarArquivo();
            contas.RemoveAll(c => c.Numero == conta.Numero); // Remove a conta existente com o mesmo número, se houver
            contas.Add(conta); // Adiciona a nova conta


            var json = JsonSerializer.Serialize(contas, // Ajuste para a serialização do JSON
            new JsonSerializerOptions { WriteIndented = true, IncludeFields = true }); // Formata o JSON com indentação para melhor legibilidade (WriteIndented = true)

            File.WriteAllText(Arquivo, json); // Salva o JSON atualizado no arquivo
        }


        /// <summary>
        /// Método para obter uma conta pelo número
        /// </summary>
        public Conta Obter(int numero)
        {
            // Carrega todas as contas e retorna a que corresponde ao número fornecido
            return CarregarArquivo().FirstOrDefault(c => c.Numero == numero); 
        }

        /// <summary>
        /// Método para listar todas as contas
        /// </summary>
        public List<Conta> Listar()
        {
            return CarregarArquivo();
        }
    }
}
