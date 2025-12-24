import { useState } from "react";
import { uploadCsv, generateForecast } from "../services/api";

import {
  Chart as ChartJS,
  LineElement,
  PointElement,
  LinearScale,
  CategoryScale,
  Tooltip,
  Legend
} from "chart.js";

import { Line } from "react-chartjs-2";

// Register chart components
ChartJS.register(
  LineElement,
  PointElement,
  LinearScale,
  CategoryScale,
  Tooltip,
  Legend
);

export default function AdminDashboard({ user }) {
  const [file, setFile] = useState(null);
  const [forecast, setForecast] = useState([]);
  const [message, setMessage] = useState("");

  // Chart data
  const chartData = {
    labels: forecast.map(f => f.month),
    datasets: [
      {
        label: "Forecast Value",
        data: forecast.map(f => f.forecastValue),
        borderColor: "blue",
        backgroundColor: "rgba(0, 0, 255, 0.2)",
        fill: false,
        tension: 0.3
      }
    ]
  };

  async function handleUpload() {
    if (!file) {
      alert("Please select a CSV file");
      return;
    }

    const result = await uploadCsv(file, user.role);
    setMessage(result.message || "CSV uploaded successfully");
  }

  async function handleGenerateForecast() {
    const data = await generateForecast(user.role);
    setForecast(data);
  }

  return (
    <div style={{ padding: "40px" }}>
      <h2>Admin Dashboard</h2>
      <p>
        Logged in as: <b>{user.username}</b>
      </p>

      <hr />

      <h3>Upload CSV</h3>
      <input
        type="file"
        accept=".csv"
        onChange={e => setFile(e.target.files[0])}
      />
      <br />
      <br />
      <button onClick={handleUpload}>Upload CSV</button>

      {message && <p style={{ color: "green" }}>{message}</p>}

      <hr />

      <h3>Generate Forecast</h3>
      <button onClick={handleGenerateForecast}>
        Generate 12-Month Forecast
      </button>

      {forecast.length > 0 && (
        <>
          <h3>Forecast Table</h3>
          <table border="1" cellPadding="8">
            <thead>
              <tr>
                <th>Month</th>
                <th>Forecast Value</th>
              </tr>
            </thead>
            <tbody>
              {forecast.map(item => (
                <tr key={item.id}>
                  <td>{item.month}</td>
                  <td>{item.forecastValue}</td>
                </tr>
              ))}
            </tbody>
          </table>

          <hr />

          <h3>Forecast Trend</h3>
          <Line data={chartData} />
        </>
      )}
    </div>
  );
}
