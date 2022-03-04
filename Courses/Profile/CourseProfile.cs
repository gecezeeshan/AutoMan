namespace Courses.Profile
{
    public class CourseProfile : AutoMapper.Profile
    {
        public CourseProfile()
        {
            CreateMap<Courses.Db.Course,Courses.Model.Course>();
        }
    }
}
