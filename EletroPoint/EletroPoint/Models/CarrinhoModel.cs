namespace EletroPoint.Models
{
    public class CarrinhoModel
    {
        public int Id_carrinho { get; set; }
        public List<string> Itens { get; set; }
        public List<int> Quantidade { get; set; }
        public string Status { get; set; }
        public DateTime Hora_da_cricao { get; set; }
        public int UserId { get; set; }
        public UserModel? Usuario { get; set; }
    }
}
