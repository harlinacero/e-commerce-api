using e_commerce_domain.entities.User;

namespace e_commerce_domain_Tests.entities.User
{
    public class SellerTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            string username = "selleruser";
            string email = "selleruser@example.com";
            string password = "sellerpassword";
            string phone = "555-1234";

            // Act
            Seller seller = new(username, email, password, phone);

            // Assert
            Assert.Equal(username, seller.GetUserName());
            Assert.Equal(email, seller.GetEmail());
            Assert.Equal(password, seller.GetPassword());
            Assert.Equal(phone, seller.GetPhone());
        }

        [Fact]
        public void SetPhone_ShouldUpdatePhone()
        {
            // Arrange
            Seller seller = new("selleruser", "selleruser@example.com", "sellerpassword", "555-1234");
            string newPhone = "555-5678";

            // Act
            seller.SetPhone(newPhone);

            // Assert
            Assert.Equal(newPhone, seller.GetPhone());
        }

        [Fact]
        public void SetScore_ShouldThrowArgumentOutOfRangeException_WhenScoreIsLessThanZero()
        {
            // Arrange
            Seller seller = new("selleruser", "selleruser@example.com", "sellerpassword", "555-1234");

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => seller.SetScore(-1));
        }

        [Fact]
        public void SetScore_ShouldThrowArgumentOutOfRangeException_WhenScoreIsGreaterThanFive()
        {
            // Arrange
            Seller seller = new("selleruser", "selleruser@example.com", "sellerpassword", "555-1234");

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => seller.SetScore(6));
        }

        [Fact]
        public void SetScore_ShouldUpdateScore_WhenScoreIsValid()
        {
            // Arrange
            Seller seller = new("selleruser", "selleruser@example.com", "sellerpassword", "555-1234");
            int newScore = 4;

            // Act
            seller.SetScore(newScore);

            // Assert
            Assert.Equal(newScore, seller.GetScore());
        }
    }
}
