namespace SucessoEventos.ViewModels;
public class AtividadeViewModel {
    public int CodAtv { get; set; }
    public string DescAtv { get; set; }
    public int Vagas { get; set; }
    public decimal Preco { get; set; }
    public bool Selected { get; set; }
    public string DescricaoDetalhada => $"{DescAtv} - R${Preco}";
}
