﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;
using Divstack.Company.Estimation.Tool.Valuations.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Equeries;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request
{
    internal sealed class RequestValuationCommandHandler : IRequestHandler<RequestValuationCommand>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IDeadlinesConfiguration _deadlinesConfiguration;
        private readonly IServiceExistingChecker _serviceExistingChecker;
        private readonly IValuationsRepository _valuationsRepository;

        public RequestValuationCommandHandler(IValuationsRepository valuationsRepository,
            IServiceExistingChecker serviceExistingChecker,
            IEventPublisher eventPublisher,
            IDeadlinesConfiguration deadlinesConfiguration)
        {
            _valuationsRepository = valuationsRepository;
            _serviceExistingChecker = serviceExistingChecker;
            _eventPublisher = eventPublisher;
            _deadlinesConfiguration = deadlinesConfiguration;
        }

        public async Task<Unit> Handle(RequestValuationCommand requestValuation, CancellationToken cancellationToken)
        {
            var email = Email.Of(requestValuation.Email);
            var client = Client.Of(email, requestValuation.FirstName, requestValuation.LastName);
            var serviceIds = requestValuation.ServicesIds
                .Select(id => new ServiceId(id))
                .ToList();

            var deadline = Deadline.Create(_deadlinesConfiguration);
            var valuation = await Valuation.RequestAsync(serviceIds, client, deadline, _serviceExistingChecker);
            await _valuationsRepository.AddAsync(valuation, cancellationToken);
            await _valuationsRepository.CommitAsync(cancellationToken);
            _eventPublisher.Publish(valuation.DomainEvents);

            return Unit.Value;
        }
    }
}
