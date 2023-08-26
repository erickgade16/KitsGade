using KitsGade.Context;
using KitsGade.Repositories.Interfaces;

namespace KitsGade.Repositories
{
    public class ProdutosRepository:IProdutosRepository
    {
        private readonly AppDbContext _context;

        public ProdutosRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
