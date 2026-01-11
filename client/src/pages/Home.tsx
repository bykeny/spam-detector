import { useState } from "react";
import SpamForm from "../components/SpamForm";
import ResultCard from "../components/ResultCard";
import { predictSpam } from "../api/spamApi";
import type { SpamResponse } from "../types/spam";
import ConfidenceChart from "../components/ConfidenceChart";

const Home: React.FC = () => {
  const [result, setResult] = useState<SpamResponse | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  const handleAnalyze = async (message: string) => {
    setLoading(true);
    setError("");
    setResult(null);

    try {
      const data = await predictSpam(message);
      setResult(data);
    } catch {
      setError("Failed to connect to API");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container">
      <SpamForm onSubmit={handleAnalyze} loading={loading} />
      {error && <p className="error">{error}</p>}
      {result && (
        <>
          <ResultCard result={result} />
          <ConfidenceChart result={result} />
        </>
      )}
    </div>
  );
};

export default Home;
