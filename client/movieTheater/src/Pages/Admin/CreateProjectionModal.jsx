import { useState } from "react";
import { apiPost } from "../../utils/axios";
function CreateProjectionModal({
  setShowModal,
  movieForProjection,
  projectionData,
  movieId,
}) {
  const [showDropdown, setShowDropdown] = useState([]);
  const [activeBtn, setActiveBtn] = useState(null);
  const [newProjection, setNewProjection] = useState({ movieId: movieId });

  const handleDropdownClick = (itemId) => {
    setShowDropdown((prevShowDropdown) => {
      const updatedDropdown = { ...prevShowDropdown };
      updatedDropdown[itemId] = !updatedDropdown[itemId];
      return updatedDropdown;
    });
  };

  const createProjection = async (e) => {
    e.preventDefault();

    try {
      const response = await apiPost(
        "api/projection/create",
        JSON.stringify(newProjection)
      );

      console.log(response);
      createSeatsByHallCapacity(response.data.id);
    } catch (err) {
      console.log(err);
    }
  };
  const createSeatsByHallCapacity = async (id) => {
    try {
      const response = await apiPost(
        `api/Seat/CreateSeatsByHallCapacity?hallId=${id}`
      );
      console.log(response);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none">
      <div className="relative w-auto my-6 mx-auto max-w-3xl">
        <div className="border-0 rounded-lg shadow-lg relative flex flex-col w-full bg-white outline-none focus:outline-none">
          <div className="flex items-start justify-between p-5 border-b border-solid border-blueGray-200 rounded-t">
            <h3 className="text-3xl font-semibold">
              {movieForProjection.movieName}
            </h3>
            <button
              className="p-1 ml-auto bg-transparent border-0 text-black opacity-5 float-right text-3xl leading-none font-semibold outline-none focus:outline-none"
              onClick={() => setShowModal(false)}
            >
              <span className="bg-transparent text-black opacity-5 h-6 w-6 text-2xl block outline-none focus:outline-none">
                ×
              </span>
            </button>
          </div>
          <div className="flex flex-row justify-around">
            <div className="h-96 w-64">
              <img
                className="object-fit"
                src={movieForProjection.imageFilePath}
                alt={movieForProjection.imageFileName}
              />
            </div>
            <div className=" h-10/12 flex flex-col justify-around">
              <h3>Please select a projeciton hall and type</h3>
              {projectionData.map((ele, i) => {
                return (
                  <>
                    <div
                      key={ele.id}
                      className=" flex flex-row gap-3 border-solid border-gray-900"
                    >
                      <button
                        className="w-fit bg-yellow-500 hover:bg-yellow-600  text-gray-700  font-semibold hover:text-white py-2 px-4 border border-gray-500 hover:border-transparent  h-12  "
                        onClick={() => {
                          setShowDropdown();
                          setNewProjection({
                            ...newProjection,
                            projectionHallId: ele.id,
                          });
                          console.log(newProjection);
                          handleDropdownClick(i);
                        }}
                      >
                        {ele.name}
                      </button>
                      {showDropdown[i] &&
                        ele.projectionTypes.length > 0 &&
                        ele.projectionTypes.map((elem, index) => {
                          return (
                            <button
                              key={index}
                              className={`w-fit bg-red-500 hover:bg-red-600  text-gray-700  font-semibold hover:text-white py-2 px-4 border border-gray-500 hover:border-transparent  h-12 ${
                                index === activeBtn
                                  ? "scale-150 bg-red-500"
                                  : " bg-yellow-500"
                              }  `}
                              onClick={() => {
                                setActiveBtn(index);
                                setNewProjection({
                                  ...newProjection,
                                  projectionTypeId: elem.id,
                                });
                              }}
                            >
                              {elem.type}
                            </button>
                          );
                        })}
                    </div>
                  </>
                );
              })}
              <div>
                {" "}
                <label htmlFor="dateTimeInput">Select a date and time:</label>
                <input
                  type="datetime-local"
                  name="dateTimeInput"
                  required
                  onChange={(e) => {
                    setNewProjection({
                      ...newProjection,
                      dateAndTimeOfProjecton: e.target.value,
                    });
                    console.log(newProjection);
                  }}
                />
              </div>
              <div>
                {" "}
                <label htmlFor="dateTimeInput">Select a price</label>
                <input
                  type="number"
                  name="price"
                  step="0.01"
                  min="1"
                  required
                  className="border border-gray-500 "
                  onChange={(e) => {
                    setNewProjection({
                      ...newProjection,
                      price: e.target.value,
                    });
                    console.log(newProjection);
                  }}
                />
              </div>
            </div>
          </div>
          <div className="relative p-6 flex-auto">
            <p className="my-4 text-blueGray-500 text-lg leading-relaxed">
              {movieForProjection.description}
            </p>
          </div>

          <div className="flex items-center justify-end p-6 border-t border-solid border-blueGray-200 rounded-b">
            <button
              className="text-red-500 background-transparent font-bold uppercase px-6 py-2 text-sm outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
              type="button"
              onClick={() => setShowModal(false)}
            >
              Close
            </button>
            <button
              className="bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
              type="button"
              onClick={(e) => createProjection(e)}
            >
              Save Changes
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default CreateProjectionModal;
