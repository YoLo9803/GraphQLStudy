using Xunit;
using System;
using GraphStudy.Models;
using System.Collections.Generic;

namespace GraphStudy.Services.Tests
{
    public class RelationshipServiceTests
    {
        /// <summary>
        /// Get relationship by id success.
        /// </summary>
        [Fact]
        public void GetRelationshipsByUserIdTest()
        {
            //Arrange
            List<Relationship> relationships = new List<Relationship>()
            {
                new Relationship()
                {
                    Id = 1,
                    FirstUserId = 1,
                    SecondUserId = 2
                }
            };
            RelationshipService relationshipService = new RelationshipService(relationships);
            //Act
            List<Relationship> result = relationshipService.GetRelationshipsByUserId(1);

            //Assert
            Assert.Equal(1, result.Count);
            Assert.Equal(1, result[0].Id);

        }
        /// <summary>
        /// Get Relationship by id failed and throw exception.
        /// </summary>

        [Fact]
        public void GetRelationshipsByUserIdFailTest()
        {
            //Arrange
            List<Relationship> relationships = new List<Relationship>()
            {
                new Relationship()
                {
                    Id = 1,
                    FirstUserId = 1,
                    SecondUserId = 2,
                }
            };
            RelationshipService relationshipService = new RelationshipService(relationships);
            const int INVALID_USERID = 3;

            //Act & Assert
            Assert.Throws<KeyNotFoundException>(() => relationshipService.GetRelationshipsByUserId(INVALID_USERID));

        }

        /// <summary>
        /// Get friends by id success
        /// </summary>
        [Fact]
        public void GetFriendsIdsByUserIdTest()
        { 
            //Arrange
            List<Relationship> relationships = new List<Relationship>()
            {
                new Relationship()
                {
                    Id = 1,
                    FirstUserId = 1,
                    SecondUserId = 2,
                },
                new Relationship()
                {
                    Id = 2,
                    FirstUserId = 2,
                    SecondUserId = 3,
                }
            };
            RelationshipService relationshipService = new RelationshipService(relationships);

            //Act
            List<int> friendsIds = relationshipService.GetFriendsIdsByUserId(1);

            //Assert
            Assert.Equal(1, friendsIds.Count);
            Assert.Equal(2, friendsIds[0]);
        }
    }
}