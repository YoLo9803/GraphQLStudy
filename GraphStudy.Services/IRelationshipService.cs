using System;
using System.Collections.Generic;
using System.Text;
using GraphStudy.Models;
using System.Linq;

namespace GraphStudy.Services
{
    public interface IRelationshipService
    {
        //按照UserId取得關係
        IEnumerable<Relationship> GetRelationshipsByUserId(int userId);
    }
}