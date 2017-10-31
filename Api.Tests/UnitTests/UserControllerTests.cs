using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class UserControllerTests
{
    protected UserController userController;
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
        moqUserManager.Setup(x => x.GetAll()).Returns(expectedUsers).Verifiable();

        var result = userController.GetAllAsync();
        moqUserManager.Verify(x => x.GetAll(), Times.Once);
        //Assert.AreSame(expectedUsers, result.Result, "Should return users");
    }



}