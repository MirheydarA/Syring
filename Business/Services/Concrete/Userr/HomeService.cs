using Business.Services.Abstract.User;
using Common.Entities;
using DataAccess.Repositories.Abstract.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete.Userr
{
    public class HomeService : IHomeService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IOurVisionRepository _ourVisionRepository;
        private readonly IOurVisionComponentRepository _ourVisionComponentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentComponentRepository _departmentComponentRepository;
        private readonly IAbuotUsRepository _abuotUsRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IWhyChooseRepository _whyChooseRepository;

        public HomeService(ISliderRepository sliderRepository, 
                           IOurVisionRepository ourVisionRepository, 
                           IOurVisionComponentRepository ourVisionComponentRepository,
                           IDepartmentRepository departmentRepository,
                           IDepartmentComponentRepository departmentComponentRepository,
                           IAbuotUsRepository abuotUsRepository,
                           IVideoRepository videoRepository,
                           IDoctorRepository doctorRepository,
                           IWhyChooseRepository whyChooseRepository)
        {
            _sliderRepository = sliderRepository;
            _ourVisionRepository = ourVisionRepository;
            _ourVisionComponentRepository = ourVisionComponentRepository;
            _departmentRepository = departmentRepository;
            _departmentComponentRepository = departmentComponentRepository;
            _abuotUsRepository = abuotUsRepository;
            _videoRepository = videoRepository;
            _doctorRepository = doctorRepository;
            _whyChooseRepository = whyChooseRepository;
        }
        public async Task<List<Slider>> GetSlidersAsync()
        {
            var sliders = await _sliderRepository.GetAllAsync();
            return sliders;
        }
        public async Task<List<OurVision>> GetOurVisionAsync()
        {
            var ourVision = await _ourVisionRepository.GetAllAsync();
            return ourVision;
        }
        public async Task<List<OurVisionComponent>> GetVisionsAsync()
        {
            var visions = await _ourVisionComponentRepository.GetAllAsync();
            return visions;
        }
        public Task<List<AboutUs>> GetAboutUsAsync()
        {
            var aboutUs = _abuotUsRepository.GetAllAsync();
            return aboutUs;
        }
        public async Task<List<Department>> DepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return departments;
        }
        public async Task<List<DepartmentComponent>> DepartmentComponentsAsync()
        {
            var departmentComponents = await _departmentComponentRepository.GetAllAsync();
            return departmentComponents;
        }

        public async Task<List<Video>> GetVideosAsync()
        {
            var videos =await _videoRepository.GetAllAsync();
            return videos;
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetDoctorsWithDuty();
            return doctors;
        }

        public async Task<List<WhyChoose>> GetWhyChoosesAsync()
        {
            var whyChooses = await _whyChooseRepository.GetAllAsync();
            return whyChooses;
        }
    }
}
