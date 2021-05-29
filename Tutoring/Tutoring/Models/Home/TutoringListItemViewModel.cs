namespace Tutoring.Models
{
    public class TutoringListItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserInfoViewModel Author { get; set; }

    }
}