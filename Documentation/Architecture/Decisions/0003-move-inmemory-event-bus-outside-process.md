# 3. Move event bus to Azure Service Bus outside process using NServiceBus.

Date: 2022-06-15

## Status

Accepted

## Context

InMemory event bus using MediatR in Modular Monolith Architecture.
Not worked as expected when comes to long business process flow. 
There is issue with not delivered messages (inbox/outbox pattern will solve the problem). 
Other important driver is that we would like to have integrations with others systems that why import for us is to have event bus outside process.
Next thing is that we would like to have more control over events using Azure Service Bus. We wouldn't like to write own azure service bus adapter beacuse of a time.
We would like to use something battle-tested.

We have tested as PoC few dedicated nuget packages.

MassTransit worked as expected. Issue was in implementation, because required handlers as public class. 
If we will expose handler we have expose all of the other dependencies. This will break our hermetization. 
This nuget is fine for microservices where we have separation by solutions and we don't have to based on internal class access. 
Thy we we drop this idea.

CAP it was hard to abstract this nuget packages because requires attributes as marker for handler methods. That was limitiation for us.

NServiceBus fulfills our needs in terms of hermetization (internal handlers are possible) and message handling
## Decision

We will change inmemory service bus to Azure Service Bus using NServiceBus ready to use nuget package.

## Consequences

We have to maintain more infrastructure. 
Implement health checks, service bus, handle the risk when service bus will be down beacuse of the network.
We have to rewrite ours event handlers.