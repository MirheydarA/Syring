using Business.Services.Abstract.User;
using Business.ViewModels.Basket;
using Common.Entities;
using DataAccess.Repositories.Abstract.Userr;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Userr
{
    public class BasketService : IBasketService
    {
        private readonly UserManager<Common.Entities.User> _userManager;
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BasketService(UserManager<Common.Entities.User> userManager, IBasketRepository basketRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BasketVM>> IndexGetBasket(ClaimsPrincipal user)
        {
            var authUser = await _userManager.GetUserAsync(user);
            if (authUser == null)
            {
                return null;
            }

            var basket = await _basketRepository.GetBasketWithProductsAsync(authUser);

            var model = new List<BasketVM>();

            if (basket is null)
                return null;

            foreach (var basketProduct in basket.BasketProducts)
            {
                var basketItem = new BasketVM
                {
                    Id = basketProduct.Id,
                    Count = basketProduct.Count,
                    PhotoName = basketProduct.Product.PhotoName,
                    StockQuantity = basketProduct.Product.Quantity,
                    Title = basketProduct.Product.Name,
                    Price = basketProduct.Product.Price
                };
                model.Add(basketItem);
            }

            return model;
        }

        public async Task<bool> AddAsync(ClaimsPrincipal user, int id)
        {
            var authUser = await _userManager.GetUserAsync(user);
            if (authUser == null)
            {
                return false;
            }

            var basket = await _basketRepository.GetBasketByIdAsync(authUser);

            if (basket is null)
            {
                basket = new Basket
                {
                    UserId = authUser.Id,
                };
                _basketRepository.CreateAsync(basket);
            }

            var product = await _productRepository.GetByIdAsync(id);
            if (product is null) return false;

            var basketProduct = await _basketRepository.GetProductByBasketProductIdAsync(id, authUser);

            if (basketProduct is null)
            {
                basketProduct = new BasketProduct
                {
                    Basket = basket,
                    ProductId = product.Id,
                    Count = 1
                };
                await _basketRepository.AddBasketProductAsync(basketProduct);
            }

            else
            {
                basketProduct.Count++;
                _basketRepository.UpdateBasketProduct(basketProduct);
            }

            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<bool> IncreaseAsync(ClaimsPrincipal user, int id)
        {
            var authUser = await _userManager.GetUserAsync(user);
            if (authUser == null)
            {
                return false;
            }

            var basket = await _basketRepository.GetBasketByIdAsync(authUser);
            if (basket == null) return false;

            var basketProduct = await _basketRepository.GetBasketProductByIdAsync(id, basket);
            if (basketProduct == null)
            {
                return false;
            }
            var product = await _productRepository.GetByIdAsync(basketProduct.ProductId);
            if (product == null)
            {
                return false;
            }

            if (product.Quantity == basketProduct.Count)
                return false;

            basketProduct.Count++;

            _basketRepository.UpdateBasketProduct(basketProduct);
            await _unitOfWork.CommitAsync();

            return true;

        }

        public async Task<bool> DecreaseAsync(ClaimsPrincipal user, int id)
        {
            var authUser = await _userManager.GetUserAsync(user);
            if (authUser == null)
            {
                return false;
            }

            var basket = await _basketRepository.GetBasketByIdAsync(authUser);
            if (basket == null) return false;

            var basketProduct = await _basketRepository.GetBasketProductByIdAsync(id, basket);
            if (basketProduct == null)
            {
                return false;
            }

            if (basketProduct.Count == 0)
                return false;

            basketProduct.Count--;

            _basketRepository.UpdateBasketProduct(basketProduct);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(ClaimsPrincipal user, int id)
        {
            var authUser = await _userManager.GetUserAsync(user);
            if (authUser == null)
            {
                return false;
            }

            var basket = await _basketRepository.GetBasketByIdAsync(authUser);
            if (basket == null) return false;

            var basketProduct = await _basketRepository.GetBasketProductByIdAsync(id, basket);
            if (basketProduct == null)
            {
                return false;
            }

            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }

            _basketRepository.DeleteBasketProduct(basketProduct);
            await _unitOfWork.CommitAsync();
            return true;

        }
    }
}
