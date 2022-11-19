import React, { Component } from "react";
import { Route } from "react-router";

import { Layout } from "./components/Layout";
import { Routes } from "./components/Routes";
import { checkAcess } from "./components/AuthHandler";

import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  componentDidMount() {
    if (!sessionStorage.getItem("jwt")) {
      this.props.history.push("/login");
    }
  }

  render() {
    return (
      <Layout>
        {Routes.map((route, i) => {
          if (checkAcess(route.access)) {
            return (
              <Route
                key={i}
                exact
                path={route.path}
                component={route.component}
              />
            );
          } else {
            return null;
          }
        })}
      </Layout>
    );
  }
}
