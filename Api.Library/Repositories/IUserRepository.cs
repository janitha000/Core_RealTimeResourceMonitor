
public interface IUserRepository
{
    void Add(User data);
    User Get(string name);
    void Update(string name);
}