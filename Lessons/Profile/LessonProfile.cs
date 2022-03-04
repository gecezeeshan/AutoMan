namespace Lessons.Profile
{
    public class LessonProfile : AutoMapper.Profile
    {
        public LessonProfile()
        {
            CreateMap<Lessons.Db.Lesson,Lessons.Model.Lesson>();
        }
    }
}
