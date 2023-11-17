using Common.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstract.Userr;
using DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete.Userr
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        private readonly AppDbContext _context;

        public BasketRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddBasketProductAsync(BasketProduct basketProduct)
        {
           await _context.BasketProducts.AddAsync(basketProduct);
        }

        public void DeleteBasketProduct(BasketProduct basketProduct)
        {
            _context.Remove(basketProduct);
        }

        public async Task<Basket> GetBasketByIdAsync(Common.Entities.User user)
        {
            var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.UserId == user.Id);
            return basket;
        }

        public async Task<BasketProduct> GetBasketProductByIdAsync(int id, Basket basket)
        {
            var basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(bp => bp.Id == id && bp.BasketId == basket.Id);
            return basketProduct;
        }

        public async Task<Basket> GetBasketWithProductsAsync(Common.Entities.User user)
        {
            var basket = await _context.Baskets.Include(b => b.BasketProducts).ThenInclude(bp => bp.Product).Where(bp => !bp.IsDeleted).FirstOrDefaultAsync(b => b.UserId == user.Id);
            return basket;
        }

        public async Task<BasketProduct>? GetProductByBasketProductIdAsync(int id, Common.Entities.User user)
        {
            var basketProduct = await _context.BasketProducts.FirstOrDefaultAsync(basketProduct => basketProduct.ProductId == id && basketProduct.Basket.UserId == user.Id);
            return basketProduct;
        }

        public void UpdateBasketProduct(BasketProduct basketProduct)
        {
             _context.Update(basketProduct);
        }
    }
}
