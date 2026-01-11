export interface SpamRequest {
  message: string;
}

export interface SpamResponse {
  isSpam: boolean;
  probability: number;
}
