import React from "react";
import { useNavigate } from "react-router-dom";
function AdminMenu() {
  const navigate = useNavigate();
  return (
    <div className="grid md:grid-cols-3  container  h-screen mx-auto  grid-cols-1">
      <div
        onClick={() => navigate("/image-upload")}
        className="relative gap-12 md:gap-0 flex justify-center items-center self-center md:flex-row flex-col mt-6   text-gray-700 bg-white shadow-2xl bg-clip-border  rounded-xl m-16  hover:scale-125 cursor-pointer duration-300 ease-in h-36"
      >
        <h3>Upload Image </h3>
      </div>
      <div
        onClick={() => navigate("/create-movie")}
        className="relative gap-12 md:gap-0 flex md:flex-row flex-col mt-6  justify-center items-center self-center text-gray-700 bg-white shadow-2xl bg-clip-border  rounded-xl m-16 hover:scale-125 cursor-pointer duration-300 ease-in  h-36"
      >
        <h3>Create Movie </h3>
      </div>
      <div
        onClick={() => navigate("/create-projection")}
        className="relative gap-12 md:gap-0 flex md:flex-row flex-col mt-6  justify-center items-center self-center text-gray-700 bg-white shadow-2xl bg-clip-border  rounded-xl m-16 hover:scale-125 cursor-pointer duration-300 ease-in  h-36"
      >
        <h3>Create Projections </h3>
      </div>
      <div
        onClick={() => navigate("/statistics")}
        className="relative gap-12 md:gap-0 flex md:flex-row flex-col mt-6 justify-center items-center self-center  text-gray-700 bg-white shadow-2xl bg-clip-border  rounded-xl m-16 hover:scale-125 cursor-pointer duration-300 ease-in  h-36"
      >
        <h3>Statistics </h3>
      </div>
    </div>
  );
}

export default AdminMenu;
