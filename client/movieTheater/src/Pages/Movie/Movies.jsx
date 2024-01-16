import { useEffect, useState } from "react";
import { apiGet } from "../../utils/axios";
import { Navigate } from "react-router-dom";
import Movie from "./Movie";
function Movies({ currentUser, checkUser }) {
  const [isLoading, setIsLoading] = useState(false);
  const [movies, setMovies] = useState([]);

  if (!currentUser) {
    return <Navigate to="/login" />;
  }
  useEffect(() => {
    checkUser();
  }, []);

  useEffect(() => {
    const getMovies = async () => {
      setIsLoading(true);
      try {
        const response = await apiGet("api/Movie?pageNumber=1&pageSize=1000");

        setMovies(response);
        setIsLoading(false);
      } catch (error) {
        console.error("Error fetching movies:", error);
        setIsLoading(false);
      }
    };
    getMovies();
  }, []);

  return (
    <div>
      <Movie isLoading={isLoading} movies={movies} />
    </div>
  );
}

export default Movies;