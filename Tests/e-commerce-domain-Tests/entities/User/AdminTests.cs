using e_commerce_domain.entities.User;

namespace e_commerce_domain_Tests.entities.User
{
    public class AdminTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string username = "adminuser";
            string email = "adminuser@example.com";
            string password = "adminpassword";

            // Act
            Admin admin = new(username, email, password);

            // Assert
            Assert.Equal(username, admin.GetUserName());
            Assert.Equal(email, admin.GetEmail());
            Assert.Equal(password, admin.GetPassword());
        }

        [Fact]
        public void SetUserName_ShouldThrowArgumentNullException_WhenUserNameIsNullOrEmpty()
        {
            // Arrange
            Admin admin = new("adminuser", "adminuser@example.com", "adminpassword");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => admin.SetUserName(null));
            Assert.Throws<ArgumentNullException>(() => admin.SetUserName(string.Empty));
        }

        [Fact]
        public void SetUserName_ShouldUpdateUserName_WhenUserNameIsValid()
        {
            // Arrange
            Admin admin = new("adminuser", "adminuser@example.com", "adminpassword");
            string newUserName = "newadminuser";

            // Act
            admin.SetUserName(newUserName);

            // Assert
            Assert.Equal(newUserName, admin.GetUserName());
        }

        [Fact]
        public void SetEmail_ShouldThrowArgumentNullException_WhenEmailIsNullOrEmpty()
        {
            // Arrange
            Admin admin = new("adminuser", "adminuser@example.com", "adminpassword");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => admin.SetEmail(null));
            Assert.Throws<ArgumentNullException>(() => admin.SetEmail(string.Empty));
        }

        [Fact]
        public void SetEmail_ShouldThrowInvalidDataException_WhenEmailIsInvalid()
        {
            // Arrange
            Admin admin = new("adminuser", "adminuser@example.com", "adminpassword");

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => admin.SetEmail("invalid-email"));
        }

        [Fact]
        public void SetEmail_ShouldUpdateEmail_WhenEmailIsValid()
        {
            // Arrange
            Admin admin = new("adminuser", "adminuser@example.com", "adminpassword");
            string newEmail = "newadminuser@example.com";

            // Act
            admin.SetEmail(newEmail);

            // Assert
            Assert.Equal(newEmail, admin.GetEmail());
        }

        [Fact]
        public void SetPassword_ShouldThrowArgumentNullException_WhenPasswordIsNullOrEmpty()
        {
            // Arrange
            Admin admin = new("adminuser", "adminuser@example.com", "adminpassword");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => admin.SetPassword(null));
            Assert.Throws<ArgumentNullException>(() => admin.SetPassword(string.Empty));
        }

        [Fact]
        public void SetPassword_ShouldUpdatePassword_WhenPasswordIsValid()
        {
            // Arrange
            Admin admin = new("adminuser", "adminuser@example.com", "adminpassword");
            string newPassword = "newadminpassword";

            // Act
            admin.SetPassword(newPassword);

            // Assert
            Assert.Equal(newPassword, admin.GetPassword());
        }
    }
}

