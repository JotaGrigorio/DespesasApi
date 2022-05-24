using DespesasApi.Data.Repositories;
using DespesasApi.Models;
using DespesasApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DespesasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesasController : ControllerBase
    {
        private IDespesasRepository _despesasRepository;

        public DespesasController(IDespesasRepository despesasRepository)
        {
            _despesasRepository = despesasRepository;
        }

        // GET: api/despesas
        [HttpGet]
        public IActionResult Get()
        {
            var despesas = _despesasRepository.Buscar();
            return Ok(despesas);            
        }

        // GET api/despesas/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var despesa = _despesasRepository.Buscar(id);
            return Ok(despesa);
        }

        // POST api/despesas
        [HttpPost]
        public string Post([FromBody] DespesaDTO novaDespesa)
        {
            var despesa = new Despesa(novaDespesa.Tipo, novaDespesa.Descricao, novaDespesa.Pessoa, novaDespesa.Valor, novaDespesa.FormaPagamento);
            _despesasRepository.Adicionar(despesa);

            return "Despesa inclusa com sucesso!";
        }

        // PUT api/despesas/{id}
        [HttpPut("{id}")]
        public string Put(string id, [FromBody] Despesa despesaAtualizada)
        {
            if (string.IsNullOrEmpty(id))
                return "Despesa não encontrada! Por favor, tente novamente!";

             _despesasRepository.Atualizar(id, despesaAtualizada);

            return "Despesa alterada com sucesso!";
        }

        // DELETE api/despesas/{id}
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return "Despesa não encontrada! Por favor, tente novamente!";

            _despesasRepository.Excluir(id);

            return "Despesa excluída com sucesso!";
        }
    }
}
