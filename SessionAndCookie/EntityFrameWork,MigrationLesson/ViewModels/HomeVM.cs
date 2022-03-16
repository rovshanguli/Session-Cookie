using EntityFrameWork_MigrationLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWork_MigrationLesson.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public SliderDetail Detail { get; set; }
        public List<Catagory> Catagories { get; set; }
        public List<Product> Products { get; set; }
        public HomeAbout About { get; set; }
        public List<Expert> Experts { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Instagram> Instagrams { get; set; }
    }
}
