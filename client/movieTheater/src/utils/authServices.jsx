import { apiPost } from "./axios.jsx";

const login = async (username, password) => {
  const userData = {
    username,
    password,
  };

  try {
    const response = await apiPost("api/Auth/Login", userData);
    console.log(response.data.jwtToken);
    const token = response.data.jwtToken;
    localStorage.setItem("token", JSON.stringify(token));
    return response;
  } catch (err) {
    console.log(err);
  }
};
const getCurrentUser = () => {
  console.log(JSON.parse(localStorage.getItem("token")));
  return JSON.parse(localStorage.getItem("token"));
};
const AuthService = {
  login,
  getCurrentUser,
};
export default AuthService;
