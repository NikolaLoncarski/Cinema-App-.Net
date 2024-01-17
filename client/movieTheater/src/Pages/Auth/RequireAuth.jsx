import { useLocation, Navigate, Outlet } from "react-router-dom";
import { useGlobalContext } from "../../context/Context";

const RequireAuth = ({ allowedRoles, currentUser }) => {
  const { auth } = useGlobalContext();
  const location = useLocation();
  console.log("a");
  console.log(localStorage.getItem("token"));
  return (
    auth?.roles?.find((role) => allowedRoles?.includes(role)) && <Outlet />
  );
};

export default RequireAuth;
