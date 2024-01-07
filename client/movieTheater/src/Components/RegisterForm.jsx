import { useState } from "react";
import { apiPost } from "../utils/axios";

function RegisterFotm() {
  const [username, setUserName] = useState();
  const [password, setPassword] = useState();

  const userData = { username, password, roles: ["user"] };
  const Login = async () => {
    const data = await apiPost("api/Auth/Register", userData);

    if (data.jwtToken) {
      localStorage.setItem("token", data.jwtToken);
    } else {
      console.log("error");
    }
  };
  const submitForm = (e) => {
    e.preventDefault();
    Login();
  };
  return (
    <div className="container flex h-screen mx-auto">
      <form className="max-w-sm m-auto shadow-md ">
        <div className="bg-violet-500 font-semibold text-2xl p-2 text-center">
          Register
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
            className="w-full p-2 text-white bg-violet-700 rounded-lg"
            onClick={submitForm}
          >
            Login
          </button>
        </div>
      </form>
    </div>
  );
}

export default RegisterFotm;
