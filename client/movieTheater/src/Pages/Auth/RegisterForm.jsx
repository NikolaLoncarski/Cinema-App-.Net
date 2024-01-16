import { useState } from "react";
import { apiPost } from "../../utils/axios";
 import { ToastContainer } from "react-toastify";

 import "react-toastify/dist/ReactToastify.css";

function RegisterForm({notify}) {
  const [username, setUserName] = useState();
  const [password, setPassword] = useState();
    const [passwordRepeat, setPasswordRepeat] = useState();

  const userData = { username, password, roles: ["user"] };

   

    const checkPasswordMatch= (pass,repeatPass)=>{
   if (pass !== repeatPass) {
notify("Password and ConfirmPassword do not match please try again!")
   }
   return
    }

  const Login = async () => {
    checkPasswordMatch(password,passwordRepeat)
    try {
    const data = await apiPost("api/Auth/Register", userData);

    if (data.status === 200 ) {
console.log('successful reg')
notify("User was sucessfuly resitered")

    }    }catch(err) {
      
    }
  };
  const submitForm = (e) => {
    e.preventDefault();
    Login();
  };

  return (
    <div className="container flex h-screen mx-auto">
      <form className="max-w-sm m-auto shadow-md ">
        <div className="bg-yellow-500 font-semibold text-2xl p-2 text-center">
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
          <label htmlFor="password" className="">
            Repeat Password
          </label>
          <input
            type="password"
            name="password"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={(e) => setPasswordRepeat(e.target.value)}
            placeholder="********"
          />
          <button
            type="submit"
            className="w-full p-2 text-white bg-yellow-500 rounded-lg"
            onClick={submitForm}
          >
            Register
          </button>
        </div>
      </form>
 <ToastContainer/>
    </div>
  );
}

export default RegisterForm
