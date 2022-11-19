import React, { Component } from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";

import "./NavMenu.css";

import { Routes } from "./Routes";
import { checkAcess } from "./AuthHandler";

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
            <NavbarBrand tag={Link} to="/">
              RBMS
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={!this.state.collapsed}
              navbar
            >
              <ul className="navbar-nav flex-grow">
                {Routes.map((route, i) => {
                  if (checkAcess(route.access)) {
                    return (
                      <NavItem>
                        <NavLink
                          key={i}
                          tag={Link}
                          className="text-dark"
                          to={route.path}
                        >
                          {route.name}
                        </NavLink>
                      </NavItem>
                    );
                  } else {
                    return null;
                  }
                })}
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/login">
                    Logout
                  </NavLink>
                </NavItem>
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
