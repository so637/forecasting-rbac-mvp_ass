const API_BASE = "http://localhost:5294/api";

export async function login(data) {
  const res = await fetch(`${API_BASE}/auth/login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(data)
  });

  return res.json();
}

export async function uploadCsv(file, role) {
  const formData = new FormData();
  formData.append("file", file);

  const res = await fetch(`${API_BASE}/admin/upload-csv`, {
    method: "POST",
    headers: {
      "X-User-Role": role
    },
    body: formData
  });

  return res.json();
}

export async function generateForecast(role) {
  const res = await fetch(`${API_BASE}/admin/generate-forecast`, {
    method: "POST",
    headers: {
      "X-User-Role": role
    }
  });

  return res.json();
}
