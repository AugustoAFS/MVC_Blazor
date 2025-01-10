namespace ElectroPoint.Models
{
    public class MarcaModel
    {
        public int Id_marca { get; set; }
        public string? Nome { get; set; }
        public bool Status {  get; set; }

        public required ICollection<EletronicosModel> Eletronicos { get; set; }
    }
}