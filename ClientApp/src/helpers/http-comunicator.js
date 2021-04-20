import axios from "axios";

export const HTTP = axios.create({
  baseURL: `https://localhost:5001/api`,
});

export default axios.create({
  baseURL: "http://localhost:8080/api",
  headers: {
    "Content-Type": "application/json",
  },
});