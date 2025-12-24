import { useState } from "react";
import Login from "./pages/Login";
import AdminDashboard from "./pages/AdminDashboard";

export default function App() {
  const [user, setUser] = useState(null);

  if (!user) {
    return <Login onLogin={setUser} />;
  }

  if (user.role === "Admin") {
    return <AdminDashboard user={user} />;
  }

  return (
    <div style={{ padding: "40px" }}>
      <h2>Welcome {user.username}</h2>
      <p>Role: {user.role}</p>
      <p>No dashboard assigned for this role yet.</p>
    </div>
  );
}
