using e_commerce_domain.entities.User;

namespace e_commerce_domain_Tests.entities.User
{
    public class CustomerTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string username = "customeruser";
            string email = "customeruser@example.com";
            string password = "customerpassword";
            string firstName = "John";
            string lastName = "Doe";
            string address = "123 Main St";

            // Act
            Customer customer = new(username, email, password, firstName, lastName, address);

            // Assert
            Assert.Equal(username, customer.GetUserName());
            Assert.Equal(email, customer.GetEmail());
            Assert.Equal(password, customer.GetPassword());
            Assert.Equal(firstName, customer.GetFirstName());
            Assert.Equal(lastName, customer.GetLastName());
            Assert.Equal(address, customer.GetAddress());
        }

        [Fact]
        public void SetFirstName_ShouldThrowArgumentNullException_WhenFirstNameIsNullOrEmpty()
        {
            // Arrange
            Customer customer = new("customeruser", "customeruser@example.com", "customerpassword", "John", "Doe", "123 Main St");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => customer.SetFirstName(null));
            Assert.Throws<ArgumentNullException>(() => customer.SetFirstName(string.Empty));
        }

        [Fact]
        public void SetFirstName_ShouldUpdateFirstName_WhenFirstNameIsValid()
        {
            // Arrange
            Customer customer = new("customeruser", "customeruser@example.com", "customerpassword", "John", "Doe", "123 Main St");
            string newFirstName = "Jane";

            // Act
            customer.SetFirstName(newFirstName);

            // Assert
            Assert.Equal(newFirstName, customer.GetFirstName());
        }

        [Fact]
        public void SetLastName_ShouldThrowArgumentNullException_WhenLastNameIsNullOrEmpty()
        {
            // Arrange
            Customer customer = new("customeruser", "customeruser@example.com", "customerpassword", "John", "Doe", "123 Main St");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => customer.SetLastName(null));
            Assert.Throws<ArgumentNullException>(() => customer.SetLastName(string.Empty));
        }

        [Fact]
        public void SetLastName_ShouldUpdateLastName_WhenLastNameIsValid()
        {
            // Arrange
            Customer customer = new("customeruser", "customeruser@example.com", "customerpassword", "John", "Doe", "123 Main St");
            string newLastName = "Smith";

            // Act
            customer.SetLastName(newLastName);

            // Assert
            Assert.Equal(newLastName, customer.GetLastName());
        }

        [Fact]
        public void SetAddress_ShouldThrowArgumentNullException_WhenAddressIsNullOrEmpty()
        {
            // Arrange
            Customer customer = new("customeruser", "customeruser@example.com", "customerpassword", "John", "Doe", "123 Main St");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => customer.SetAddress(null));
            Assert.Throws<ArgumentNullException>(() => customer.SetAddress(string.Empty));
        }

        [Fact]
        public void SetAddress_ShouldUpdateAddress_WhenAddressIsValid()
        {
            // Arrange
            Customer customer = new("customeruser", "customeruser@example.com", "customerpassword", "John", "Doe", "123 Main St");
            string newAddress = "456 Elm St";

            // Act
            customer.SetAddress(newAddress);

            // Assert
            Assert.Equal(newAddress, customer.GetAddress());
        }

        [Fact]
        public void SetPhone_ShouldThrowArgumentNullException_WhenPhoneIsNullOrEmpty()
        {
            // Arrange
            Customer customer = new("customeruser", "customeruser@example.com", "customerpassword", "John", "Doe", "123 Main St");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => customer.SetPhone(null));
            Assert.Throws<ArgumentNullException>(() => customer.SetPhone(string.Empty));
        }

        [Fact]
        public void SetPhone_ShouldUpdatePhone_WhenPhoneIsValid()
        {
            // Arrange
            Customer customer = new("customeruser", "customeruser@example.com", "customerpassword", "John", "Doe", "123 Main St");
            string newPhone = "555-1234";

            // Act
            customer.SetPhone(newPhone);

            // Assert
            Assert.Equal(newPhone, customer.GetPhone());
        }
    }
}


