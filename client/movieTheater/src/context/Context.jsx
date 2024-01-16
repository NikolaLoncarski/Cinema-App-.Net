import React, { useContext, useState, useEffect, useCallback } from "react";
import { useNavigate } from "react-router-dom";

import { ToastContainer, toast } from "react-toastify";

const AppContext = React.createContext();

export const AppProvider = ({ children }) => {
  const [movieProjection, setMovieProjection] = useState([]);
  const [ticketData, setTicketData] = useState();
  const [userId, setUserId] = useState("");
  const [auth, setAuth] = useState({});

  const notifyLoginExpired = () => {
    toast.error("Login expired!", {
      position: toast.POSITION.TOP_RIGHT,
    });
  };

  return (
    <AppContext.Provider
      value={{
        movieProjection,
        setMovieProjection,
        ticketData,
        setTicketData,
        setUserId,
        notifyLoginExpired,

        auth,
        setAuth,
      }}
    >
      {children}
    </AppContext.Provider>
  );
};
export const useGlobalContext = () => {
  return useContext(AppContext);
};
