using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.ML.Data;

namespace Spam.Api.ML
{
    public class SpamInput
    {
        [LoadColumn(0)]
        public bool Label { get; set; }
        [LoadColumn(1)]
        public string Text { get; set; } = string.Empty;
    }
}
