import React from "react";
import { NavLink, useNavigate } from "react-router-dom";
import { useGlobalContext } from "../../context/Context";
function Navbar({ currentUser, setCurrentUser }) {
  const { setUser } = useGlobalContext();
  const { auth } = useGlobalContext();
  const navigate = useNavigate();
  return (
    <>
      <nav className="bg-yellow-500 dark:bg-yellow-500 fixed w-full z-20 top-0 start-0 border-b border-gray-200  dark:border-gray-600">
        <div className="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4">
          <h1 className=" text-2xl neonText text-red-700">
            <NavLink to="/"> Cinema</NavLink>
          </h1>
          <div className="flex gap-3 md:order-2 space-x-3 md:space-x-0 rtl:space-x-reverse">
            {!localStorage.getItem("token") ? (
              <>
                {" "}
                <NavLink
                  to="/login"
                  className=" text-gray-700  border-solid border-2  border-gray-300 bg-yello-700 hover:bg-yello-800 focus:ring-4 focus:outline-none focus:ring-yello-300 font-medium rounded-lg text-sm px-4 py-2 text-center dark:bg-yello-600 dark:hover:bg-yello-700 dark:focus:ring-yello-800"
                >
                  Login
                </NavLink>
                <NavLink
                  to="/register"
                  className=" text-gray-700  border-solid border-2  border-gray-300 bg-yellow-500 hover:bg-yellow-800 focus:ring-4 focus:outline-none focus:ring-yello-300 font-medium rounded-lg text-sm px-4 py-2 text-center dark:bg-yello-600 dark:hover:bg-yello-700 dark:focus:ring-yello-800"
                >
                  Register
                </NavLink>
              </>
            ) : (
              <NavLink
                to="/login"
                onClick={() => {
                  localStorage.removeItem("token");
                  localStorage.removeItem("roles");
                  setUser({});
                }}
                className=" text-gray-700  border-solid border-2   border-gray-300 bg-yellow-500 hover:bg-yellow-800 focus:ring-4 focus:outline-none focus:ring-yello-300 font-medium rounded-lg text-sm px-4 py-2 text-center dark:bg-yello-600 dark:hover:bg-yello-700 dark:focus:ring-yello-800"
              >
                Log Out
              </NavLink>
            )}
          </div>
          <div className="items-center justify-between hidden w-full md:flex md:w-auto md:order-1">
            <div className="flex flex-col  p-4 md:p-0 mt-4 font-medium border border-gray-100 rounded-lg bg-gray-50 md:space-x-8 rtl:space-x-reverse md:flex-row md:mt-0 md:border-0 md:bg-white dark:bg-yellow-500 md:dark:bg-yellow-500 dark:border-gray-700">
              <NavLink
                to="/movies"
                className=" text-gray-700  border-solid border-2  border-gray-300 bg-yellow-500 hover:bg-yellow-800 focus:ring-4 focus:outline-none focus:ring-yello-300 font-medium rounded-lg text-sm px-4 py-2 text-center dark:bg-yello-600 dark:hover:bg-yello-700 dark:focus:ring-yello-800"
              >
                Movies
              </NavLink>
              <NavLink
                to="/reservations"
                className=" text-gray-700  border-solid border-2  border-gray-300 bg-yellow-500 hover:bg-yellow-800 focus:ring-4 focus:outline-none focus:ring-yello-300 font-medium rounded-lg text-sm px-4 py-2 text-center dark:bg-yello-600 dark:hover:bg-yello-700 dark:focus:ring-yello-800"
              >
                Reservations
              </NavLink>{" "}
              {auth.roles.includes("Admin") && (
                <NavLink
                  to="/admin"
                  className=" text-gray-700   border-solid border-2  border-gray-300 bg-yellow-500 hover:bg-yellow-800 focus:ring-4 focus:outline-none focus:ring-yello-300 font-medium rounded-lg text-sm px-4 py-2 text-center dark:bg-yello-600 dark:hover:bg-yello-700 dark:focus:ring-yello-800"
                >
                  Admin Menu
                </NavLink>
              )}
            </div>
          </div>
        </div>
      </nav>
    </>
  );
}

export default Navbar;
