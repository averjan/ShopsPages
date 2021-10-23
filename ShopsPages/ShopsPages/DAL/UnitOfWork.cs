using ShopsPages.Models;

namespace ShopsPages.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ShopsContext _context;
        public IShopRepository Shops { get; private set; }

        public IProductRepository Products { get; private set; }

        public UnitOfWork(ShopsContext context)
        {
            this._context = context;
            this.Shops = new ShopRepository(context);
            this.Products = new ProductRepository(context);
        }

        public void Complete()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
