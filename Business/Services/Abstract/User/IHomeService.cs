using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract.User
{
    public interface IHomeService
    {
        Task<List<Slider>> GetSlidersAsync();
        Task<List<OurVision>> GetOurVisionAsync();
        Task<List<OurVisionComponent>> GetVisionsAsync();
        Task<List<AboutUs>> GetAboutUsAsync();
        Task<List<Department>> DepartmentsAsync();
        Task<List<DepartmentComponent>> DepartmentComponentsAsync();
        Task<List<Video>> GetVideosAsync();
        Task<List<Doctor>> GetDoctorsAsync();
        Task<List<WhyChoose>> GetWhyChoosesAsync();
    }   
}
