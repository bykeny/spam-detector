using Microsoft.ML;

namespace Spam.Api.ML
{
    public class SpamPredictionService
    {
        private readonly PredictionEngine<SpamInput, SpamOutput> _engine;

        public SpamPredictionService()
        {
            var mlContext = new MLContext();
            var model = mlContext.Model.Load("ML/spam-model.zip", out _);
            _engine = mlContext.Model
                .CreatePredictionEngine<SpamInput, SpamOutput>(model);
        }

        public SpamOutput Predict(string text)
        {
            return _engine.Predict(new SpamInput
            {
                Text = text
            });
        }
    }
}
