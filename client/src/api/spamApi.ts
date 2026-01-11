import axios from "axios";
import type { SpamResponse } from "../types/spam";

const api = axios.create({
  baseURL: "http://localhost:5240/api",
  headers: {
    "Content-Type": "application/json"
  }
});

export const predictSpam = async (
  message: string
): Promise<SpamResponse> => {
  // Server expects { text: string } (camel-cased JSON from C# record `SpamRequest(Text)`)
  const payload = { text: message };

  const response = await api.post(
    "/spam/predict",
    payload
  );

  // Server responds with { result: string, confidence: number }
  const server = response.data as { result: string; confidence: number };

  return {
    isSpam: server.result === "Spam",
    probability: server.confidence
  };
};
