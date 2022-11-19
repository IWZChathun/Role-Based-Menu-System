import axios from "axios";
import ErrorHandler from "./components/ErrorHandler";

export default class ApiService {
  login = (data) => {
    return new Promise((resolve) => {
      axios
        .post(`api/login`, data)
        .then((result) => {
          resolve(result.data);
        })
        .catch((error) => {
          resolve(ErrorHandler(error));
        });
    });
  };

  getHome = () => {
    return new Promise((resolve) => {
      axios
        .get(`api/home`)
        .then((result) => {
          resolve(result.data);
        })
        .catch((error) => {
          resolve(ErrorHandler(error));
        });
    });
  };

  getAdminOnly = () => {
    return new Promise((resolve) => {
      axios
        .get(`api/adminonly`)
        .then((result) => {
          resolve(result.data);
        })
        .catch((error) => {
          resolve(ErrorHandler(error));
        });
    });
  };

  getUserOnly = () => {
    return new Promise((resolve) => {
      axios
        .get(`api/useronly`)
        .then((result) => {
          resolve(result.data);
        })
        .catch((error) => {
          resolve(ErrorHandler(error));
        });
    });
  };
}
