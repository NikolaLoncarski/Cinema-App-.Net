import { useState, useEffect } from "react";
import { apiGet, apiPost } from "../../utils/axios";

function CreateMovie() {
  const [isLoading, setIsLoading] = useState(false);
  const [allImages, setAllImages] = useState([]);
  const [movieData, setMovieData] = useState({});
  const handleChange = (e) => {
    const { name, value } = e.target;
    setMovieData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };
  const currentYear = new Date().getFullYear();
  const getImages = async (e) => {
    setIsLoading(true);
    try {
      const response = await apiGet("api/GetImages");
      setAllImages(response);
      setIsLoading(false);
      console.log(response);
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    getImages();
  }, []);

  const createMovie = async (e) => {
    e.preventDefault();
    console.log(movieData);
    try {
      const response = await apiPost(
        "api/movie/create",
        JSON.stringify(movieData)
      );
      console.log(response);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className=" container flex  h-screen mx-auto">
      <form className="max-w-sm m-auto shadow-md " onSubmit={createMovie}>
        <div className="bg-yellow-500 font-semibold text-2xl p-2 text-center">
          Create A Movie
        </div>
        <div className="p-8">
          <label htmlFor="email" className="">
            Movie Name
          </label>
          <input
            type="text"
            name="name"
            className="w-full px-3 py-2 mt-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            placeholder="Movie Name"
            onChange={handleChange}
          />
          <label htmlFor="text" className="">
            Director
          </label>
          <input
            type="text"
            name="director"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={handleChange}
          />
          <label htmlFor="text" className="">
            Lead Actor
          </label>
          <input
            type="text"
            name="leadActor"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={handleChange}
          />
          <label htmlFor="text" className="">
            Genre
          </label>
          <input
            type="text"
            name="genre"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={handleChange}
          />

          <label htmlFor="text" className="">
            Duration
          </label>
          <input
            type="number"
            step="1"
            min="1"
            name="duration"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={(e) => {
              setMovieData((prevData) => ({
                ...prevData,
                duration: e.target.value,
              }));
            }}
          />
          <label htmlFor="text" className="">
            Distributer
          </label>
          <input
            type="text"
            name="distributer"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={handleChange}
          />
          <label htmlFor="text" className="">
            Country of Origin
          </label>
          <input
            type="text"
            name="countryOfOrigin"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={handleChange}
          />
          <label htmlFor="yearOfRelease" className="">
            Year of Release
          </label>
          <input
            type="number"
            name="yearOfRelease"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={handleChange}
            min="1913"
            max={currentYear}
          />
          <label htmlFor="text" className="">
            Description
          </label>
          <input
            type="text"
            name="description"
            className="w-full px-3 py-2 mb-3 leading-tight text-gray-700 border rounded focus:border-sky-500 focus:outline-none"
            onChange={handleChange}
          />
          <button
            type="submit"
            className="w-full p-2 text-white bg-yellow-500 rounded-lg"
          >
            Create Movie
          </button>
        </div>
      </form>
      <div className="max-w-sm m-auto shadow-md h-1/2 flex items-center justify-center overflow-scroll flex-col overflow-x-hidden">
        <h3>Chose a Picture</h3>
        {!isLoading &&
          allImages.length > 0 &&
          allImages.map((element) => {
            const {
              id,
              file,
              fileName,

              filePath,
            } = element;

            return (
              ///---///
              <div key={id} className="hover:scale-125 ">
                <h3>{fileName}</h3>
                <img
                  onClick={() => {
                    setMovieData((prevData) => ({
                      ...prevData,
                      imageId: element.id,
                    }));
                  }}
                  className="w-48 h-48 object-contain"
                  src={filePath}
                  alt={fileName}
                />
              </div>
            );
          })}
      </div>
    </div>
  );
}

export default CreateMovie;
