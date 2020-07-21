using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsOptionsValidation
{
    public class OptionsValidation
    {
        private readonly ITester _tester;

        public OptionsValidation(ITester tester)
        {
            _tester = tester;
        }

        [FunctionName(nameof(OptionsValidation))]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            var length = _tester.DoThing();

            return new OkObjectResult(length);
        }
    }
}
