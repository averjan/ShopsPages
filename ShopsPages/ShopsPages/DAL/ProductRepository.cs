using ShopsPages.Models;

namespace ShopsPages.DAL
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopsContext context) : base(context)
        {
        }

        public override IEnumerable<Product> GetAll()
        {
            try
            {
                return this.dbSet.ToList();
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public override bool Delete(int? id)
        {
            try
            {
                var exist = dbSet.Where(x => x.ProductId == id).FirstOrDefault();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(Product entity)
        {
            try
            {
                var toUpdate = this.dbSet.FirstOrDefault(p => p.ProductId == entity.ProductId);
                this.context.Entry(toUpdate).CurrentValues.SetValues(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
