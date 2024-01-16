import React, { useEffect, useState } from "react";
import { apiGet } from "../../utils/axios";
import ReservationTicket from "./ReservationTicket";
function Reservations() {
  const [reservations, setReservations] = useState([]);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
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

    getProjectionById();
  }, []);
  // <ReservationTicket reservations={reservations} isLoading={isLoading} />
  return (
    <div>
      <ReservationTicket reservations={reservations} isLoading={isLoading} />
    </div>
  );
}

export default Reservations;
