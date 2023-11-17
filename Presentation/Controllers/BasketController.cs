using Business.Services.Abstract.User;
using Business.ViewModels.Basket;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _basketService.IndexGetBasket(User));
        }
        [HttpGet]
        public async Task<IActionResult> AddAsync(BasketVM model)
        {
            var isSucceded = await _basketService.AddAsync(User, model.Id);
            if (!isSucceded) return NotFound("Nese duz getmedi");

            return Ok("Mehsul ugurla elave edildi");
        }

        public async Task<IActionResult> Increase(BasketVM model)
        {
            var isSucceded = await _basketService.IncreaseAsync(User, model.Id);
            if (!isSucceded) return NotFound("Nese duz getmedi");

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Decrease(BasketVM model)
        {
            var isSucceded = await _basketService.DecreaseAsync(User, model.Id);
            if (!isSucceded) return NotFound("Nese duz getmedi");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(BasketVM model)
        {
            var isSucceded = await _basketService.DeleteAsync(User, model.Id);
            if (!isSucceded) return NotFound("Nese duz getmedi");

            return RedirectToAction(nameof(Index));
        }


    }
}
