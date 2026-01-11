using Microsoft.ML;

namespace Spam.Api.ML
{
    public class SpamTrainer
    {
        private const string DataPath = "Data/spam-data.csv";
        private const string ModelPath = "ML/spam-model.zip";

        public void Train()
        {
            var mlContext = new MLContext(seed: 42);

            var data = mlContext.Data.LoadFromTextFile<SpamInput>(
                path: DataPath,
                hasHeader: true,
                separatorChar: ',');

            var pipeline =
                mlContext.Transforms.Text.FeaturizeText(
                    outputColumnName: "Features",
                    inputColumnName: nameof(SpamInput.Text))
                .Append(
                    mlContext.BinaryClassification.Trainers
                        .SdcaLogisticRegression());

            var model = pipeline.Fit(data);

            mlContext.Model.Save(model, data.Schema, ModelPath);
        }
    }
}
