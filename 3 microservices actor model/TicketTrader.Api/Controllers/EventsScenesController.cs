using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicketTrader.Api.Core;
using TicketTrader.EventDefinitions.Gateway.Client;

namespace TicketTrader.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Events/{eventId}/Scenes/")]
    public class EventsScenesController : ApiController
    {
        private readonly EventDefinitionsClientProvider _eventDefinitionsClient;

        public EventsScenesController(EventDefinitionsClientProvider eventDefinitionsClient, ILogger<ApiController> logger) : base(logger)
        {
            _eventDefinitionsClient = eventDefinitionsClient;
        }
        
        [HttpGet()]
        [Authorize(Policy = nameof(PolicyDefinitions.ApprovedCustomersOnly))]
        public async Task<ApiResponse<IEnumerable<SceneDetailsDto>>> Get(int eventId)
        {
            return await Respond
                .AsyncWithMany<SceneDetailsDto>(async (response, fail) =>
                {
                    response.Result = await _eventDefinitionsClient.EventDefinitionsClient.ApiEventsScenesGetAsync(eventId);
                });
        }

        [HttpGet("{id}")]
        [Authorize(Policy = nameof(PolicyDefinitions.ApprovedCustomersOnly))]
        public string Get(int eventId, int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize(Policy = nameof(PolicyDefinitions.AdministratorsOnly))]
        public void Post(int eventId, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = nameof(PolicyDefinitions.AdministratorsOnly))]
        public void Put(int eventId, int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = nameof(PolicyDefinitions.AdministratorsOnly))]
        public void Delete(int eventId, int id)
        {
            throw new NotImplementedException();
        }
    }
}

