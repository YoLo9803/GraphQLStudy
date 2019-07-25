using System;
using System.Collections.Generic;
using System.Text;
using GraphStudy.Models;
using System.Linq;

namespace GraphStudy.Services
{
    public class RelationshipService : IRelationshipService
    {
        List<Relationship> relationships;

        public RelationshipService()
        {
            relationships = new List<Relationship>
            {
                #region 關係List
                new Relationship
                {
                    Id = 1,
                    FirstUserId = 1,
                    SecondUserId = 2,
                    CreateDate = new DateTime(2019,3,21)
                },
                new Relationship
                {
                    Id = 2,
                    FirstUserId = 1,
                    SecondUserId = 4,
                    CreateDate = new DateTime(2018,2,6)
                },
                new Relationship
                {
                    Id = 3,
                    FirstUserId = 1,
                    SecondUserId = 5,
                    CreateDate = new DateTime(2019,7,19)
                },
                new Relationship
                {
                    Id = 4,
                    FirstUserId = 1,
                    SecondUserId = 6,
                    CreateDate = new DateTime(2015,6,30)
                },
                new Relationship
                {
                    Id = 5,
                    FirstUserId = 2,
                    SecondUserId = 3,
                    CreateDate = new DateTime(2019,3,21)
                },
                new Relationship
                {
                    Id = 6,
                    FirstUserId = 2,
                    SecondUserId = 4,
                    CreateDate = new DateTime(2018,9,20)
                },
                new Relationship
                {
                    Id = 7,
                    FirstUserId = 3,
                    SecondUserId = 4,
                    CreateDate = new DateTime(2019,5,17)
                }
                #endregion
            };
        }

        /// <summary>
        /// 按照UserId尋找Relationship
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Relationship> GetRelationshipsByUserId(int userId)
        {
            List<Relationship> relationships = 
            this.relationships.Where(context => 
                context.FirstUserId == userId || context.SecondUserId == userId).ToList();
            if (relationships == null)
            {
                throw new ArgumentException(String.Format("無 User Id {0} 之紀錄", userId));
            }
            return relationships;
        }

        public List<int> GetFriendsIdsByUserId(int userId)
        {
            List<Relationship> relationships = this.GetRelationshipsByUserId(userId);
            List<int> friendsIds = new List<int>();
            foreach (Relationship relationship in relationships)
            {
                if (relationship.FirstUserId == userId)
                    friendsIds.Add(relationship.SecondUserId);
                else
                    friendsIds.Add(relationship.FirstUserId);
            }
            if (friendsIds.Count == 0)
                throw new ArgumentNullException("List is null");
            return friendsIds;
        }
    }
}
