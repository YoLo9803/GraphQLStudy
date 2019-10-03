using Xunit;
using System;
using GraphStudy.Models;
using System.Collections.Generic;

namespace GraphStudy.Services.Tests
{
    public class UserServiceTests
    {
        /// <summary>
        /// Get user by id success.
        /// </summary>
        [Fact]
        public void GetUserByIdTest()
        {
            //Arrange
            List<User> usersData = new List<User>
            {
                new User
                {
                    id = 1,
                    name = "chris"
                },
                new User
                {
                    id = 2,
                    name = "jackey"
                }
            };
            UserService userService = new UserService(usersData);
            const int CHRIS_USERID = 1;
            //Act
            User chris = userService.GetUserById(CHRIS_USERID);
            //Assert
            Assert.Equal(chris.id, 1);
            Assert.Equal(chris.name, "chris");
        }

        /// <summary>
        /// Get user by id failed and throw exception.
        /// </summary>
        [Fact]
        public void GetUserByIdFail()
        { 
            //Arrange
            List<User> usersData = new List<User>
            {
                new User
                {
                    id = 1,
                    name = "chris"
                },
                new User
                {
                    id = 2,
                    name = "jackey"
                }
            };
            UserService userService = new UserService(usersData);
            const int INVALID_USERID = 3;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => userService.GetUserById(INVALID_USERID));
        }

        /// <summary>
        /// test UserService contructor.
        /// </summary>
        [Fact]
        public void DefaultUserConstuctorTest()
        {
            //Arrange
            UserService userService = new UserService();

            //Act
            User chris = userService.GetUserById(1);

            //Assert
            Assert.Equal(1, chris.id);
            Assert.Equal("chris", chris.name);
        }
    }
}