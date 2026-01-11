import type { SpamResponse } from "../types/spam";

interface ResultCardProps {
  result: SpamResponse | null;
}

const ResultCard: React.FC<ResultCardProps> = ({ result }) => {
  if (!result) return null;

  const { isSpam, probability } = result;

  return (
    <div className={`card result ${isSpam ? "spam" : "ham"}`}>
      <h3>Result</h3>

      <p>
        <strong>Status:</strong>{" "}
        {isSpam ? "🚨 Spam" : "✅ Not Spam"}
      </p>

      <p>
        <strong>Confidence:</strong>{" "}
        {(probability * 100).toFixed(2)}%
      </p>
    </div>
  );
};

export default ResultCard;
