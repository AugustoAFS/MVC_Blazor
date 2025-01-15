namespace EletroPoint.Models
{
    public class AdminModel
    {
        public int Id_admin { get; set; }
        public string Nome { get; set; }
        public decimal Cpf { get; set; }
        public string Email { get; set; }
        public string Funcao { get; set; }
        public bool Status { get; set; }
    }
}
