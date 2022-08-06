using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entity
{
    public class Books
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "BookTitle is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "BookDescription is required")]
        public string Description { get; set; }
    }
}
