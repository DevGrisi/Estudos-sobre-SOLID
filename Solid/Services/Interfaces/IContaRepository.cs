using Solid.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Services.Interfaces
{
    /// <summary>
    /// Contrato para persistência de contas bancárias.
    /// </summary>
    public interface IContaRepository
    {
        void Salvar(Conta conta);
        Conta Obter(int numero);
        List<Conta> Listar();
    }
}
