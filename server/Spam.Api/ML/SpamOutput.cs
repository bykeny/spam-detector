namespace Spam.Api.ML
{
    public class SpamOutput
    {
        public bool PredictedLabel { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }
}
