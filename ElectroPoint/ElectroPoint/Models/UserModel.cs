namespace ElectroPoint.Models
{
    public class UserModel
    {
        public int Id_user { get; set; }
        public string? Nome { get; set; }
        public decimal? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Funcao { get; set; }
        public string? Status { get; set; }

        public int UserId { get; set; }

        public ICollection<CarrinhoModel>? Carrinhos { get; set; }
    }
}
