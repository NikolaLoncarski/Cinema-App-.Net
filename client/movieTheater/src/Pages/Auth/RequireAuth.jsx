import { useLocation, Navigate, Outlet } from "react-router-dom";
import { useGlobalContext } from "../../context/Context";

const RequireAuth = ({ allowedRoles, currentUser }) => {
  const { auth } = useGlobalContext();
  const location = useLocation();
  console.log("a");
  console.log(localStorage.getItem("token"));
  console.log(auth.roles)
  return (
    auth?.roles?.find((role) => allowedRoles?.includes(role)) ? (
      <Outlet />
    ) : auth?.user ? (
      <Navigate to="/unauthorized" state={{ from: location }} replace />
    ) : (
      <Navigate to="/login" state={{ from: location }} replace />
    ))
  };

export default RequireAuth;
