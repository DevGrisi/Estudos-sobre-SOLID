using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Solid.SOLID
{
    //Por exemplo, um serviço de conta bancária pode depender de um repositório abstrato
    //IRepositorioDeContas em vez de uma implementação específica de banco de dados.Abaixo, ServicoDeConta
    //recebe via injeção de dependência um IRepositorioDeContas, sem saber se é MySQL, SQL Server, etc.
    //Isso segue o Principio de inversão de Denpendencia, pois o serviço(modulo de alto nível)
    //usa apenas a abstração.


    /// <summary>
    /// Clase que representa uma conta bancária, afim de exemplificar.
    /// </summary>
    public class ContaBancaria
    {
        public string NumeroConta { get; set; }
    }


    /// <summary>Interface que define operações de armazenamento para contas bancárias.</summary>
    public interface IRepositorioDeContas
    {
        /// <summary>Salva a conta bancária no repositório de dados.</summary>
        void Salvar(ContaBancaria conta);
    }


    /// <summary>
    /// Implementação CONCRETA de repositório usando um banco de dados SQL.
    /// </summary>
    public class RepositorioSqlDeContas : IRepositorioDeContas
    {
        /// <summary>Salva a conta usando SQL.</summary>
        public void Salvar(ContaBancaria conta)
        {
            // Logica de persistência em banco de dados (SQL)
            Console.WriteLine("Conta salva no banco de dados SQL.");
        }
    }

    /// <summary>
    /// Serviço de aplicação que utiliza abstração de repositorio, não dependendo de implementação concreta.
    /// </summary>
    public class D_ServicoDeConta
    {
        /// <summary>
        /// É a abstração do repositório de contas.
        /// </summary>
        private readonly IRepositorioDeContas _repositorio;

        /// <summary>
        /// Constrói o serviço de conta injetando a abstração do repositório.
        /// </summary>
        public D_ServicoDeConta(IRepositorioDeContas repositorio)
        {
            _repositorio = repositorio; // injeção de dependencia do repositorio de contas
        }

        /// <summary>
        /// Adiciona uma nova conta e persiste usando o repositorio injetado.
        /// </summary>
        public void AdicionarConta(ContaBancaria conta)
        {
            _repositorio.Salvar(conta);
        }
    }

}
