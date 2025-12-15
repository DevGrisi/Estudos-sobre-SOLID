using Solid.Entidades;
using Solid.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Services
{
    /// <summary>
    /// Serviço responsável pelas regras de negócio das contas
    /// </summary>
    public class ContaService
    {
        // Repositório de contas (injetado via construtor)
        private readonly IContaRepository _repositorio;

        /// <summary>
        /// Serviço responsável pelo repositório de contas
        /// </summary>
        public ContaService(IContaRepository repositorio) // Injeção de dependência do repositório
        {
            _repositorio = repositorio; // Atribui o repositório injetado ao campo privado
        }

        /// <summary>
        /// Método para criar uma nova conta
        /// </summary>
        public void CriarConta(Conta conta)
        {
            _repositorio.Salvar(conta);
        }

        /// <summary>
        /// Método para depositar um valor em uma conta
        /// </summary>
        public void Depositar(int numero, decimal valor)
        {
            var conta = _repositorio.Obter(numero); // Obtém a conta pelo número
            conta.Depositar(valor);                 // Realiza o depósito
            _repositorio.Salvar(conta);             // Salva a conta atualizada no repositório
        }


        public void Sacar(int numero, decimal valor)
        {
            var conta = _repositorio.Obter(numero); // Obtém a conta pelo número
            conta.Sacar(valor);                     // Realiza o saque
            _repositorio.Salvar(conta);             // Salva a conta atualizada no repositório
        }


        /// <summary>
        /// Método para listar todas as contas
        /// </summary>
        public List<Conta> ListarContas() 
        {
            return _repositorio.Listar();
        }
    }
}
