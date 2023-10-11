using SaleSeeker_DAL.Models;

namespace SaleSeeker_Api.Repositories
{
    public interface IDbService
    {
        #region----------Select Methods----------
        public IQueryable<Product> GetProductItems(int maximumItemCount);
        public IQueryable<Product> GetProductsInCategoryItems(int categoryId);
        public IQueryable<Product> GetProductItem(int productId);
        public IQueryable<Cart> GetActiveCart(string userId);
        public IQueryable<Cart> GetActiveCarts();
        public IQueryable<Stock> GetStock(int stockId);
        public IQueryable<Stock> GetStockItems();
        public IQueryable<Stock> GetStockItemsByCategory(int categoryId);
        public IQueryable<Item> GetCartItem(string userId, int productId);
        public IQueryable<Item> GetCartItems(string userId, int cartId);

        #endregion

        #region----------Add Methods----------

        public Task<int> AddCart(Cart cart);
        public Task<int> AddCartItem(Item item);
        public Task<int> AddCartItems(List<Item> items);
        public Task<int> AddStock(Stock stock);
        #endregion

        #region----------Update Methods----------
        public int UpdateCart(Cart cart);
        public int UpdateCartItem(Item item);
        public int UpdateCartItems(List<Item> items);
        public int UpdateStock(Stock stock);
        
        #endregion

        #region----------Delete Methods----------
        public bool DeleteCart(Cart cart);
        public bool  DeleteCartItem(Item item);
        public bool DeleteCartItems(List<Item> items);
        public bool DisableStockItem(Stock stock);

        #endregion
    }
}
