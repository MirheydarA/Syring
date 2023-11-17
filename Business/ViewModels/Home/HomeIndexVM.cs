using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ViewModels.Home
{
    public class HomeIndexVM
    {
        public List<Slider> Sliders { get; set; }
        public List<OurVision> OurVisions { get; set; }
        public List<OurVisionComponent> OurVisionComponents { get; set; }
        public List<AboutUs> AboutUs { get; set; }
        public List<Department> Departments { get; set; }
        public List<DepartmentComponent> DepartmentComponents { get; set; }
        public List<Video> Videos { get; set; }
        public List<Common.Entities.Doctor> Doctors { get; set; }
        public List<WhyChoose> WhyChooses { get; set; }

    }
}
