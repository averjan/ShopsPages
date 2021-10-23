namespace ShopsPages.DAL
{
    public interface IUnitOfWork
    {
        IShopRepository Shops { get; }
        IProductRepository Products { get; }
        void Complete();
    }
}
