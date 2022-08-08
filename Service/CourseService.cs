using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFProgramEffect.Model;

namespace WPFProgramEffect.Service
{
    public class CourseService : ICourseService
    {
        public async Task<List<Course>> GetCourseAsync()
        {
            return await Task.Run(() =>
            {
                List<Course> retValue = new List<Course>();
                retValue.Add(new Course() { Name = "数学" });
                retValue.Add(new Course() { Name = "化学" });
                retValue.Add(new Course() { Name = "物理" });
                retValue.Add(new Course() { Name = "音乐" });

                return retValue;
            });
        }
    }
}
