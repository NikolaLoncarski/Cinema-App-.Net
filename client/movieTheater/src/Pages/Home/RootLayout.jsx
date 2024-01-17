import { Outlet, useNavigate } from "react-router-dom";
import Sidebar from "../Admin/Sidebar";
import Navbar from "./Navbar";
import { useEffect } from "react";

function RootLayout({ currentUser, setCurrentUser }) {
  const navigate = useNavigate();

  return (
    <div>
      <main className="overflow-auto h-screen w-screen w-svw">
        <Outlet />
      </main>
    </div>
  );
}

export default RootLayout;
