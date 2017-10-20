using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class UserManagerTests
{
    private UsersManager _userManager;
    private Mock<IRepository<User>> _mockRepository;


    public UserManagerTests()
    {


        _mockRepository = new Mock<IRepository<User>>();

        _mockRepository.Setup(repo => repo.Get(mockUser => mockUser.FirstName == "Janitha")).Returns(new User() { FirstName = "Janitha", LastName = "Tennakoon", Age = 26 });

        _userManager = new UsersManager(_mockRepository.Object);

    }

    [TestMethod]
    public void Should_return_all_users()
    {
        var expectedUsers = new List<User>{
            new User(){ FirstName = "Janitha", LastName = "Tennakoon", Age=27},
            new User() { FirstName = "Vindya", LastName = "Hettige", Age = 27}
        };
        _mockRepository.Setup(x => x.List()).Returns(expectedUsers);

        var users = _userManager.GetAll();
        Assert.AreSame(expectedUsers, users, "Should return users");

    }

    [TestMethod]
    public void Should_return_one_user()
    {
        string name = "Janitha";
        var expectedUser = new User() { FirstName = "Janitha", LastName = "Tennakoon", Age = 27 };

        var user = _userManager.Get(name);

    }

    [TestMethod]
    public void Should_add_one_user()
    {
        string name = "Janitha";
        var user = new User() { FirstName = "Vindya", LastName = "Hettige", Age = 27 };

       _userManager.Add(user);

    }

    [TestMethod]
    public void Should_Check_Exists(){
        string name = "Shanika";
        bool result = _userManager.Exists(name);
    }





    // [TestMethod]
    // public void IsUserNameNullTest()
    // {
    //     User user = new User();
    //     Assert.IsTrue(_userManager.IsUserNameNull(user), "IsNull should be true when the user name is Null");
    // }

    // [TestMethod]
    // public void TestGetUsers()
    // {
    //     User user = _userManager.Get("Janitha");
    //     Assert.IsFalse(_userManager.IsUserNameNull(user), "A user should be returned from the database");
    // }

    // [TestMethod]
    // public void AddTestUser()
    // {
    //     User user = new User() { FirstName = "Vindya", LastName = "Hettige", Age = 27 };
    //     _userManager.AddUser(user);

    //     User addedUser = _userManager.GetUser("Vindya");
    //     Assert.IsNotNull(addedUser, "Adding users failed");


    // }


}