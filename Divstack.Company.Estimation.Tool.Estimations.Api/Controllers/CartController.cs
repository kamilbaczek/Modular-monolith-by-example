using Divstack.Company.Estimation.Tool.Estimations.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Estimations.Api.Controllers
{
    internal sealed class ValuationsController : BaseController
    {
        private readonly IValuationsModule _valuationsModule;

        public ValuationsController(IValuationsModule valuationsModule)
        {
            _valuationsModule = valuationsModule;
        }
    }
}
