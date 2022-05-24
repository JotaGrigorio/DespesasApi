using System;

namespace DespesasApi.Models
{
    public class Despesa
    {
        public Despesa(char tipo, string descricao, string pessoa, double valor, string formaPagamento)
        {
            Id = Guid.NewGuid().ToString();
            Tipo = tipo;
            Descricao = descricao;
            Data = DateTime.Now;
            Pessoa = pessoa;
            Valor = valor;
            FormaPagamento = formaPagamento;
            SeriaPaga = false;
        }

        public string Id { get; set; }
        public char Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public string Pessoa { get; set; } 
        public double Valor { get; set; }
        public string FormaPagamento { get; set; }    
        public bool SeriaPaga { get; set; }    
    }
}
