namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get.Dtos;

public record InquiryDetailsDto(InquiryInformationDto Information,
    IReadOnlyList<InquiriesServiceItemDto> Services);
