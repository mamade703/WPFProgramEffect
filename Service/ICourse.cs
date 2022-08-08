using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFProgramEffect.Model;

namespace WPFProgramEffect.Service
{
    public interface ICourseService
    {
        Task<List<Course>> GetCourseAsync();
    }
}
