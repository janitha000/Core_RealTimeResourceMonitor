using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UserManagerTests
{
    private UsersManager _userManager;


    public UserManagerTests()
    {
        _userManager = new UsersManager();
    }

    [TestMethod]
    public void IsUserNameNullTest()
    {
        User user = new User();
        Assert.IsTrue(_userManager.IsUserNameNull(user), "IsNull should be true when the user name is Null");
    }


}