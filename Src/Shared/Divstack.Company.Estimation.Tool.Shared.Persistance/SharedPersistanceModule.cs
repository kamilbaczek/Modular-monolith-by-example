using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Shared.Infrastructure")]

namespace Divstack.Company.Estimation.Tool.Shared.Persistance;

using Microsoft.AspNetCore.Builder;
using Mongo;

internal static class SharedPersistanceModule
{
    public static void UseSharedPersistance(this IApplicationBuilder app) => app.UseMongo();
}
