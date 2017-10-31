using Microsoft.AspNetCore.Mvc;

public class UserExistsAttribute : TypeFilterAttribute
{
    public UserExistsAttribute() : base (typeof(UserExistsAttributeFilter))
    {
        
    }
}