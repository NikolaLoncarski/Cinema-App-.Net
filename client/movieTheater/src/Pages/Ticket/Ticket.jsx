import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";
import { apiGet } from "../../utils/axios";
import { useGlobalContext } from "../../context/Context";

import { useNavigate } from "react-router-dom";
import Checkout from "./Checkout";
function Ticket({ notify }) {
  const { movieProjection, setMovieProjection, ticketData, setTicketData } =
    useGlobalContext();
  const [isLoading, setIsLoading] = useState(false);
  const [seats, setSeats] = useState([]);

  const [activeBtn, setActiveBtn] = useState(null);
  const [ticketId, setTicketId] = useState(null);
  const [showNext, setShowNext] = useState(false);
  const [seatLocation, setSeatLocation] = useState();

  const navigate = useNavigate();
  const { state } = useLocation();

  const projectionId = state?.projectionId;
  useEffect(() => {
    setIsLoading(true);
    const getProjectionById = async (id) => {
      try {
        const response = await apiGet(
          `api/Seat/GetSeatsByProjectionId?id=${id}`
        );
        setSeats(response);
        console.log(response[0].projectionId);
        setTicketData({
          ...ticketData,
          projectionId: response[0].projectionId,
        });

        console.log(response);
        setIsLoading(false);
      } catch (error) {
        setIsLoading(false);
        console.error("Error fetching movies:", error);
      }
    };
    getProjectionById(projectionId);
  }, []);

  console.log(ticketId);

  return (
    <div className="flex justify-center items-center flex-col h-fit mt-24 w-full text-2xl ">
      Chose a Seat
      <div className="md:w-1/2 md:h-1/2 w-11/12 h-11/12 border-solid border-8 bg-green-200 border-yellow-500 rounded-md flex  flex-col justify-between items-center ">
        {" "}
        <div className="border-solid border-8 border-gray-800 h-1 w-11/12 mt-1"></div>
        <div className=" grid grid-cols-10 m-2 gap-3 max-w-full mt-32 h-full border-none place-content-baseline">
          {!isLoading &&
            seats.length > 0 &&
            seats.map((item, index) => {
              if (!item.reserved) {
                return (
                  <button
                    className={`w-6 h-6   rounded-t-lg bg hover:scale-150 hover:bg-red-500 md:w-12 md:h-12 ${
                      index === activeBtn
                        ? "scale-150 bg-red-500"
                        : " bg-yellow-500"
                    }  `}
                    key={index}
                    onClick={() => {
                      setActiveBtn(index);
                      setTicketData({ ...ticketData, seatId: item.id });
                      setSeatLocation(item.location);
                      console.log(item.id);
                      setShowNext(true);
                    }}
                  >
                    {item.location}
                  </button>
                );
              } else {
                return (
                  <button
                    className="w-6 h-6 md:w-12 md:h-12  rounded-t-lg bg-red-900 disabled "
                    key={index}
                  >
                    {item.location}
                  </button>
                );
              }
            })}
        </div>
        <div className="flex flex-row gap-5 items-center justify-center">
          <div className="w-5 h-5 border bg-yellow-500"></div>
          <div>free </div>
          <div className="w-5 h-5 border bg-red-900"></div>
          <div>reserved</div>
        </div>
      </div>
      <div className="container flex h-fit justify-center mx-auto mt-12">
        {showNext && <Checkout notify={notify} seatLocation={seatLocation} />}
      </div>
    </div>
  );
}

export default Ticket;
