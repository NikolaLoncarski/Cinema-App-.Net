import "./App.css";
import LoginForm from "./Components/Auth/LoginForm";
import RegisterForm from "./Components/Auth/RegisterForm";
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

import Movies from "./Components/Movie/Movies";
import RootLayout from "./Components/Home/RootLayout";
import Projections from "./Components/Projection/Projection";

import Ticket from "./Components/Ticket/Ticket";
import Checkout from "./Components/Ticket/Checkout";
import { toast } from "react-toastify";
import Reservations from "./Components/Cart/Reservations";

function App() {
  const [currentUser, setCurrentUser] = useState(null);

  const notifyAuthFail = () => {
    toast.error("Authorization failed you will be redirected!", {
      position: toast.POSITION.TOP_RIGHT,
    });
  };
  const checkUser = useCallback(() => {
    const user = AuthService.getCurrentUser();

    if (user) {
      setCurrentUser(user);
    }
    console.log(currentUser);
  }, [currentUser]);

  useEffect(() => {
    checkUser();
  }, [checkUser, currentUser]);

  const notify = (messsage) => {
    toast.error(`${messsage}`, {
      position: toast.POSITION.TOP_RIGHT,
    });
  };

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

  return (
    <div className="App">
      <RouterProvider router={router} />
    </div>
  );
}

export default App;
