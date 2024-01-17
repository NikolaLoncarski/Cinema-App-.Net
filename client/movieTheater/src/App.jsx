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
  /*
  const checkUser = useCallback(() => {
    const user = AuthService.getCurrentUser();

    if (user) {
      setCurrentUser(user);
    }
    console.log(user);
  }, [currentUser]);

  useEffect(() => {
    checkUser();
    console.log("current");
  }, [currentUser]);
  */
  const notify = (messsage) => {
    toast.error(`${messsage}`, {
      position: toast.POSITION.TOP_RIGHT,
    });
  };
  /*
  const router = createBrowserRouter(
    createRoutesFromElements(
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
        <Route
          path="/movies"
          element={
            <Movies
              currentUser={currentUser}
              notify={notify}
              checkUser={checkUser}
            />
          }
        />
        <Route path="/register" element={<RegisterForm notify={notify} />} />
        <Route path="/projection" element={<Projections notify={notify} />} />
        <Route path="/ticket" element={<Ticket notify={notify} />} />
        <Route path="/checkout" element={<Checkout notify={notify} />} />
        <Route path="/ticket" element={<Ticket notify={notify} />} />
        <Route
          path="/reservations"
          element={<Reservations notify={notify} />}
        />
      </Route>
    )
  );
*/
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
            path="/login"
            element={<LoginForm currentUser={currentUser} notify={notify} />}
          />
          <Route path="/register" element={<RegisterForm notify={notify} />} />
          <Route
            element={
              <RequireAuth
                currentUser={currentUser}
                allowedRoles={[ROLES.User]}
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
      </Routes>
    </div>
  );
}

export default App;
