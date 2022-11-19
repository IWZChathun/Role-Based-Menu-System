import axios from "axios";

export default function setAuthorizationToken(token) {
  if (token) {
    axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
    axios.defaults.headers.common["Accept"] = `application/json`;
  } else {
    delete axios.defaults.headers.common["Authorization"];
  }
}

export function checkAcess(module) {
  if (sessionStorage.getItem("access")) {
    const acesss = sessionStorage.getItem("access").split(";");
    return acesss.includes(module);
  }
  return [];
}

function setLocalStorage(result) {
  console.log(result);
  sessionStorage.setItem(
    "name",
    result["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"]
  );
  sessionStorage.setItem(
    "username",
    result[
      "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname"
    ]
  );
  sessionStorage.setItem(
    "role",
    result["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
  );
  sessionStorage.setItem("access", result.access);
}

export function decodeJwt(token) {
  const base64Url = token.split(".")[1];
  const base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
  const payload = decodeURIComponent(
    atob(base64)
      .split("")
      .map(function (c) {
        return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
      })
      .join("")
  );

  setLocalStorage(JSON.parse(payload));
}
