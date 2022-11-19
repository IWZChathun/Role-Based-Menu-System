import Home from "../Pages/Home";
import AdminOnly from "../Pages/AdminOnly";
import UserOnly from "../Pages/UserOnly";

export const Routes = [
  {
    name: "Home",
    path: "/pages/home",
    access: "Home",
    component: Home,
  },
  {
    name: "Admin Only",
    path: "/pages/adminonly",
    access: "AdminOnly",
    component: AdminOnly,
  },
  {
    name: "User Only",
    path: "/pages/useronly",
    access: "UserOnly",
    component: UserOnly,
  },
];
