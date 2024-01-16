import { useState, useEffect } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import { apiGet } from "../../utils/axios";
import Projections from "../Projection/Projection";
import { format } from "date-fns";
import { TailSpin } from "react-loader-spinner";
import AuthService from "../../utils/authServices";
function Movie({ movies, isLoading }) {
  const [movieProjections, setMovieProjections] = useState([]);
  const [isLoadingProjection, setIsLoadingProjeciton] = useState(false);
  const [showDropdown, setShowDropdown] = useState([]);

  const navigate = useNavigate();

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

  return (
    <section className="pt-24 grid  place-items-center">
      {isLoading && <TailSpin className="p-4 border" />}

      {!isLoading &&
        movies.length > 0 &&
        movies.map((ele, index) => (
          <div key={index}>
            <div className="relative flex flex-row mt-6 text-gray-700 bg-white shadow-2xl bg-clip-border rounded-xl m-16 max-w-screen-xl  h-96 ">
              <div className="w-72 h-96 ">
                <img
                  className="max-w-full max-h-full  rounded-md shadow-2xl transform -translate-y-4 border-4 border-gray-300 shadow-lg"
                  src={ele.imageFilePath}
                  alt={ele.imageFileName}
                />
              </div>

              <div className="flex flex-col justify-around w-1/2">
                <h2 className="text-2xl">{ele.movieName}</h2>

                <p className="text-xl">
                  <b>Genre:</b> {ele.genre}
                </p>

                <p className="text-xl">
                  <b>Director: </b>
                  {ele.director}
                </p>

                <p className="text-xl">
                  <b>Duraiton:</b> {ele.duration} min
                </p>

                <p className="text-xl text-justify">
                  <b>Desription:</b> {ele.description}{" "}
                </p>

                <button
                  onClick={() => {
                    setShowDropdown();
                    getProjectionById(ele.id);
                    handleDropdownClick(index);
                  }}
                  className="w-fit bg-yellow-500 hover:bg-yellow-600  text-gray-700  font-semibold hover:text-white py-2 px-4 border border-gray-500 hover:border-transparent  h-12 "
                >
                  Projections
                </button>
              </div>
            </div>
            {showDropdown[index] && movieProjections.length > 0 && (
              <div className="relative flex flex-row mt-1 bg-neutral-400 shadow-md bg-clip-border   max-w-full h-36 m-16 gap-3 items-center ">
                {movieProjections.map((ele, index) => {
                  let projecitonDate = format(
                    ele.dateAndTimeOfProjecton,
                    "MMMM do yyyy"
                  );
                  let projecitonTime = format(
                    ele.dateAndTimeOfProjecton,
                    "HH:mm:ss"
                  );
                  return (
                    <div
                      key={index}
                      className="bg-yellow-500 cursor-pointer h-fit m-5 text-gray-700 shadow-md hover:bg-white  p-2"
                      onClick={() => {
                        navigate("/projection", {
                          state: { projectionId: `${ele.id}` },
                        });
                      }}
                    >
                      <p>{projecitonDate}</p>
                      <p>{projecitonTime}</p>
                    </div>
                  );
                })}
              </div>
            )}{" "}
          </div>
        ))}
    </section>
  );
}

export default Movie;
