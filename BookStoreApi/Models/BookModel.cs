using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "BookTitle is required")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
