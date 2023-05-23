import { MDBBadge } from "mdb-react-ui-kit";
import React, { Component } from "react";
function Badge({ children }) {
  const color = {
    Fashion: "primary",
    Travel: "success",
    Fitness: "warning",
    Food: "warning",
    Tech: "info",
    Sports: "dark",
  };
  return (
    <h5 className="text-center">
      <MDBBadge color={color[children]} className="ms-2">
        {children}
      </MDBBadge>
    </h5>
  );
}

export default Badge;
