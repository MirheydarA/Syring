using Business.Services.Abstract.User;
using Business.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexVM
            {
                Sliders = await _homeService.GetSlidersAsync(),
                OurVisions = await _homeService.GetOurVisionAsync(),
                OurVisionComponents = await _homeService.GetVisionsAsync(),
                Departments = await _homeService.DepartmentsAsync(),
                DepartmentComponents = await _homeService.DepartmentComponentsAsync(),
                AboutUs = await _homeService.GetAboutUsAsync(),
                Videos = await _homeService.GetVideosAsync(),
                Doctors = await _homeService.GetDoctorsAsync(),
                WhyChooses = await _homeService.GetWhyChoosesAsync(),
            };
            return View(model);
        }
    }
}
