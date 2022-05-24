using DespesasApi.Models;
using System.Collections.Generic;

namespace DespesasApi.Data.Repositories
{
    public interface IDespesasRepository
    {
        void Adicionar(Despesa despesa);
        void Atualizar(string id, Despesa despesaAtualizada);
        IEnumerable<Despesa> Buscar();
        Despesa Buscar(string id);
        void Excluir(string id);
    }
}
