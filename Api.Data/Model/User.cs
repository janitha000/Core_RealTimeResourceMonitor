using System.ComponentModel.DataAnnotations;

public class User {

    [Key]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    
    
    
    
}