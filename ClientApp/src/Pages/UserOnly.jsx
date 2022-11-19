import React, { Component } from "react";
import ApiService from "../ApiService";

class UserOnly extends Component {
  constructor(props) {
    super(props);

    this.state = {
      message: "",
    };

    this.service = new ApiService();
  }

  componentDidMount() {
    this.loadData();
  }

  loadData = async () => {
    const result = await this.service.getUserOnly();
    if (result.status === "success") {
      this.setState({ message: result.message });
    } else {
      if (result === 401) {
        this.props.history.push("login");
      }
    }
  };

  render() {
    return (
      <div>
        <h2>{this.state.message}</h2>
      </div>
    );
  }
}

export default UserOnly;
