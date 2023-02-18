FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "/src"]
COPY ["Src/Bootstrapper/Divstack.Company.Estimation.Tool.Bootstrapper/Divstack.Company.Estimation.Tool.Bootstrapper.csproj", "Src/Bootstrapper/Divstack.Company.Estimation.Tool.Bootstrapper/"]
COPY ["Src/Modules/Divstack.Company.Estimation.Tool.Push.Api/Divstack.Company.Estimation.Tool.Push.Api.csproj", "Src/Modules/Divstack.Company.Estimation.Tool.Push.Api/"]
COPY ["Src/Modules/Push/Divstack.Company.Estimation.Tool.Push.DataAccess/Divstack.Company.Estimation.Tool.Push.DataAccess.csproj", "Src/Modules/Push/Divstack.Company.Estimation.Tool.Push.DataAccess/"]
COPY ["Src/Shared/Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks/Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks.csproj", "Src/Shared/Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks/"]
COPY ["Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents/Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.csproj", "Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents/"]
COPY ["Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Domain/Divstack.Company.Estimation.Tool.Valuations.Domain.csproj", "Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Domain/"]
COPY ["Src/Shared/Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects/Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.csproj", "Src/Shared/Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects/"]
COPY ["Src/Modules/Services/Divstack.Company.Estimation.Tool.Services.Core/Divstack.Company.Estimation.Tool.Services.Core.csproj", "Src/Modules/Services/Divstack.Company.Estimation.Tool.Services.Core/"]
COPY ["Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails/Divstack.Company.Estimation.Tool.Emails.csproj", "Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails/"]
COPY ["Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Core/Divstack.Company.Estimation.Tool.Emails.Core.csproj", "Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Core/"]
COPY ["Src/Shared/Abstractions/Divstack.Company.Estimation.Tool.Shared.Abstractions/Divstack.Company.Estimation.Tool.Shared.Abstractions.csproj", "Src/Shared/Abstractions/Divstack.Company.Estimation.Tool.Shared.Abstractions/"]
COPY ["Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Payments/Divstack.Company.Estimation.Tool.Emails.Payments.csproj", "Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Payments/"]
COPY ["Src/Shared/Divstack.Company.Estimation.Tool.Shared.Infrastructure/Divstack.Company.Estimation.Tool.Shared.Infrastructure.csproj", "Src/Shared/Divstack.Company.Estimation.Tool.Shared.Infrastructure/"]
COPY ["Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents/Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.csproj", "Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents/"]
COPY ["Src/Shared/Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure/Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure.csproj", "Src/Shared/Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure/"]
COPY ["Src/Shared/Divstack.Company.Estimation.Tool.Shared.Persistance/Divstack.Company.Estimation.Tool.Shared.Persistance.csproj", "Src/Shared/Divstack.Company.Estimation.Tool.Shared.Persistance/"]
COPY ["Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Application/Divstack.Company.Estimation.Tool.Inquiries.Application.csproj", "Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Application/"]
COPY ["Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Domain/Divstack.Company.Estimation.Tool.Inquiries.Domain.csproj", "Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Domain/"]
COPY ["Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.IntegrationsEvents/Divstack.Company.Estimation.Tool.Payments.IntegrationsEvents.csproj", "Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.IntegrationsEvents/"]
COPY ["Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Priorities/Divstack.Company.Estimation.Tool.Emails.Priorities.csproj", "Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Priorities/"]
COPY ["Src/Modules/Reminders/Divstack.Company.Estimation.Tool.Reminders.Priorities/Divstack.Company.Estimation.Tool.Reminders.Priorities.csproj", "Src/Modules/Reminders/Divstack.Company.Estimation.Tool.Reminders.Priorities/"]
COPY ["Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Domain/Divstack.Company.Estimation.Tool.Priorities.Domain.csproj", "Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Domain/"]
COPY ["Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.IntegrationsEvents/Divstack.Company.Estimation.Tool.Priorities.IntegrationsEvents.csproj", "Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.IntegrationsEvents/"]
COPY ["Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Application/Divstack.Company.Estimation.Tool.Users.Application.csproj", "Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Application/"]
COPY ["Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Domain/Divstack.Company.Estimation.Tool.Users.Domain.csproj", "Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Domain/"]
COPY ["Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Users/Divstack.Company.Estimation.Tool.Emails.Users.csproj", "Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Users/"]
COPY ["Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Valuations/Divstack.Company.Estimation.Tool.Emails.Valuations.csproj", "Src/Modules/Emails/Divstack.Company.Estimation.Tool.Emails.Valuations/"]
COPY ["Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Api/Divstack.Company.Estimation.Tool.Inquiries.Api.csproj", "Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Api/"]
COPY ["Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Infrastructure/Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.csproj", "Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Infrastructure/"]
COPY ["Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Persistance/Divstack.Company.Estimation.Tool.Inquiries.Persistance.csproj", "Src/Modules/Inquiries/Divstack.Company.Estimation.Tool.Inquiries.Persistance/"]
COPY ["Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Api/Divstack.Company.Estimation.Tool.Payments.Api.csproj", "Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Api/"]
COPY ["Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Domain/Divstack.Company.Estimation.Tool.Payments.Domain.csproj", "Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Domain/"]
COPY ["Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Infrastructure/Divstack.Company.Estimation.Tool.Payments.Infrastructure.csproj", "Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Infrastructure/"]
COPY ["Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Application/Divstack.Company.Estimation.Tool.Payments.Application.csproj", "Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Application/"]
COPY ["Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Application/Divstack.Company.Estimation.Tool.Valuations.Application.csproj", "Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Application/"]
COPY ["Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe/Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe.csproj", "Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Infrastructure.PaymentProcessor.Stripe/"]
COPY ["Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Persistance/Divstack.Company.Estimation.Tool.Payments.Persistance.csproj", "Src/Modules/Payments/Divstack.Company.Estimation.Tool.Payments.Persistance/"]
COPY ["Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Api/Divstack.Company.Estimation.Tool.Priorities.Api.csproj", "Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Api/"]
COPY ["Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Infrastructure/Divstack.Company.Estimation.Tool.Priorities.Infrastructure.csproj", "Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Infrastructure/"]
COPY ["Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Application/Divstack.Company.Estimation.Tool.Priorities.Application.csproj", "Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Application/"]
COPY ["Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Persistance/Divstack.Company.Estimation.Tool.Priorities.Persistance.csproj", "Src/Modules/Priorities/Divstack.Company.Estimation.Tool.Priorities.Persistance/"]
COPY ["Src/Modules/Push/Divstack.Company.Estimation.Tool.Push/Divstack.Company.Estimation.Tool.Push.csproj", "Src/Modules/Push/Divstack.Company.Estimation.Tool.Push/"]
COPY ["Src/Modules/Push/Divstack.Company.Estimation.Tool.Push.Payments/Divstack.Company.Estimation.Tool.Push.Payments.csproj", "Src/Modules/Push/Divstack.Company.Estimation.Tool.Push.Payments/"]
COPY ["Src/Modules/Push/Divstack.Company.Estimation.Tool.Push.Valuations/Divstack.Company.Estimation.Tool.Push.Valuations.csproj", "Src/Modules/Push/Divstack.Company.Estimation.Tool.Push.Valuations/"]
COPY ["Src/Modules/Reminders/Divstack.Company.Estimation.Tool.Reminders/Divstack.Company.Estimation.Tool.Reminders.csproj", "Src/Modules/Reminders/Divstack.Company.Estimation.Tool.Reminders/"]
COPY ["Src/Modules/Services/Divstack.Company.Estimation.Tool.Services.Api/Divstack.Company.Estimation.Tool.Services.Api.csproj", "Src/Modules/Services/Divstack.Company.Estimation.Tool.Services.Api/"]
COPY ["Src/Modules/Services/Divstack.Company.Estimation.Tool.Services.DataAccess/Divstack.Company.Estimation.Tool.Services.DataAccess.csproj", "Src/Modules/Services/Divstack.Company.Estimation.Tool.Services.DataAccess/"]
COPY ["Src/Modules/Sms/Divstack.Company.Estimation.Tool.Sms/Divstack.Company.Estimation.Tool.Sms.csproj", "Src/Modules/Sms/Divstack.Company.Estimation.Tool.Sms/"]
COPY ["Src/Modules/Sms/Divstack.Company.Estimation.Tool.Sms.Core/Divstack.Company.Estimation.Tool.Sms.Core.csproj", "Src/Modules/Sms/Divstack.Company.Estimation.Tool.Sms.Core/"]
COPY ["Src/Modules/Sms/Divstack.Company.Estimation.Tool.Sms.Payments/Divstack.Company.Estimation.Tool.Sms.Payments.csproj", "Src/Modules/Sms/Divstack.Company.Estimation.Tool.Sms.Payments/"]
COPY ["Src/Modules/Sms/Divstack.Company.Estimation.Tool.Sms.Valuations/Divstack.Company.Estimation.Tool.Sms.Valuations.csproj", "Src/Modules/Sms/Divstack.Company.Estimation.Tool.Sms.Valuations/"]
COPY ["Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Api/Divstack.Company.Estimation.Tool.Users.Api.csproj", "Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Api/"]
COPY ["Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Infrastructure/Divstack.Company.Estimation.Tool.Users.Infrastructure.csproj", "Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Infrastructure/"]
COPY ["Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Persistance/Divstack.Company.Estimation.Tool.Users.Persistance.csproj", "Src/Modules/Users/Divstack.Company.Estimation.Tool.Users.Persistance/"]
COPY ["Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Api/Divstack.Company.Estimation.Tool.Valuations.Api.csproj", "Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Api/"]
COPY ["Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Infrastructure/Divstack.Company.Estimation.Tool.Valuations.Infrastructure.csproj", "Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Infrastructure/"]
COPY ["Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov/Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.csproj", "Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov/"]
COPY ["Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello/Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello.csproj", "Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Trello/"]
COPY ["Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Persistance/Divstack.Company.Estimation.Tool.Valuations.Persistance.csproj", "Src/Modules/Valuations/Divstack.Company.Estimation.Tool.Valuations.Persistance/"]
RUN dotnet restore "Src/Bootstrapper/Divstack.Company.Estimation.Tool.Bootstrapper/Divstack.Company.Estimation.Tool.Bootstrapper.csproj"
COPY . .
WORKDIR "/src/Src/Bootstrapper/Divstack.Company.Estimation.Tool.Bootstrapper"
RUN dotnet build "Divstack.Company.Estimation.Tool.Bootstrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Divstack.Company.Estimation.Tool.Bootstrapper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Divstack.Company.Estimation.Tool.Bootstrapper.dll"]