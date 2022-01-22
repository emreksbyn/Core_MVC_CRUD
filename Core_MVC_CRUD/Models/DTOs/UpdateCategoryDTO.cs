using System.ComponentModel.DataAnnotations;

namespace Core_MVC_CRUD.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Boş Bırakılamaz !")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz !")]
        [MinLength(3,ErrorMessage = "Min 3 Karakter")]
        public string Description { get; set; }
    }
}
