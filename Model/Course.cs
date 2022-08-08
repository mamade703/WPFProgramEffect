using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProgramEffect.Model
{
    public class Course
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "语文";
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public string CreateUser { get; set; } = "李永乐";
    }
}
