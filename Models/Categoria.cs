namespace KitsGade.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string CategoriaName { get; set; }
        public string Descricao { get; set; }
        public string Subtitulo { get; set; }

        public List<Produto> Produtos  { get; set; }
    }
}
