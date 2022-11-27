using Microsoft.AspNetCore.Mvc.Testing;
using S3E1.Commands;
using FluentAssertions;
using S3E1.Entities;
using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;
using S3E1.Data;

namespace IntegrationTest.TestControllers
{
    public class TestCheckoutController : IntegrationTestBaseClass
    {
        [Fact]
        public async Task Test_Checkout_Controller()
        {
            //----- POST ORDER/CHECKOUT -----
            // Arrange
            var url = "/api/checkout";
            var userUrl = "/api/users";
            var itemUrl = "/api/cart-items";

            // User
            var userResponse = await _httpClient.GetAsync(userUrl);
            var user = await userResponse.Content.ReadFromJsonAsync<UserEntity>();

            // Items
            var itemResponse = await _httpClient.GetAsync(itemUrl);
            var item = await userResponse.Content.ReadFromJsonAsync<CartItemEntity>();


            var order = new OrderEntity
            {
                OrderID = Guid.NewGuid(),
                OrderTotalPrice = 10.5,
                UserOrderId = user.UserID,
                OrderCreatedDate = DateTime.Now,
                CartItemEntity = new List<CartItemEntity>
                {
                    item
                }
            };

            // Act
            var orderResponse = await _httpClient.PostAsJsonAsync(url, order);

            // Assert
            orderResponse.EnsureSuccessStatusCode();
            var newOrder = await orderResponse.Content.ReadFromJsonAsync<OrderEntity>();
            newOrder.Should().BeOfType<OrderEntity>();
        }
    }
}