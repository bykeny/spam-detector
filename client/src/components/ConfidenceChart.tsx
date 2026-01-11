import { Doughnut } from "react-chartjs-2";
import type { SpamResponse } from "../types/spam";

interface ConfidenceChartProps {
  result: SpamResponse;
}

const ConfidenceChart: React.FC<ConfidenceChartProps> = ({ result }) => {
  const spamConfidence = result.probability;
  const hamConfidence = 1 - spamConfidence;

  const data = {
    labels: ["Spam", "Not Spam"],
    datasets: [
      {
        data: [spamConfidence, hamConfidence],
        backgroundColor: ["#dc2626", "#16a34a"],
        borderWidth: 0
      }
    ]
  };

  const options = {
    plugins: {
      legend: {
        position: "bottom" as const
      }
    },
    cutout: "70%"
  };

  return (
    <div className="card">
      <h3>Prediction Confidence</h3>
      <Doughnut data={data} options={options} />
    </div>
  );
};

export default ConfidenceChart;
