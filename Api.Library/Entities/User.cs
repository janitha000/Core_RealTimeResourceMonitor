using System.ComponentModel.DataAnnotations;

public class User : BaseEntity
{

    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }




}