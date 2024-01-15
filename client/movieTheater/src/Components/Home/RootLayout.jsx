import { Outlet ,useNavigate} from "react-router-dom";
import Sidebar from "../Admin/Sidebar";
import Navbar from "./Navbar";
import { useEffect } from "react";


function RootLayout({ currentUser,setCurrentUser }) {
  const navigate = useNavigate();

useEffect(() => {
  return () => {
 if (currentUser) {

   navigate("/movies");
 }
  };
}, [currentUser])
 

  return (
    <div >
      <Navbar currentUser={currentUser} setCurrentUser={setCurrentUser} />


      <main className="overflow-auto h-screen w-screen w-svw">
        <Outlet  />

      </main>
    </div>
  );
}

export default RootLayout;
