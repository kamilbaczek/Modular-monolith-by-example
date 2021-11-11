using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Inquiries.IntegrationsEvents.External;

public record InquiryMadeEvent(
    Guid InquiryId) : IntegrationEvent;
