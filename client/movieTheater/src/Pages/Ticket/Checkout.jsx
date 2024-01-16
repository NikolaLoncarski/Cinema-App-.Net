import React from "react";
import { useGlobalContext } from "../../context/Context";
import { apiPost } from "../../utils/axios";
import { format, parseISO } from "date-fns";
import { useNavigate } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import { useState } from "react";

function Checkout({ seatLocation, notify }) {
  const [reserved, setReserved] = useState();
  const {
    movieProjection,
    setMovieProjection,
    ticketData,
    setTicketData,
    notifyLoginExpired,
  } = useGlobalContext();

  const {
    dateAndTimeOfProjecton,
    id,
    movieName,
    movieYearOfRelease,
    movieImageFileName,
    movieImageFilePath,
    projectionTypeType,
    projectionHallName,
    price,
  } = movieProjection;

  let dateOfProjection;
  let timeOfProjection;

  if (dateAndTimeOfProjecton) {
    dateOfProjection = format(dateAndTimeOfProjecton, "MMMM do yyyy");
    timeOfProjection = format(dateAndTimeOfProjecton, "HH:mm:ss");
  }
  const notifyAuthFail = () => {
    toast.error("Authorization failed you will be redirected!", {
      position: toast.POSITION.TOP_RIGHT,
    });
  };

  const navigate = useNavigate();
  let data = { ...ticketData, action: true };
  console.log(ticketData);
  const BuyTicket = async () => {
    try {
      const response = await apiPost("api/MovieTicket/Create", data);
      console.log(response.status);
      if (response.status === 200) {
        notify("Seat reserved successfuly!");

        setTimeout(() => {
          navigate("/reservations");
        }, "5000");
      } else {
        console.log(`Request failed with status: ${response.status}`);
      }
    } catch (err) {
      console.error(err);
      if (err.status === 401) {
        localStorage.removeItem("token");
        notifyAuthFail();
        setTimeout(() => {
          navigate("/login");
        }, "6000");

        /*
  setTimeout(()=>{
    notifyLoginExpired()

  })

       navigate('/login')*/
      }
    }

    console.log(movieProjection);
    console.log("asd");
  };

  return (
    <div className="flex h-fit justify-center items-center">
      <div key={id} className="h-fit flex flex-col  font-mono bg-gray-900">
        <div className="bg-white rounded-md bg-gray-800 shadow-lg">
          <div className="md:flex px-4 leading-none max-w-4xl">
            <div className="flex-none ">
              <img
                src={movieImageFilePath}
                alt={movieImageFilePath}
                className="h-72 w-56 rounded-md shadow-2xl transform -translate-y-4 border-4 border-gray-300 shadow-lg"
              />
            </div>
            <div className="flex-col ml-10 text-gray-600">
              <p className="pt-4 text-2xl font-bold">
                {movieName} {movieYearOfRelease}
              </p>
              <hr className="hr-text" data-content="" />

              <p className="flex text-md px-4 my-2">
                <b> Projection Hall: </b>
                {projectionHallName}
                <span className="font-bold px-2">|</span>
                {projectionTypeType}
              </p>
              <p className="flex text-md px-4 my-2">
                <b>Price:</b> {price}$
              </p>
              <p className="flex text-md px-4 my-2">
                <b> Date and time of Projeciton: </b>
                {dateOfProjection} {timeOfProjection}
              </p>
              <p className="flex text-md px-4 my-2">
                {" "}
                <b>Location:</b> {seatLocation}
              </p>
              <button
                className="w-fit bg-yellow-500 hover:bg-yellow-600  text-gray-700  font-semibold hover:text-white py-2 px-4 border border-gray-500 hover:border-transparent  h-12 "
                onClick={() => BuyTicket()}
              >
                Reserve
              </button>
            </div>
          </div>
        </div>
      </div>
      <ToastContainer />
    </div>
  );
}

export default Checkout;
