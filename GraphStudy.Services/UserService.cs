using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphStudy.Models;

namespace GraphStudy.Services
{
    /// <summary>
    /// 使用者Service
    /// </summary>
    public class UserService : IUserService
    {
        private List<User> users;

        public UserService()
        {
            users = new List<User> {
                new User{
                    Id = 1,
                    Name = "chris"
                },
                new User{
                    Id = 2,
                    Name = "Amy"
                },
                new User{
                    Id = 3,
                    Name = "Leon"
                },
                new User{
                    Id = 4,
                    Name = "Binson"
                },
                new User{
                    Id = 5,
                    Name = "Elisa"
                },
                new User{
                    Id = 6,
                    Name = "Jacky"
                }
            };
        }

        public UserService(List<User> users)
        {
            this.users = users;
        }

        /// <summary>
        /// 按照ID取得使用者
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            User selectedUser = users.SingleOrDefault(context => context.Id == id);
            if (selectedUser == null)
            {
                throw new ArgumentException(String.Format("User ID {0} 不存在", id));
            }
            return selectedUser;
        }
    }
}
