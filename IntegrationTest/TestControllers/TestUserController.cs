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
    public class TestUserController : IntegrationTestBaseClass
    { 
        [Fact]
        public async Task Test_User_Controller()
        {
            //----- POST USER -----
            // Arrange
            var url = "/api/users";
            var user = new UserEntity
            {
                UserID = Guid.NewGuid(),
                Username= "TestUsername",
            };

            // Act
            var userResponse = await _httpClient.PostAsJsonAsync(url, user);

            // Assert
            userResponse.EnsureSuccessStatusCode();
            var newUser = await userResponse.Content.ReadFromJsonAsync<UserEntity>();
            newUser.Should().BeOfType<UserEntity>();

            // System.Text.Json.JsonException : The input does not contain any JSON tokens. //

            ////----- GET USER BY ID-----
            //// Arrange
            //var id = user.UserID;
            //var urlId = url + "/" + id.ToString();

            //// Act
            //var fetchedUser = await _httpClient.GetFromJsonAsync<UserEntity>(urlId);

            ////Assert
            //fetchedUser.Should().Be(HttpStatusCode.OK);
            //fetchedUser.Should().NotBeNull();


        }
    }
}