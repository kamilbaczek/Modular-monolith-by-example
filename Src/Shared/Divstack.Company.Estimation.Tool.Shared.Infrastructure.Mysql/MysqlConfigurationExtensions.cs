using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Mysql
{
    public static class MysqlConfigurationExtensions
    {
        public static PropertyBuilder<TProperty> IsIdentity<TProperty>(
            this PropertyBuilder<TProperty> propertyBuilder)
        {
            return propertyBuilder.HasColumnType("char(36)");
        }
    }
}