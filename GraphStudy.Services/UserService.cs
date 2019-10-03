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
                    id = 1,
                    name = "chris"
                },
                new User{
                    id = 2,
                    name = "Amy"
                },
                new User{
                    id = 3,
                    name = "Leon"
                },
                new User{
                    id = 4,
                    name = "Binson"
                },
                new User{
                    id = 5,
                    name = "Elisa"
                },
                new User{
                    id = 6,
                    name = "Jacky"
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
            User selectedUser = users.SingleOrDefault(context => context.id == id);
            if (selectedUser == null)
            {
                throw new ArgumentException(String.Format("User ID {0} 不存在", id));
            }
            return selectedUser;
        }
    }
}
