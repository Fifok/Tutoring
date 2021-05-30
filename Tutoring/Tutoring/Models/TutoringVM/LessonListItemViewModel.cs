namespace Tutoring.Models.TutoringVM
{
    public class LessonListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public UserInfoViewModel Author { get; set; }
        public int Index { get; set; }
    }
}