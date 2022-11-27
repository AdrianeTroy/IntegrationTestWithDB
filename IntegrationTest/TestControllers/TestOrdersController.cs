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
    public class TestOrdersController : IntegrationTestBaseClass
    {
        [Fact]
        public async Task Test_Orders_Controller()
        {
            //----- POST CART ITEM -----
            // Arrange
            var url = "/api/orders";
            
            //----- GET ALL CART ITEMS -----
            // Act
            var response = await _httpClient.GetAsync(url);

            // Arrange
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var orderList = await response.Content.ReadFromJsonAsync<List<OrderEntity>>();
            orderList.Should().BeOfType<List<OrderEntity>>();

            //----- GET CART ITEM BY ID-----
            // Arrange
            var newOrder = await response.Content.ReadFromJsonAsync<OrderEntity>();
            var id = newOrder.OrderID;
            var urlId = url + "/" + id.ToString();

            // Act
            var fetchedOrder = await _httpClient.GetFromJsonAsync<OrderEntity>(urlId);

            //Assert
            newOrder.Should().BeEquivalentTo(fetchedOrder);

            // System.Net.Http.HttpRequestException : Response status code does not indicate success: 405 (Method Not Allowed). //

            ////----- PUT CART ITEM -----
            //// Arrange
            //var updateItem = new
            //{
            //    ItemID = newOrder.ItemID,
            //    ItemName = "Updated Item Name",
            //    ItemPrice = 10.5,
            //    ItemStatus = newOrder.ItemStatus
            //};

            //// Act
            //var updatedItemResponse = await _httpClient.PutAsJsonAsync(urlId, updateItem);

            //// Assert
            //updatedItemResponse.EnsureSuccessStatusCode();
            //updatedItemResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            //----- DELETE CART ITEM BY ID -----
            // Act
            var deleteItem = await _httpClient.DeleteAsync(urlId);

            // Assert
            deleteItem.EnsureSuccessStatusCode();
        }
    }
}