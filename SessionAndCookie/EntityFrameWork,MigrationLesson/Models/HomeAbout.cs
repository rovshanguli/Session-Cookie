using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWork_MigrationLesson.Models
{
    public class HomeAbout : BaseEntity
    {
        public string Image { get; set; }
        public string Header { get; set; }
        public string Desciription { get; set; }
    }
}
