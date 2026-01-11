using Microsoft.AspNetCore.Mvc;
using Spam.Api.ML;

namespace Spam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpamController : ControllerBase
    {
        private readonly SpamPredictionService _predictionService;

        public SpamController(SpamPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        public record SpamRequest(string Text);
        public record SpamResponse(string Result, float Confidence);

        [HttpPost("predict")]
        public ActionResult<SpamResponse> Predict([FromBody] SpamRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Text))
                return BadRequest("Text is required.");

            var prediction = _predictionService.Predict(request.Text);

            var result = prediction.PredictedLabel ? "Spam" : "Not Spam";

            return Ok(new SpamResponse(
                result,
                prediction.Probability
            ));
        }
    }
}
