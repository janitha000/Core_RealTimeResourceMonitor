using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class UserControllerTests {
    protected  UserController userController;
    protected Mock<IManager<User>> moqUserManager;

    public UserControllerTests()
    {
        moqUserManager = new Mock<IManager<User>>();
        userController = new UserController(moqUserManager.Object);
    }

    [TestMethod]
    public void Should_return_user_list()
    {
        var expectedUsers = new User[]
        {
            new User { FirstName = "Janitha", LastName = "Tennakoon"},
            new User {FirstName = "Vindya", LastName = "Hettige"}
        };
        moqUserManager.Setup(x => x.GetAll()).Returns(expectedUsers);
        
        var result =  userController.GetAllAsync();
        Assert.AreSame(expectedUsers, result.Result,"Should return users");


    }

}