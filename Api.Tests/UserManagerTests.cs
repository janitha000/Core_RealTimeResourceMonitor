using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class UserManagerTests
{
    private UsersManager _userManager;
    private  Mock<IUserRepository> _mockRepository;


    public UserManagerTests()
    {
        
        _mockRepository = new Mock<IUserRepository>();
        _mockRepository.Setup(repo => repo.Get("Janitha")).Returns(new User(){ FirstName ="Janitha", LastName = "Tennakoon", Age = 26});

        _userManager = new UsersManager(_mockRepository.Object);

    }

    [TestMethod]
    public void IsUserNameNullTest()
    {
        User user = new User();
        Assert.IsTrue(_userManager.IsUserNameNull(user), "IsNull should be true when the user name is Null");
    }

    [TestMethod]
    public void TestGetUsers(){
        User user = _userManager.GetUser("Janitha");
        Assert.IsFalse(_userManager.IsUserNameNull(user), "A user should be returned from the database");
    }


}