using System;
using System.Collections.Generic;
using System.Text;

namespace GraphStudy.Models
{
    /// <summary>
    /// 使用者
    /// </summary>
    public class User
    {
        /// <summary>
        /// 使用者編號
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 朋友編號List
        /// </summary>
        public List<int> FriendIds { get; set; }
    }
}
