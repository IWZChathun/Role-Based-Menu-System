import React, { Component } from "react";

import ApiService from "../ApiService";
import setAuthorizationToken, { decodeJwt } from "../components/AuthHandler";

class Login extends Component {
  constructor(props) {
    super(props);

    this.state = {
      loading: false,
      username: "",
      password: "",
    };

    this.service = new ApiService();
  }

  componentDidMount() {
    sessionStorage.clear();
  }

  onChange = (event) => {
    let temp = Object.assign({}, this.state);
    temp[event.target.name] = event.target.value;
    this.setState(temp);
  };

  handleSubmit = async (e) => {
    e.preventDefault();
    const result = await this.service.login(this.state);
    if (result.status === "success") {
      sessionStorage.setItem("jwt", result.token);
      setAuthorizationToken(result.token);
      decodeJwt(result.token);
      this.props.history.push("home");
    } else {
      this.setState({ message: "Username or Password Incorrect!" });
    }
  };

  render() {
    return (
      <div className="login-container">
        <form onSubmit={this.handleSubmit}>
          <h4>Role Based Menu System</h4>
          <div className="field">
            <label className="block" htmlFor="username">
              Username
            </label>
            <input
              required
              id="username"
              name="username"
              autoComplete="off"
              onChange={this.onChange}
            />
          </div>
          <div className="field">
            <label htmlFor="password">Password</label>
            <input
              required
              type="password"
              id="password"
              name="password"
              autoComplete="off"
              onChange={this.onChange}
            />
          </div>
          <div className="field">
            <button type="submit" label="Login" className="btn-primary">
              Login
            </button>
          </div>
          <div className="field">
            <label htmlFor="message">{this.state.message}</label>
          </div>
        </form>
      </div>
    );
  }
}

export default Login;
