using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutoring.Models.Db.Models
{
    public class Tutorial
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<TutorialTag> Tags { get; set; }
        public ICollection<Page> Pages { get; set; }
    }
}
