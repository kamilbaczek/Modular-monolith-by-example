import axios from "axios";
import {authHeader} from './authservice/auth-header';

export const anonymousHttpClient = axios.create({
  baseURL: 'https://localhost:5001/api/',
  timeout: 1000,
});


const authenticatedHttpClient = axios.create({
  baseURL: 'https://localhost:5001/api/',
  timeout: 1000,
  headers: authHeader()
});

export default authenticatedHttpClient;