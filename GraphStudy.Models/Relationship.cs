using System;
using System.Collections.Generic;
using System.Text;

namespace GraphStudy.Models
{
    public class Relationship
    {
        /// <summary>
        /// PK
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 第一個使用者Id
        /// </summary>
        public int FirstUserId { get; set; }

        /// <summary>
        /// 第二個使用者Id
        /// </summary>
        public int SecondUserId { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate { get; set; }

    }
}
