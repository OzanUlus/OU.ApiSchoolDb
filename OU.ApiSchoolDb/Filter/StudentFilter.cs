using OU.ApiSchoolDb.Models;

namespace OU.ApiSchoolDb.Filter
{
    public class StudentFilter
    {
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
    }
}
