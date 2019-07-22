using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using GraphStudy.Services;
using GraphStudy.Models;

namespace GraphStudy.Api.RelationshipRESTful.Controllers
{
    [ApiController]
    public class RelationshipController : ControllerBase
    {
        IRelationshipService relationshipService;

        public RelationshipController(IRelationshipService relationshipService)
        {
            //DI
            this.relationshipService = relationshipService;
        }

        [HttpGet]
        [Route("api/[Controller]/{userId}")]
        public IEnumerable<Relationship> GetRelationshipByUserId(int userId)
        {
            return relationshipService.GetRelationshipsByUserId(userId);
        }
}
}