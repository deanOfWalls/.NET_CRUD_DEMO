using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PersonModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? FirstName { get; set; }
        
        [Required]
        public string? LastName { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
