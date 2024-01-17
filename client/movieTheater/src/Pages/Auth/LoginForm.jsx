import { useState } from "react";
import AuthService from "../../utils/authServices";
import { NavLink, Navigate, useNavigate } from "react-router-dom";
import { ToastContainer, toast } from "react-toastify";
import { useGlobalContext } from "../../context/Context";

function LoginForm({ currentUser, login, notify }) {
  const { setAuth } = useGlobalContext();
  const [username, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const resp = await AuthService.login(username, password);
      localStorage.setItem("roles", JSON.stringify(resp?.data?.roles));

      const roles = resp?.data?.roles;

      const user = resp?.data?.username;
      setAuth({ roles: [roles], user });
      notify("successful login");
      setTimeout(() => {
        navigate("/movies");
      }, 3000);

      return resp.data.jwtToken;
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="container flex h-screen mx-auto">
      <form className="max-w-sm m-auto shadow-md " onSubmit={handleLogin}>
        <div className="bg-yellow-500 font-semibold text-2xl p-2 text-center">
          Login
        </div>
        <div className="p-8">
          <label htmlFor="email" className="">
            Username / Email.com
          </label>
          <input
            type="text"
            name="username"
            className="w-full px-3 py-2 mt-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={(e) => setUserName(e.target.value)}
            placeholder="Email"
          />
          <label htmlFor="password" className="">
            Password
          </label>
          <input
            type="password"
            name="password"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={(e) => setPassword(e.target.value)}
            placeholder="********"
          />
          <button
            type="submit"
            className="w-full p-2 text-white bg-yellow-500 rounded-lg"
          >
            Login
          </button>
          <span className="self-end mt-1">
            Don't have an Account{" "}
            <NavLink className="underline" to="/register">
              Register here
            </NavLink>
          </span>
        </div>
      </form>
      <ToastContainer />
    </div>
  );
}

export default LoginForm;
