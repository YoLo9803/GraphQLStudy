# GraphStudy

### For comparing the performence of RESTful & GraphQL

Requirement:  
* Windows/Linux/MacOS
* .Net Core SDK 2.2

There are 4 web servers have to run:

* GraphStudy.Api.GraphQLServer
* GraphStudy.Api.RelationshipRESTful
* GraphStudy.Api.UserRESTful
* GraphStudy.SearchFriendsWebServer
---

You can run these web server via the two ways below:  

1. Run execute.ps1 at the root folder with powerShell (Windows only).
2. Open multiple cmd (terminal), cd to each folder above, and type .Net Core SDK 2.2 command *dotnet run* to run these servers.
---

After run the servers above, The SearchFriendsWebServer exposes one endpoint:  
* http://localhost:8082/user/UserAndHisFriends?userId={id}
  * Id is a number between 1 to 6.
  * Ex. http://localhost:8082/user/UserAndHisFriends?userId=2

And the GraphQLServer exposes one endpoint:  
* http://localhost:8083/graphql  

You can use the UI middleware *GraphiQL* to explore the graphQL schema, Link below:  
  * http://localhost:8083/graphiql  
  
  Example:  
  ![](https://upload.cc/i1/2019/08/01/08FyP4.png)
