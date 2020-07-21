using System.ComponentModel.DataAnnotations;

namespace AzureFunctionsOptionsValidation
{
    public class TesterSettings
    {
        [Required]
        public string Test { get; set; }
    }
}
