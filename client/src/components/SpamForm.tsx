import { useState, type FormEvent } from "react";

interface SpamFormProps {
  onSubmit: (message: string) => void;
  loading: boolean;
}

const SpamForm: React.FC<SpamFormProps> = ({ onSubmit, loading }) => {
  const [message, setMessage] = useState<string>("");

  const handleSubmit = (e: FormEvent) => {
    e.preventDefault();
    if (!message.trim()) return;
    onSubmit(message);
  };

  return (
    <form onSubmit={handleSubmit} className="card">
      <h2>Spam Detector</h2>

      <textarea
        rows={5}
        placeholder="Enter message to analyze..."
        value={message}
        onChange={(e) => setMessage(e.target.value)}
      />

      <button type="submit" disabled={loading}>
        {loading ? "Analyzing..." : "Check Message"}
      </button>
    </form>
  );
};

export default SpamForm;
