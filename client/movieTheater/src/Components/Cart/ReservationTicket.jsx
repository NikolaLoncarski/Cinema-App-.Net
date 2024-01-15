import React, { useState,useEffect } from 'react'
import {format} from "date-fns"
import {  apiDeleteTicket } from '../../utils/axios';
function ReservationTicket({reservations, isLoading}) {

 const currentDate = new Date()

 const initialDate = new Date(currentDate);

 const formattedDate = format(initialDate, "yyyy-MM-dd'T'HH:mm:ss.SSS");

 const deleteReservation = async (movieTicketId, action, seatId) => {
   const data = { movieTicketId, action, seatId };
console.log(data)
   try {
     const response = await apiDeleteTicket('api/MovieTicket/DeleteTicket', JSON.stringify(data));
     console.log(response);
   } catch (error) {
     console.error("Error fetching projections:", error);
   }
 };




  return (
   
    <div>
      {!isLoading &&
        reservations.length > 0 &&
        reservations.map((item, index) => (
        

          <div
            key={item.id}
            className="h-fit mt-32 grid place-items-center font-mono "
          >
            <div className="bg-white rounded-md bg-gray-800 shadow-lg">
              <div className="md:flex px-4 leading-none max-w-4xl">
                <div className="flex-none ">
                  <img
                    src={item.image_Src}
                    alt={item.image_Name}
                    className="h-72 w-56 rounded-md shadow-2xl transform -translate-y-4 border-4 border-gray-300 shadow-lg"
                  />
                </div>

                <div className="flex-col text-gray-700">
                  <p className="pt-4 text-2xl font-bold">{item.movie_name}</p>
                  <hr className="hr-text" data-content="" />

                  <p className="flex text-md px-4 my-2">
                    Projection Hall: {item.projectionHall_Name}
                  </p>
                  <p className="flex text-md px-4 my-2">
                    Projection Type: {item.projection_Type}
                  </p>
                  <p className="flex text-md px-4 my-2">price: {item.price}$</p>
                  <p className="flex text-md px-4 my-2">
                    Date and time of : {item.starts}
                  </p>
                  <p className="flex text-md px-4 my-2">
                    Seat : {item.seat_Location}
                  </p>

                  {item.starts > formattedDate && <button onClick={()=>{

                  deleteReservation(item.id,false,item.seat_Id)

                  }}
                  className="bg-yellow-500 hover:bg-gray-100 text-gray-800 font-semibold py-2 px-4 border border-gray-400 rounded shadow h-fit self-center">
                    Cancel Reservation
                  </button>  }
                 
                </div>
              </div>
            </div>
          </div>
        ))}
    </div>
  );
}

export default ReservationTicket