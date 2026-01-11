# Spam Detector – ML.NET Fullstack Project

A **clean, recruiter-friendly full‑stack project** demonstrating how to integrate **ML.NET** into a real-world application using **ASP.NET Core Web API (.NET 10)** and **React + TypeScript**.

This project focuses on **practical machine learning in .NET**, not theory.

---

## 🔍 What This Project Does

* Accepts a text message
* Predicts whether it is **Spam** or **Not Spam**
* Returns a **confidence score**
* Displays the result visually in a modern frontend

---

## 🛠 Tech Stack

### Backend

* ASP.NET Core Web API (.NET 10)
* ML.NET
* Scalar / OpenAPI

### Frontend

* React
* TypeScript
* Axios
* Recharts (confidence visualization)

---

## 📁 High-Level Structure

```
server/
 ├── Spam.Api              # REST API + ML inference

client/                    # React + TypeScript UI
```

---

## 🧠 Machine Learning Overview

* **Problem type:** Binary text classification
* **Model:** Logistic Regression (ML.NET)
* **Input:** Text message
* **Output:** Spam / Not Spam + confidence

The model is trained once and loaded by the API at startup for fast predictions.

---

## 🚀 How to Run

### 1️⃣ Run the API

```bash
cd server/Spam.Api
dotnet run
```

Scalar available at:

```
http://localhost:5240/scalar/v1
```

### 3️⃣ Run the Frontend

```bash
cd client
npm install
npm run dev
```

---

## 📡 API Example

**Request**

```json
{ "message": "Win a free iPhone now!" }
```

**Response**

```json
{ "isSpam": true, "confidence": 0.91 }
```

---

## 📊 Frontend Features

* Message input
* Spam / Not Spam result
* Confidence percentage
* Confidence bar chart

---

## 🔧 Possible Extensions

* Larger dataset
* Model evaluation metrics
* Prediction history
* Authentication & rate limiting
* Docker support

---

## 👤 Author

**Kanan Ramazanov**
Full‑stack .NET Developer 
