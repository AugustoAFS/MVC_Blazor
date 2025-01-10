namespace ElectroPoint.Models
{
    public class CarrinhoModel
    {
        public int Id_carrinho { get; set; }
        public List<string>? Itens { get; set; }
        public List<int>? Quantidade { get; set; }
        public string? Status { get; set; }
        public DateTime Hora_da_cricao { get; set; }

        // Propriedade de chave estrangeira para o usuário
        public int UserId { get; set; } // Esta propriedade deve existir para mapear o relacionamento com o usuário.

        // Propriedade de navegação para o usuário
        public UserModel? Usuario { get; set; }
    }


}
