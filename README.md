**Project Overview**
- **Name:**: Spam Detector (React client + .NET ML API)
- **Purpose:**: A simple spam-detection demo using Microsoft.ML on the server and a React + Vite frontend to call the prediction API.

**Repository Structure**
- **client**: React + TypeScript frontend (Vite). See [client/package.json](client/package.json).
- **server/Spam.Api**: ASP.NET Core Web API with ML training and prediction code. See [server/Spam.Api/Program.cs](server/Spam.Api/Program.cs#L1).
- **server/Spam.Api/Data**: CSV dataset used for training: [server/Spam.Api/Data/spam-data.csv](server/Spam.Api/Data/spam-data.csv#L1).

**Quick Prerequisites**
- **Dotnet:** .NET 10 SDK (match target `net10.0`).
- **Node:** Node.js 18+ and `npm` (or `pnpm`/`yarn`) for the client.

**Server (ML API) - Setup & Run**
- **Restore & run**:

```
cd server/Spam.Api
dotnet restore
dotnet run
```

- **What happens on startup:** If the file `ML/spam-model.zip` is missing the server will create the `ML` directory and run a training pass using the CSV at [server/Spam.Api/Data/spam-data.csv](server/Spam.Api/Data/spam-data.csv#L1). Training code: [server/Spam.Api/ML/SpamTrainer.cs](server/Spam.Api/ML/SpamTrainer.cs#L1).
- **Manual retrain:** Remove `ML/spam-model.zip` and restart the server to force retraining, or run the trainer from a short utility that instantiates `SpamTrainer.Train()` (not included here).

**Client (Frontend) - Setup & Run**
- **Install & start**:

```
cd client
npm install
npm run dev
```

- **Notes:** The client calls the API base URL defined in [client/src/api/spamApi.ts](client/src/api/spamApi.ts#L1). By default that file targets `http://localhost:5240/api`. If your server launches on a different port update that file accordingly.

**API - Endpoints**
- **POST** `/api/spam/predict`
  - **Request JSON:** `{ "text": "message to analyze" }`
  - **Response JSON:** `{ "result": "Spam" | "Not Spam", "confidence": float }`
  - Implementation: [server/Spam.Api/Controllers/SpamController.cs](server/Spam.Api/Controllers/SpamController.cs#L1)

**ML Model & Data**
- **Training pipeline:** Text featurization (FeaturizeText) -> SDCA Logistic Regression. See [server/Spam.Api/ML/SpamTrainer.cs](server/Spam.Api/ML/SpamTrainer.cs#L1).
- **Model file:** `ML/spam-model.zip` (generated at runtime if missing).
- **Input/Output types:** [SpamInput.cs](server/Spam.Api/ML/SpamInput.cs#L1) and [SpamOutput.cs](server/Spam.Api/ML/SpamOutput.cs#L1).
- **Dataset:** `server/Spam.Api/Data/spam-data.csv` — small CSV with `Label,Text` columns used for training. Inspect sample rows at [server/Spam.Api/Data/spam-data.csv](server/Spam.Api/Data/spam-data.csv#L1).

**CORS & Local Development**
- The server enables a permissive CORS policy in `Program.cs`, allowing the frontend served by Vite to call the API during development. See [server/Spam.Api/Program.cs](server/Spam.Api/Program.cs#L1).

**Troubleshooting**
- If predictions fail with model-loading errors, confirm `ML/spam-model.zip` exists or let the server retrain by removing it and restarting.
- If client cannot reach the API, check the server URL printed by `dotnet run` and update [client/src/api/spamApi.ts](client/src/api/spamApi.ts#L1).

**Development Notes**
- The frontend uses `axios`, `react`, `chart.js`, and `react-chartjs-2` (see [client/package.json](client/package.json#L1)).
- The server uses `Microsoft.ML` and `Microsoft.ML.FastTree` (see [server/Spam.Api/Spam.Api.csproj](server/Spam.Api/Spam.Api.csproj#L1)).

**Contributing**
- Feel free to open issues or pull requests. Suggested improvements:
  - Add more labeled training data and data-cleaning pipeline.
  - Add unit tests for the ML pipeline and API.
  - Add CI to build both client and server and run lint/tests.

**License**
- No license file included. Add one if you intend to open-source the project.

**Contact / Next Steps**
- Want me to: add CI, generate a small CONTRIBUTING.md, or wire up a Docker/devcontainer? Reply which you prefer and I'll proceed.
