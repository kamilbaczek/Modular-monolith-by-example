namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Common.Interfaces;

internal interface IMapper<in TDto, out TEntity>
{
    TEntity Map(TDto source);
}
