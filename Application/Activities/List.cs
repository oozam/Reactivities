namespace Application.Activities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    using Domain;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Persistence;

    public class List
    {
        public class Query : IRequest<List<Activity>>
        {
        }
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly ReactivitiesDbContext context;

            public Handler(ReactivitiesDbContext context)
            {
                this.context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activites = await this.context.Activities.ToListAsync(cancellationToken);

                return activites;
            }
        }
    }
}
