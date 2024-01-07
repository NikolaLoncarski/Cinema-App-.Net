import { useState, useEffect } from "react";
import { NavLink } from "react-router-dom";
import { apiGet } from "../utils/axios";
import Projections from "./Projections";
import { format } from "date-fns";

function Movie({ movies, isLoading }) {
  const [movieProjections, setMovieProjections] = useState([]);
  const [isLoadingProjection, setIsLoadingProjeciton] = useState(false);
  const [showDropdown, setShowDropdown] = useState([]);

  const handleDropdownClick = (itemId) => {
    setShowDropdown((prevShowDropdown) => {
      const updatedDropdown = { ...prevShowDropdown };
      updatedDropdown[itemId] = !updatedDropdown[itemId];
      return updatedDropdown;
    });
  };

  const getProjectionById = async (id) => {
    setIsLoadingProjeciton(true);
    try {
      const response = await apiGet(`api/Projection/GetByMovieId?id=${id}`);
      setMovieProjections(response);
      setIsLoadingProjeciton(false);
    } catch (error) {
      console.error("Error fetching projections:", error);
      setIsLoadingProjeciton(false);
    }
  };

  console.log(movieProjections);
  console.log(movies);
  return (
    <section className="pt-24 flex  flex-col">
      {!isLoading &&
        movies.length > 0 &&
        movies.map((ele, index) => (
          <>
            <div
              className="relative flex flex-row mt-6 text-gray-700 bg-white shadow-xl bg-clip-border rounded-xl max-w-full h-96 m-16 "
              key={index}
            >
              <div className="w-72 h-96 ">
                <img
                  className="max-w-full max-h-full"
                  src={ele.imageFilePath}
                  alt={ele.imageFileName}
                />
              </div>

              <ul className="flex flex-col justify-around w-1/2">
                <li>
                  {" "}
                  <h2 className="text-2xl">{ele.movieName}</h2>
                </li>
                <li>
                  {" "}
                  <p className="text-xl">Genre: {ele.genre}</p>
                </li>
                <li>
                  {" "}
                  <p className="text-xl">Director: {ele.director}</p>
                </li>
                <li>
                  {" "}
                  <p className="text-xl">Duraiton: {ele.duration} min</p>
                </li>
                <li>
                  {" "}
                  <p className="text-xl">Desription: {ele.description} </p>
                </li>
                <li>
                  <button
                    onClick={() => {
                      setShowDropdown();
                      getProjectionById(ele.id);
                      handleDropdownClick(index);
                    }}
                    className="bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded h-12"
                  >
                    Projections
                  </button>
                </li>
              </ul>
            </div>
            {showDropdown[index] && movieProjections.length > 0 && (
              <div className="relative flex flex-row mt-1 text-gray-700 bg-white shadow-md bg-clip-border rounded-xl max-w-full h-12 m-16 gap-3">
                {movieProjections.map((ele, index) => {
                  let projecitonDate = format(
                    ele.dateAndTimeOfProjecton,
                    "MMMM do yyyy"
                  );
                  let projecitonTime = format(
                    ele.dateAndTimeOfProjecton,
                    "h:mm:ss a"
                  );
                  return (
                    <div
                      key={index}
                      className="bg-neutral-200 text-gray-50 shadow-md bg-clip-border rounded-xl"
                    >
                      <p>{projecitonDate}</p>
                      <p>{projecitonTime}</p>
                    </div>
                  );
                })}
              </div>
            )}{" "}
          </>
        ))}
    </section>
  );
}

export default Movie;
