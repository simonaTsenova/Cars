using System.ComponentModel.DataAnnotations;

namespace Cars.Web.Models
{
    public class SearchViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int OwnerId { get; set; }
    }
}