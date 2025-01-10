namespace ElectroPoint.Models
{
    public class EletronicosModel
    {
        public int Id_eletronicos { get; set; }
        public string? Nome { get; set; }
        public string? Cor {  get; set; }
        public string? Descricao { get; set; }
        public int Quantidade { get; set; }
        public string? Status {  get; set; }

        public int MarcaId {  get; set; }
        public MarcaModel? Marca { get; set; }

    }
}
