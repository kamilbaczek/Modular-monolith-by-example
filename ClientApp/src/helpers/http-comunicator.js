import axios from "axios";

export const HTTP = axios.create({
  baseURL: `https://localhost:5001/api`,
});
