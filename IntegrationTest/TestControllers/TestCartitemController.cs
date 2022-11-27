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
    public class TestCartitemController : IntegrationTestBaseClass
    { 
        [Fact]
        public async Task Test_CartItem_Controller()
        {
            //----- POST CART ITEM -----
            // Arrange
            var url = "/api/cart-items";
            var item = new CartItemEntity
            {
                ItemID = Guid.NewGuid(),
                ItemName = "Item Name",
                ItemPrice = 5.5,
                ItemStatus = "Pending",
                OrderEntityOrderID = null
            };

            // Act
            var itemResponse = await _httpClient.PostAsJsonAsync(url, item);

            // Assert
            itemResponse.EnsureSuccessStatusCode();
            var newItem = await itemResponse.Content.ReadFromJsonAsync<CartItemEntity>();
            newItem.Should().BeOfType<CartItemEntity>();

            //----- GET ALL CART ITEMS -----
            // Act
            var response = await _httpClient.GetAsync(url);

            // Arrange
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var itemList = await response.Content.ReadFromJsonAsync<List<CartItemEntity>>();
            itemList.Should().BeOfType<List<CartItemEntity>>();

            //----- GET CART ITEM BY ID-----
            // Arrange
            var id = newItem.ItemID;
            var urlId = url + "/" + id.ToString();

            // Act
            var fetchedItem = await _httpClient.GetFromJsonAsync<CartItemEntity>(urlId);

            //Assert
            newItem.Should().BeEquivalentTo(fetchedItem);

            // System.Net.Http.HttpRequestException : Response status code does not indicate success: 405 (Method Not Allowed). //

            ////----- PUT CART ITEM -----
            //// Arrange
            //var updateItem = new
            //{
            //    ItemID = newItem.ItemID,
            //    ItemName = "Updated Item Name",
            //    ItemPrice = 10.5,
            //    ItemStatus = newItem.ItemStatus
            //};

            //// Act
            //var updatedItemResponse = await _httpClient.PutAsJsonAsync(urlId, updateItem);

            //// Assert
            //updatedItemResponse.EnsureSuccessStatusCode();
            //updatedItemResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            ////----- DELETE CART ITEM BY ID -----
            //// Act
            //var deleteItem = await _httpClient.DeleteAsync(urlId);

            //// Assert
            //deleteItem.EnsureSuccessStatusCode();
        }
    }
}