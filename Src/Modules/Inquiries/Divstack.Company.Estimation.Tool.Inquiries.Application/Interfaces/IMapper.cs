namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Interfaces
{
    internal interface IMapper<in TDto, out TEntity>
    {
        TEntity Map(TDto source);
    }
}