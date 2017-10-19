using System.ComponentModel.DataAnnotations;

namespace Cars.Web.Models
{
    public class SearchViewModel
    {
        [Required]
        public int OwnerId { get; set; }
    }
}