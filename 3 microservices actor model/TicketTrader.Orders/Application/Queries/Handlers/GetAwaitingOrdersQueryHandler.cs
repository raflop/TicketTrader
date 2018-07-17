﻿using System.Linq;
using System.Threading.Tasks;
using TicketTrader.Orders.Canonical.Queries;
using TicketTrader.Orders.Domain;
using TicketTrader.Orders.Domain.Queries;
using TicketTrader.Orders.Domain.Queries.ReadModels;
using TicketTrader.Shared.Base.CQRS.Commands;

namespace TicketTrader.Orders.Application.Queries.Handlers
{
    class GetAwaitingOrdersQueryHandler : IQueryHandler<GetAwaitingOrdersQuery, GetAwaitingOrdersQuery.Response>
    {
        private readonly DomainActorSystem _domainActorSystem;

        public GetAwaitingOrdersQueryHandler(DomainActorSystem domainActorSystem)
        {
            _domainActorSystem = domainActorSystem;
        }

        public async Task<GetAwaitingOrdersQuery.Response> Handle(GetAwaitingOrdersQuery query)
        {
            var response = await _domainActorSystem.Query<RespondAwaitingOrders>(new GetAwaitingOrders());
            return new GetAwaitingOrdersQuery.Response
            {
                Orders = response.Orders.Select(x => new GetAwaitingOrdersQuery.Order
                {
                    Id = x.Id
                }).ToList()
            };
        }
    }
}