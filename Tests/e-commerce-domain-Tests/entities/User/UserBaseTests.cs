using e_commerce_domain.entities.User;

namespace e_commerce_domain_Tests.entities.User
{
    public class UserBaseTests
    {
        private class TestUser : UserBase
        {
            public TestUser(string username, string email, string password)
                : base(username, email, password)
            {
            }
        }

        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string username = "testuser";
            string email = "testuser@example.com";
            string password = "password123";

            // Act
            TestUser user = new(username, email, password);

            // Assert
            Assert.Equal(username, user.GetUserName());
            Assert.Equal(email, user.GetEmail());
            Assert.Equal(password, user.GetPassword());
        }

        [Fact]
        public void SetUserName_ShouldThrowArgumentNullException_WhenUserNameIsNullOrEmpty()
        {
            // Arrange
            TestUser user = new("testuser", "testuser@example.com", "password123");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => user.SetUserName(null));
            Assert.Throws<ArgumentNullException>(() => user.SetUserName(string.Empty));
        }

        [Fact]
        public void SetUserName_ShouldUpdateUserName_WhenUserNameIsValid()
        {
            // Arrange
            TestUser user = new("testuser", "testuser@example.com", "password123");
            string newUserName = "newuser";

            // Act
            user.SetUserName(newUserName);

            // Assert
            Assert.Equal(newUserName, user.GetUserName());
        }

        [Fact]
        public void SetEmail_ShouldThrowArgumentNullException_WhenEmailIsNullOrEmpty()
        {
            // Arrange
            TestUser user = new("testuser", "testuser@example.com", "password123");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => user.SetEmail(null));
            Assert.Throws<ArgumentNullException>(() => user.SetEmail(string.Empty));
        }

        [Fact]
        public void SetEmail_ShouldThrowInvalidDataException_WhenEmailIsInvalid()
        {
            // Arrange
            TestUser user = new("testuser", "testuser@example.com", "password123");

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => user.SetEmail("invalid-email"));
        }

        [Fact]
        public void SetEmail_ShouldUpdateEmail_WhenEmailIsValid()
        {
            // Arrange
            TestUser user = new("testuser", "testuser@example.com", "password123");
            string newEmail = "newuser@example.com";

            // Act
            user.SetEmail(newEmail);

            // Assert
            Assert.Equal(newEmail, user.GetEmail());
        }

        [Fact]
        public void SetPassword_ShouldThrowArgumentNullException_WhenPasswordIsNullOrEmpty()
        {
            // Arrange
            TestUser user = new("testuser", "testuser@example.com", "password123");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => user.SetPassword(null));
            Assert.Throws<ArgumentNullException>(() => user.SetPassword(string.Empty));
        }

        [Fact]
        public void SetPassword_ShouldUpdatePassword_WhenPasswordIsValid()
        {
            // Arrange
            TestUser user = new("testuser", "testuser@example.com", "password123");
            string newPassword = "newpassword123";

            // Act
            user.SetPassword(newPassword);

            // Assert
            Assert.Equal(newPassword, user.GetPassword());
        }
    }
}
