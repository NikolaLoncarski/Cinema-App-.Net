import { Outlet } from "react-router-dom";
import Sidebar from "./Sidebar";

function RootLayout({ currentUser }) {
  return (
    <div className="flex">
      {currentUser && <Sidebar />}

      <main className="overflow-auto h-screen w-screen w-svw">
        <Outlet />
      </main>
    </div>
  );
}

export default RootLayout;
