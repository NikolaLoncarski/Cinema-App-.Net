import { useState, useEffect } from "react";
import { apiGet } from "../../utils/axios";
import CreateProjectionModal from "./CreateProjectionModal";

function CreateProjection() {
  const [movieData, setMovieData] = useState(null);
  const [projectionData, setProjectionData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [showModal, setShowModal] = useState(false);
  const [moviForProjeciton, setMovieForProjection] = useState();
  const [movieId, setMovieId] = useState(null);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const moviesUrl = "api/Movie/?pageSize=60";
        const projectionsUrl = "api/ProjectionHall";

        const [response1, response2] = await Promise.all([
          apiGet(moviesUrl),
          apiGet(projectionsUrl),
        ]);

        setMovieData(response1);
        setProjectionData(response2);
      } catch (error) {
        console.error("Error fetching data:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="container mx-auto mt-24 grid xl:grid-cols-4 md:grid-cols-3 sm:grid-cols-1 gap-8">
      {!loading &&
        movieData.length > 0 &&
        movieData.map((ele, i) => {
          return (
            <div
              className="relative gap-12 md:gap-0 flex  flex-col items-center content-center mt-6  text-gray-700 bg-white shadow-2xl bg-clip-border  rounded-xl hover:bg-yellow-300 hover:scale-105 cursor-pointer hover:transition-colors hover:duration-300 hover:ease-in "
              key={ele.id}
              onClick={() => {
                setMovieForProjection(ele);
                setShowModal(true);
                setMovieId(ele.id);
              }}
            >
              <h3>
                {" "}
                <b>{ele.movieName}</b>
              </h3>
              <div className="h-96 w-64">
                <img
                  className="object-fit"
                  src={ele.imageFilePath}
                  alt={ele.imageFileName}
                />
              </div>
            </div>
          );
        })}
      {showModal && (
        <CreateProjectionModal
          setShowModal={setShowModal}
          movieForProjection={moviForProjeciton}
          projectionData={projectionData}
          movieId={movieId}
        />
      )}
    </div>
  );
}

export default CreateProjection;
