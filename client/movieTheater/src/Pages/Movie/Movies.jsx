import { useEffect, useState } from "react";
import { apiGet } from "../../utils/axios";
import { Navigate } from "react-router-dom";
import Movie from "./Movie";
import Search from "../../Components/Search";
function Movies({ currentUser }) {
  const [isLoading, setIsLoading] = useState(false);
  const [movies, setMovies] = useState([]);
  const [searchMovie, setSearchMovie] = useState("");
  const [sortBy, setSortBy] = useState("name");
  const [pageSize, setPageSize] = useState(5);
  const [isAscending, setIsAscending] = useState(true);
  const [pageNumber, setPageNumber] = useState(1);
  const [moviesQuery, setMoviesQuery] = useState("");

  useEffect(() => {
    const getMovies = async () => {
      setIsLoading(true);
      try {
        const response = await apiGet(
          `api/movie${moviesQuery ? `?${moviesQuery}` : ""}`
        );

        setMovies(response);
        setIsLoading(false);
      } catch (error) {
        console.error("Error fetching movies:", error);
        setIsLoading(false);
      }
    };
    getMovies();
  }, [moviesQuery]);

  const handleSubmit = (e) => {
    e.preventDefault();
    setMoviesQuery(
      `name=${searchMovie}&isAscending=${isAscending}&sortBy=${sortBy}&pageNumber=${pageNumber}&pageSize=${pageSize}`
    );
  };
  return (
    <div className="flex flex-col items-center pt-24">
      <form className="w-9/12 mb-36" onSubmit={handleSubmit}>
        <div className="flex">
          <select
            className="flex-shrink-0 z-10 inline-flex items-center py-2.5 px-4 text-sm font-medium text-center text-yellow-900 bg-yellow-100 border border-yellow-300 rounded-s-lg hover:bg-yellow-200 focus:ring-4 focus:outline-none focus:ring-yellow-100 dark:bg-yellow-700 dark:hover:bg-yellow-600 dark:focus:ring-yellow-700 dark:text-white dark:border-yellow-600"
            type="button"
            onChange={(e) => {
              setSortBy(e.target.value);
              console.log(e.target.value);
            }}
          >
            <option value="Name">SortBy</option>
            <option value="Name">Name</option>
            <option value="Duration">Duration</option>
            <option value="YearOfRelease">Year of release</option>
          </select>
          <select
            className="flex-shrink-0 z-10 inline-flex items-center py-2.5 px-4 text-sm font-medium text-center text-yellow-900 bg-yellow-100 border border-yellow-300  hover:bg-yellow-200 focus:ring-4 focus:outline-none focus:ring-yellow-100 dark:bg-yellow-700 dark:hover:bg-yellow-600 dark:focus:ring-yellow-700 dark:text-white dark:border-yellow-600"
            type="button"
            onChange={(e) => setIsAscending(e.target.value)}
          >
            {" "}
            <option value={true}>Order Ascending</option>
            <option value={false}>Order Descending</option>
          </select>
          <select
            name="pageSize"
            className="flex-shrink-0 z-10 inline-flex items-center py-2.5 px-4 text-sm font-medium text-center text-yellow-900 bg-yellow-100 border border-yellow-300  hover:bg-yellow-200 focus:ring-4 focus:outline-none focus:ring-yellow-100 dark:bg-yellow-700 dark:hover:bg-yellow-600 dark:focus:ring-yellow-700 dark:text-white dark:border-yellow-600"
            type="button"
            onChange={(e) => setPageSize(e.target.value)}
          >
            {" "}
            <option>Number of results</option>
            <option value={5}>5</option>
            <option value={10}>10</option>
          </select>

          <div className="relative w-full">
            <input
              type="text"
              className="block p-2.5 w-full z-20 text-sm text-yellow-900 bg-yellow-50 rounded-e-lg border-s-yellow-50 border-s-2 border border-yellow-300 focus:ring-yellow-500 focus:border-yellow-500 dark:bg-yellow-700 dark:border-s-yellow-700  dark:border-yellow-600 dark:placeholder-yellow-400 dark:text-white dark:focus:border-yellow-500"
              placeholder="Search movies"
              required
              onChange={(e) => {
                setSearchMovie(e.target.value);
              }}
            />

            <button
              type="submit"
              className="absolute top-0 end-0 p-2.5 text-sm font-medium h-full text-white bg-yellow-700 rounded-e-lg border border-yellow-700 hover:bg-yellow-800 focus:ring-4 focus:outline-none focus:ring-yellow-300 dark:bg-yellow-600 dark:hover:bg-yellow-700 dark:focus:ring-yellow-800"
            >
              <span>Search</span>
            </button>
          </div>
        </div>
      </form>
      <Movie isLoading={isLoading} movies={movies} />
    </div>
  );
}

export default Movies;
