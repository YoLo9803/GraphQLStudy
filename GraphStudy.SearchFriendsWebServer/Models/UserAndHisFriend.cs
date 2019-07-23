using GraphStudy.Models;
using System.Collections.Generic;

namespace GraphStudy.SearchFriendsWebServer.Models
{
    public class UserAndHisFriend
    {
        public User user{ get; set; }

        public List<FriendInformation> friends{ get; set; }
    }

}