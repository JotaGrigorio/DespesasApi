using DespesasApi.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using DespesasApi.Data.Configurations;

namespace DespesasApi.Data.Repositories
{
    public class DespesasRepository : IDespesasRepository
    {
        private readonly IMongoCollection<Despesa> _despesas;

        public DespesasRepository(IDataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DataBaseName);

            _despesas = database.GetCollection<Despesa>("despesas");
        }

        public void Adicionar(Despesa despesa)
        {
            _despesas.InsertOne(despesa);
        }

        public void Atualizar(string id, Despesa despesaAtualizada)
        {
            _despesas.ReplaceOne(d => d.Id == id, despesaAtualizada);
        }

        public IEnumerable<Despesa> Buscar()
        {
            return _despesas.Find(d => true).ToList();
        }

        public Despesa Buscar(string id)
        {
            return _despesas.Find(d => d.Id == id).FirstOrDefault();
        }

        public void Excluir(string id)
        {
            _despesas.DeleteOne(d => d.Id == id);
        }
    }
}
