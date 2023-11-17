using Common.Entities;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract.Userr
{
    public interface IBasketRepository : IRepository<Basket>
    {
        Task<Basket> GetBasketWithProductsAsync(Common.Entities.User user);
        Task<Basket> GetBasketByIdAsync(Common.Entities.User user);
        //Task AddAsync(Basket basket);
        Task<BasketProduct> GetProductByBasketProductIdAsync(int id, Common.Entities.User user);
        Task AddBasketProductAsync(BasketProduct basketProduct);
        void UpdateBasketProduct(BasketProduct basketProduct);
        Task<BasketProduct>? GetBasketProductByIdAsync(int id, Basket basket);
        void DeleteBasketProduct(BasketProduct basketProduct);

    }
}
