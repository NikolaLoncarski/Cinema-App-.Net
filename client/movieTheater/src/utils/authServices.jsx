import { apiPost } from "./axios.jsx";

const login = async (username, password) => {
  const userData = {
    username,
    password,
  };

  try {
    const response = await apiPost("api/Auth/Login", userData);

    localStorage.setItem("token", JSON.stringify(response.data.jwtToken));
    return response;
  } catch (err) {
    console.log(err);
  }
};
const getCurrentUser = () => {
  return JSON.parse(localStorage.getItem("token"));
};
const AuthService = {
  login,
  getCurrentUser,
};
export default AuthService;
