import { useState, useEffect } from "react";
import { apiGet } from "../../utils/axios";
function Statistics() {
  const [isLoading, setIsLoading] = useState(false);
  const [movieStats, setMovieStats] = useState([]);
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
          `api/Movie/Statistics${moviesQuery ? `?${moviesQuery}` : ""}`
        );

        setMovieStats(response);
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
      <table className="w-full text-sm text-left rtl:text-right text-gray-100 dark:text-gray-200">
        <thead className="text-xs text-yellow-700 uppercase bg-gray-50 dark:bg-yellow-500 dark:text-gray-900">
          <tr>
            <th scope="col" className="px-6 py-3">
              Movie Id
            </th>
            <th scope="col" className="px-6 py-3">
              Name
            </th>
            <th scope="col" className="px-6 py-3">
              Total Earned{" "}
            </th>
            <th scope="col" className="px-6 py-3">
              Number Of Projections{" "}
            </th>
            <th scope="col" className="px-6 py-3">
              Total Tickets Sold{" "}
            </th>
            <th scope="col" className="px-6 py-3">
              Total Seats{" "}
            </th>
            <th scope="col" className="px-6 py-3">
              Average Ticket Price{" "}
            </th>
            <th scope="col" className="px-6 py-3">
              %Seats Occupied{" "}
            </th>
          </tr>
        </thead>
        <tbody className="odd:bg-white odd:dark:bg-yellow-900 even:bg-yellow-50 even:dark:bg-yellow-800 border-b dark:border-gray-700">
          {!isLoading &&
            movieStats.length > 0 &&
            movieStats.map((e, i) => {
              const {
                movieId,
                movieName,
                totalEarned,
                numberOfProjections,
                numberOfTicketsSold,
                totalNumberOfSeats,
                averageTicketPrice,
                percentageOfSeatsOcupied,
              } = e;

              return (
                <tr
                  className="odd:bg-white odd:dark:bg-yellow-900 even:bg-gray-50 even:dark:bg-yellow-800 border-b dark:border-yellow-700"
                  key={i}
                >
                  <td className="px-6 py-4">{movieId}</td>
                  <td className="px-6 py-4">{movieName}</td>
                  <td className="px-6 py-4">{totalEarned}</td>
                  <td className="px-6 py-4">{numberOfProjections}</td>
                  <td className="px-6 py-4">{numberOfTicketsSold}</td>
                  <td className="px-6 py-4">{totalNumberOfSeats}</td>
                  <td className="px-6 py-4">{averageTicketPrice}</td>
                  <td className="px-6 py-4">% {percentageOfSeatsOcupied}</td>
                </tr>
              );
            })}
        </tbody>
      </table>
      <div className="flex mt-4 mb-24 ">
        {pageNumber > 1 ? (
          <button
            onClick={(e) => {
              setPageNumber(pageNumber - 1);
              handleSubmit(e);
            }}
            className=" z-50 flex items-center justify-center px-4 h-10 ms-3 text-base font-medium text-gray-500 bg-white border border-gray-300 rounded-lg hover:bg-gray-100 hover:text-yellow-700 dark:bg-yellow-800 dark:border-yellow-700 dark:text-yellow-400 dark:hover:bg-yellow-700 dark:hover:text-white"
          >
            Previous
          </button>
        ) : null}
        {movieStats.length < pageSize ? null : (
          <button
            onClick={(e) => {
              setPageNumber(pageNumber + 1);
              handleSubmit(e);
            }}
            className=" z-50 flex items-center justify-center px-4 h-10 ms-3 text-base font-medium text-gray-500 bg-white border border-gray-300 rounded-lg hover:bg-gray-100 hover:text-yellow-700 dark:bg-yellow-800 dark:border-yellow-700 dark:text-yellow-400 dark:hover:bg-yellow-700 dark:hover:text-white"
          >
            Next
          </button>
        )}
      </div>
    </div>
  );
}

export default Statistics;
