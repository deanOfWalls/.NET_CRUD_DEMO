using System;
using System.ComponentModel.DataAnnotations;

public class Person
{
    [Key] //sets primary key
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; } //PascalCase is used for naming variables, methods, properties
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }
}