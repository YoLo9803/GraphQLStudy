# GraphStudy

### For comparing the performence of RESTful & GraphQL

There are 4 web servers have to run:

* GraphStudy.Api.GraphQLServer
* GraphStudy.Api.RelationshipRESTful
* GraphStudy.Api.UserRESTful
* GraphStudy.SearchFriendsWebServer
---

You can run these web server via the two ways below:  

1. Run execute.ps1 at the root folder with powerShell.  
2. Open cmd, cd to each folder above, and type .Net Core SDK 2.2 command *dotnet run* to run these servers.
---

After run the servers above, The SearchFriendsWebServer exposes one endpoint:  
* http://localhost:8082/user/UserAndHisFriends{userId}

And the GraphQLServer exposes one endpoint:  
* http://localhost:8083/graphql  

  You can use the UI middleware *GraphiQL* to explore the graphQL schema, Link below:  
  * http://localhost:8083/graphiql
