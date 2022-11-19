import "bootstrap/dist/css/bootstrap.css";

import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";

import App from "./App";
import Login from "./Pages/Login";

import registerServiceWorker from "./registerServiceWorker";
import setAuthorizationToken from "./components/AuthHandler";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

setAuthorizationToken(sessionStorage.getItem("jwt"));

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <Switch>
      <Route path="/login" component={Login} />
      <Route path="/pages" component={App} />
      <Redirect from="/" to="/pages/home" />
    </Switch>
  </BrowserRouter>,
  rootElement
);

registerServiceWorker();
