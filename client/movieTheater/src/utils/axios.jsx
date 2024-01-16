import axios from "axios";

const axiosInstance = axios.create();
const serverURL = "https://localhost:7029/";

export const apiGet = async (api) => {
  const headers = {
    "Content-Type": "application/json",
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`,
  };
  console.log(headers);
  const res = await axiosInstance.get(`${serverURL}${api}`, {
    headers,
  });

  return res.data;
};

export const apiPost = async (api, body) => {
  const headers = {
    "Content-Type": "application/json",
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`,
  };
  const res = await axiosInstance.post(`${serverURL}${api}`, body, {
    headers,
  });
  console.log(res);
  return res;
};

export const apiPostFormData = async (api, body) => {
  const headers = {
    "Content-Type": "multipart/form-data",
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`,
  };
  const res = await axiosInstance.post(`${serverURL}${api}`, body, {
    headers,
  });
  return res.data;
};

export const apiPostFile = async (api, body) => {
  const headers = {
    "Content-Type": "multipart/form-data",
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`,
  };
  const res = await axiosInstance.post(`${serverURL}${api}`, body, {
    headers,
  });
  return res.data;
};

export const apiPut = async (api, body) => {
  const headers = {
    "Content-Type": "application/json",
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`,
  };
  const res = await axiosInstance.put(`${serverURL}${api}`, body, {
    headers,
  });
  return res.data;
};

export const apiPatch = async (api, body) => {
  const headers = {
    "Content-Type": "application/json",
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`,
  };
  const res = await axiosInstance.patch(`${serverURL}${api}`, body, {
    headers,
  });
  return res.data;
};

export const apiPatchFormData = async (api, body) => {
  const headers = {
    "Content-Type": "multipart/form-data",
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`,
  };
  const res = await axiosInstance.patch(`${serverURL}${api}`, body, {
    headers,
  });
  return res.data;
};

export const apiDelete = async (api) => {
  const headers = {
    "Content-Type": "application/json",
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`,
  };
  const res = await axiosInstance.delete(`${serverURL}${api}`, {
    headers,
  });
  return res;
};
export const apiDeleteTicket = async (api, body) => {
  const headers = {
    "Content-Type": "application/json",
    Authorization: `Bearer ${JSON.parse(localStorage.getItem("token"))}`,
  };
  const res = await axiosInstance.put(`${serverURL}${api}`, body, {
    headers,
  });
  return res.data;
};


export default axiosInstance;
