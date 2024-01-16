import React, { useEffect, useState } from "react";
import { apiGet } from "../../utils/axios";
import ReservationTicket from "./ReservationTicket";
import { current } from "@reduxjs/toolkit";
function Reservations() {
  const [reservations, setReservations] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [resedApi, setResendApi] = useState(false);

  const getProjectionById = async () => {
    setIsLoading(true);
    try {
      const response = await apiGet(`api/MovieTicket/GetTicketByUserId`);
      console.log(response);
      setReservations(response);

      setIsLoading(false);
    } catch (error) {
      console.error("Error fetching projections:", error);
    }
  };
  useEffect(() => {
    getProjectionById();
  }, []);
  // <ReservationTicket reservations={reservations} isLoading={isLoading} />
  return (
    <div>
      <ReservationTicket
        setResendApi={setResendApi}
        reservations={reservations}
        getProjectionById={getProjectionById}
      />
    </div>
  );
}

export default Reservations;
