using Microsoft.EntityFrameworkCore;
using SaleSeeker_DAL;
using SaleSeeker_DAL.Models;
using Z.EntityFramework.Plus;

namespace SaleSeeker_Api.Repositories
{
    public class DbService : IDbService
    {
        private readonly SaleSeekerContext _saleSeekerContext;

        public DbService(SaleSeekerContext saleSeekerContext)
        {
            _saleSeekerContext = saleSeekerContext;
        }

        #region----------Select Methods----------

        public IQueryable<Product> GetProductItems(int maximumItemCount)
        {
            return _saleSeekerContext.Products.Where(p => p.IsActive).Skip(0).Take(maximumItemCount);
        }

        public IQueryable<Product> GetProductsInCategoryItems(int categoryId)
        {
            return _saleSeekerContext.Products.Where(p => p.CategoryId == categoryId && p.IsActive);
        }

        public IQueryable<Product> GetProductItem(int productId)
        {
            return _saleSeekerContext.Products.Where(p => p.Id == productId && p.IsActive);
        }

        public IQueryable<Cart> GetActiveCart(string userId)
        {
            return _saleSeekerContext.Carts.Where(c => c.UserId == userId && !c.IsCheckedOut);
        }

        public IQueryable<Cart> GetActiveCarts()
        {
            return _saleSeekerContext.Carts.Where(c => !c.IsCheckedOut);
        }

        public IQueryable<Stock> GetStock(int stockId)
        {
            return _saleSeekerContext.Stock
                .Include(st => st.Product)
                .Where(s => s.Product != null 
                            && s.IsActive 
                            && s.Id == stockId);
        }
        
        public IQueryable<Stock> GetStockItemsByCategory(int categoryId)
        {
            return _saleSeekerContext.Stock
                .Include(st => st.Product)
                .Where(s => s.Product != null 
                              && s.IsActive 
                              && s.Product.CategoryId == categoryId);
        }
        public IQueryable<Stock> GetStockItems()
        {
            return _saleSeekerContext.Stock.Where(s => s.IsActive);
        }

        public IQueryable<Item> GetCartItem(string userId, int productId)
        {
            return _saleSeekerContext.Items.Where(i => userId == i.UserId && i.ProductId == productId);
        }

        public IQueryable<Item> GetCartItems(string userId, int cartId)
        {
            return _saleSeekerContext.Items.Where(i => userId == i.UserId && i.CartId == cartId);
        }
        #endregion

        #region----------Insert Methods----------

        public Task<int> AddCart(Cart cart)
        {
            _saleSeekerContext.Carts.Add(cart);
            return _saleSeekerContext.SaveChangesAsync();
        }
        public Task<int> AddStock(Stock stock)
        {
            _saleSeekerContext.Stock.AddAsync(stock);
            return _saleSeekerContext.SaveChangesAsync();
        }
        public Task<int> AddCartItem(Item item)
        {
            _saleSeekerContext.Items.Add(item);
            return _saleSeekerContext.SaveChangesAsync();
        }

        public Task<int> AddCartItems(List<Item> items)
        {
            _saleSeekerContext.Items.AddRange(items);
            return _saleSeekerContext.SaveChangesAsync();
        }

        #endregion

        #region----------Update Methods----------

        public int UpdateCart(Cart cart)
        {
            _saleSeekerContext.Carts.Update(cart);
            return _saleSeekerContext.SaveChanges();
        }

        public int UpdateCartItem(Item item)
        {
            _saleSeekerContext.Items.Update(item);
            return _saleSeekerContext.SaveChanges();
        }
        public int UpdateCartItems(List<Item> items)
        {
            _saleSeekerContext.Items.UpdateRange(items);
            return _saleSeekerContext.SaveChanges();
        }

        public int UpdateStock(Stock stock)
        {
            _saleSeekerContext.Stock.Update(stock);
            return _saleSeekerContext.SaveChanges();
        }
        #endregion

        #region----------Delete Methods----------

        public bool DeleteCart(Cart cart)
        {
            var isSuccess = _saleSeekerContext.Carts.SingleDeleteAsync(cart).IsCompletedSuccessfully;
            return isSuccess;
        }
        public bool  DeleteCartItem(Item item)
        {
            var isSuccess = _saleSeekerContext.Items.SingleDeleteAsync(item).IsCompletedSuccessfully;
            return isSuccess;
        }

        public bool DeleteCartItems(List<Item> items)
        {
            var isSuccess = _saleSeekerContext.Items.BulkDeleteAsync(items).IsCompletedSuccessfully;
            return isSuccess;
        }
        
        public bool DisableStockItem(Stock stock)
        {
            stock.IsActive = false;
            stock.Product.IsActive = false;
            stock.UpdatedDatetime = DateTime.Now;
            
            var isSuccess = _saleSeekerContext.Stock.SingleUpdateAsync(stock).IsCompletedSuccessfully;
            return isSuccess;
        }
        
        #endregion
    }
}
