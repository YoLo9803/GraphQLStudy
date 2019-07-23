using GraphStudy.Models;

namespace GraphStudy.SearchFriendsWebServer.Models
{
    public class FriendInformation
    {
        public Relationship relationship{ get; set; }

        public User FriendModel{ get; set; }
    }
}