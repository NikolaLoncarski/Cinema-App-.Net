import "./App.css";
import LoginForm from "./Components/LoginForm";
import RegisterForm from "./Components/RegisterForm";
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

import Movies from "./Components/Movies";
import RootLayout from "./Components/RootLayout";
import Projections from "./Components/Projections";
import HomePage from "./Components/HomePage";

function App() {
  const [currentUser, setCurrentUser] = useState(null);

  const checkUser = useCallback(() => {
    const user = AuthService.getCurrentUser();

    if (user) {
      setCurrentUser(user);
    }
  }, [currentUser]);

  useEffect(() => {
    checkUser();
  }, [checkUser, currentUser]);

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route
        path="/"
        element={
          currentUser ? (
            <RootLayout currentUser={currentUser} />
          ) : (
            <LoginForm currentUser={currentUser} login={checkUser} />
          )
        }
      >
        <Route index element={<RootLayout />} />
        <Route path="/movies" element={<Movies />} />
        <Route path="/projections" element={<Projections />} />
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
