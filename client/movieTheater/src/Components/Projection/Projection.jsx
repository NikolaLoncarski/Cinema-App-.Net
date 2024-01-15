import { useState, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { apiGet } from "../../utils/axios";
import { format, parseISO } from "date-fns";
import { useGlobalContext } from "../../context/Context";
function Projection() {
  const { movieProjection, setMovieProjection } = useGlobalContext();
  const [isLoading, setIsLoading] = useState(false);
  const { state } = useLocation();
  const projectionId = state?.projectionId;
  console.log(projectionId);

  const navigate = useNavigate();

  useEffect(() => {
    setIsLoading(true);
    const getProjectionById = async (id) => {
      try {
        const response = await apiGet(`api/Projection/GetById?id=${id}`);
        setMovieProjection(response);
        setIsLoading(false);
      } catch (error) {
        setIsLoading(false);
        console.error("Error fetching movies:", error);
      }
    };

    getProjectionById(projectionId);
  }, [projectionId]);
  const ProjectionCard = () => {
    const {
      dateAndTimeOfProjecton,
      id,
      movieId,
      movieName,
      movieDirector,
      movieLeadActor,
      movieGenre,
      movieDuration,
      movieDistributer,
      movieCountryOfOrigin,
      movieYearOfRelease,
      movieDescription,
      movieImageId,
      movieImageFileName,
      movieImageFilePath,
      projectionTypeId,
      projectionType,
      projectionHallId,
      projectionHallName,
      price,
    } = movieProjection;

    let dateOfProjection;
    let timeOfProjection;
    if (dateAndTimeOfProjecton) {
      dateOfProjection = format(dateAndTimeOfProjecton, "MMMM do yyyy");
      timeOfProjection = format(dateAndTimeOfProjecton, "HH:mm:ss");
    }

    return (
      <div
        key={id}
        className="min-h-screen grid place-items-center font-mono bg-gray-100"
      >
        <div className="bg-white rounded-md bg-gray-800 shadow-lg">
          <div className="md:flex px-4 leading-none max-w-4xl">
            <div className="flex-none ">
              <img
                src={movieImageFilePath}
                alt={movieImageFilePath}
                className="h-72 w-56 rounded-md shadow-2xl transform -translate-y-4 border-4 border-gray-300 shadow-lg"
              />
            </div>
            <div className="flex-col text-gray-700">
              <p className="pt-4 text-2xl font-bold">
                {movieName} {movieYearOfRelease}
              </p>
              <hr className="hr-text" data-content="" />
              <div className="text-md flex justify-between px-4 my-2">
                <span className="font-bold">
                  {movieDuration} min | {movieGenre}
                </span>
                <span className="font-bold"></span>
              </div>
              <p className="hidden md:block px-4 my-4 text-sm text-left">
                {movieDescription}{" "}
              </p>

              <p className="flex text-md px-4 my-2">
                <b>Projection Hall: </b>
                {projectionHallName}
              </p>
              <p className="flex text-md px-4 my-2">
                <b>Projection Type: </b>
                {projectionType}
              </p>
              <p className="flex text-md px-4 my-2">
                <b>Price: </b> {price}$
              </p>
              <p className="flex text-md px-4 my-2">
                <b> Date and time of: </b>
                {dateOfProjection} {timeOfProjection}
              </p>
            </div>
            <button
              onClick={() => {
                navigate("/ticket", {
                  state: { projectionId: projectionId },
                });
              }}
              className="bg-yellow-500 hover:bg-gray-100 text-gray-800 font-semibold py-2 px-4 border border-gray-400 rounded shadow h-fit self-center"
            >
              Buy Ticket
            </button>
          </div>
        </div>
      </div>
    );
  };
  return (
    <div className="w-full">
      <p>aasdsad</p>
      {!isLoading && <ProjectionCard />}
    </div>
  );
}

export default Projection;
