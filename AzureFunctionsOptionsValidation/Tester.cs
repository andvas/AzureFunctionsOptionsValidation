using Microsoft.Extensions.Options;

namespace AzureFunctionsOptionsValidation
{
    public class Tester : ITester
    {
        private readonly TesterSettings _testerSettings;

        public Tester(IOptions<TesterSettings> options)
        {
            // Does not throw OptionsValidationException
            _testerSettings = options.Value;
        }

        public int DoThing()
        {
            // Throws because Test is null
            return _testerSettings.Test.Length;
        }
    }
}
