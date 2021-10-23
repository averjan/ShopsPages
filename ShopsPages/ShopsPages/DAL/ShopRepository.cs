using Microsoft.EntityFrameworkCore;
using ShopsPages.Models;

namespace ShopsPages.DAL
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(ShopsContext context) : base(context)
        {
        }

        public override Shop? GetById(int? id)
        {
            try
            {
                var activeShop = this.dbSet
                            .Include(s => s.Products)
                            .FirstOrDefault(s => s.ShopId == id);

                activeShop.Products = activeShop.Products.OrderBy(p => p.ProductId).ToList();
                return activeShop;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override IEnumerable<Shop> GetAll()
        {
            try
            {
                return this.dbSet.ToList();
            }
            catch (Exception)
            {
                return new List<Shop>();
            }
        }

        public override bool Delete(int? id)
        {
            try
            {
                var exist = dbSet.Where(x => x.ShopId == id).FirstOrDefault();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Update(Shop entity)
        {
            try
            {
                var toUpdate = this.dbSet.FirstOrDefault(p => p.ShopId == entity.ShopId);
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
