namespace DespesasApi.Models.DTO
{
    public class DespesaDTO
    {
        public char Tipo { get; set; }
        public string Descricao { get; set; }
        public string Pessoa { get; set; }
        public double Valor { get; set; }
        public string FormaPagamento { get; set; }
    }
}
