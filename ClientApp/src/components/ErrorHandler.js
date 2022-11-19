export default function ErrorHandler(error) {
  console.log(error);
  if (error.response) {
    if (
      error.response.Status === 401 ||
      JSON.stringify(error).includes("Request failed with status code 401")
    ) {
      return 401;
    }
    if (
      error.response.Status === 400 ||
      JSON.stringify(error).includes("Request failed with status code 400")
    ) {
      return 400;
    }
    if (error.response.data) {
      return error.response.data.error;
    }
    if (error.response.data.error_description) {
      return error.response.data.error_description;
    }
    return "Bad Request";
  } else {
    if (error.message) {
      return error.message;
    }
    return "Bad Request";
  }
}
