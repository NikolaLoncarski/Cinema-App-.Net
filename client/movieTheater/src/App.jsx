import "./App.css";
import LoginForm from "./Pages/Auth/LoginForm";
import RegisterForm from "./Pages/Auth/RegisterForm";
import { useState, useCallback, useEffect } from "react";
import AuthService from "./utils/authServices";
import {
  Routes,
  Route,
  Navigate,
  createBrowserRouter,
  createRoutesFromElements,
  RouterProvider,
} from "react-router-dom";

import Movies from "./Pages/Movie/Movies";
import RootLayout from "./Pages/Home/RootLayout";
import Projections from "./Pages/Projection/Projection";
import RequireAuth from "./Pages/Auth/RequireAuth";
import Ticket from "./Pages/Ticket/Ticket";
import Checkout from "./Pages/Ticket/Checkout";
import { toast } from "react-toastify";
import Reservations from "./Pages/Cart/Reservations";
import Navbar from "./Pages/Home/Navbar";
import UploadMovieImage from "./Pages/Admin/UploadMovieImage";
import CreateMovie from "./Pages/Admin/CreateMovie";
import AdminMenu from "./Pages/Admin/AdminMenu";
import CreateProjection from "./Pages/Admin/CreateProjection";
import Statistics from "./Pages/Admin/Statistics";
function App() {
  const [currentUser, setCurrentUser] = useState(
    JSON.parse(localStorage.getItem("token"))
  );

  const notifyAuthFail = () => {
    toast.error("Authorization failed you will be redirected!", {
      position: toast.POSITION.TOP_RIGHT,
    });
  };

  const ROLES = {
    User: "User",
    Admin: "Admin",
  };

  const checkUser = useCallback(() => {
    const user = AuthService.getCurrentUser();

    if (user) {
      setCurrentUser(user);
    }
  }, [currentUser]);

  useEffect(() => {
    checkUser();
  }, [currentUser]);

  const notify = (messsage) => {
    toast.error(`${messsage}`, {
      position: toast.POSITION.TOP_RIGHT,
    });
  };

  return (
    <div className="App">
      <Navbar />
      <Routes>
        <Route
          element={
            <RootLayout
              setCurrentUser={setCurrentUser}
              currentUser={currentUser}
            />
          }
        >
          <Route
            index
            element={
              currentUser ? <Navigate to="/movies" /> : <Navigate to="/login" />
            }
          />
          <Route
            path="/login"
            element={<LoginForm currentUser={currentUser} notify={notify} />}
          />
          <Route path="/register" element={<RegisterForm notify={notify} />} />
          <Route
            element={
              <RequireAuth
                currentUser={currentUser}
                allowedRoles={[ROLES.User, ROLES.Admin]}
              />
            }
          >
            <Route
              path="/movies"
              element={<Movies currentUser={currentUser} notify={notify} />}
            />
            <Route
              path="/projection"
              element={<Projections notify={notify} />}
            />
            <Route path="/ticket" element={<Ticket notify={notify} />} />
            <Route path="/checkout" element={<Checkout notify={notify} />} />

            <Route
              path="/reservations"
              element={<Reservations notify={notify} />}
            />
          </Route>
        </Route>
        <Route
          element={
            <RequireAuth
              currentUser={currentUser}
              allowedRoles={[ROLES.Admin]}
            />
          }
        >
          <Route path="/admin" element={<AdminMenu />} />
          <Route path="/image-upload" element={<UploadMovieImage />} />
          <Route path="/create-movie" element={<CreateMovie />}></Route>
          <Route
            path="/create-projection"
            element={<CreateProjection />}
          ></Route>
          <Route path="/statistics" element={<Statistics />}></Route>
        </Route>
      </Routes>
    </div>
  );
}

export default App;
