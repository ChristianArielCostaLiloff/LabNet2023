using System.ComponentModel.DataAnnotations;

namespace Practica6.MVC.Models
{
    public class CustomersView
    {
        [Required(ErrorMessage = "Id es requerido.")]
        [StringLength(5, ErrorMessage = "Id tiene que tener 5 caracteres maximo.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Nombre de la compañia es requerido.")]
        [StringLength(40, 
            ErrorMessage = "Id no puede exceder de 40 caracteres.")]
        public string CompanyName { get; set; }
        [StringLength(30, 
            ErrorMessage = "Nombre del contacto no puede exceder de 30 caracteres.")]
        public string ConctactName { get; set; }
        [StringLength(15, 
            ErrorMessage = "Ciudad no puede exceder de 15 caracteres.")]
        public string City { get; set; }
        [StringLength(24, 
            ErrorMessage = "El numero de telefono no puede exceder de 24 caracteres.")]
        public string Phone { get; set; }
    }
}