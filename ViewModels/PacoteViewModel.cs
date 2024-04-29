namespace SucessoEventos.ViewModels;
public class PacoteViewModel
{
    public int CodPac { get; set; }
    public decimal Preco { get; set; }
    public string Descricao { get; set; }
    public string DescricaoDetalhada => $"{Descricao} - R${Preco}";
}