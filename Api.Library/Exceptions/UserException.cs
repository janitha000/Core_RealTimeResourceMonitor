public class UserException : WebApiException
{

    public UserException(User user) : this(user.FirstName)
    {

    }
    public UserException(string username) : base($"User {username} was not found")
    {

    }
}