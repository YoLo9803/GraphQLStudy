using GraphStudy.Models;

namespace GraphStudy.Services
{
    public interface IUserService
    {
        /// <summary>
        /// 依照編號取得使用者資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int id);
    }
}