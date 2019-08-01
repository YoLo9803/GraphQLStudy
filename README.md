# GraphStudy

### For helping you to setup a graphql-dotnet server

Requirement:  
* Windows/Linux/MacOS  
* .Net Core SDK 2.2  

You can use .Net Core SDK 2.2, open cmd (terminal) , and type command *dotnet run* to run the server.

* GraphStudy.Api.GraphQLServer  
---

After run the server above, it exposes one endpoint:  
* http://localhost:8083/graphql  
  Query GET request sample:  
  
  * Ex. http://localhost:8083/graphql?query={user(id:2){id,name,friends{id,name}}}

You can use the UI middleware *GraphiQL* to explore the graphQL schema, Link below:  
* http://localhost:8083/graphiql
  
Example:  
![](https://upload.cc/i1/2019/08/01/08FyP4.png)
