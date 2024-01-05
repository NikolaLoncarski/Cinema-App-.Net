import { useState } from "react";

function LoginForm() {
  const [username, setUserName] = useState();
  const [password, setPassword] = useState();
  const Login = async () => {
    const data = await fetch(" https://localhost:7029/api/Auth/Login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ username, password }),
    });
    console.log(data);
  };
  const submitForm = (e) => {
    e.preventDefault();
    Login();
  };
  return (
    <>
      <form action="" className="d-flex justify-center flex-col ">
        <input
          type="text"
          name="username"
          className="h-12 w-96 border-solid border-2 border-sky-500"
          onChange={(e) => setUserName(e.target.value)}
        />
        <input
          type="text"
          name="password"
          className="h-12 w-96 border-solid border-2 border-sky-500"
          onChange={(e) => setPassword(e.target.value)}
        />
        <input type="submit" onClick={submitForm} />
      </form>
    </>
  );
}

export default LoginForm;
