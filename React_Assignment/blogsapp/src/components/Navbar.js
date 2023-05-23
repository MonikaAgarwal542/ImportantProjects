import React, { useState } from "react";

import {
  MDBNavbar,
  MDBContainer,
  MDBIcon,
  MDBNavbarNav,
  MDBNavbarItem,
  MDBNavbarLink,
  MDBNavbarToggler,
  MDBNavbarBrand,
  MDBCollapse,
} from "mdb-react-ui-kit";
function Navbar() {
  const [show, setShow] = useState(false);

  return (
    <MDBNavbar expand="lg" className="p-3 bg-info">
      <MDBContainer fluid>
        <MDBNavbarBrand href="#" className="mx-4" style={{ color: "white" }} h3>
          <img
            src="https://cdn.pixabay.com/photo/2015/01/21/13/20/blog-606684_960_720.png"
            style={{ height: "auto", width: "7rem" }}
          ></img>
        </MDBNavbarBrand>
        <MDBNavbarToggler
          type="button"
          data-target="#navbarColor02"
          aria-controls="navbarColor02"
          aria-expanded="false"
          aria-label="Toggle navigation"
          onClick={() => setShow(!show)}
        >
          <MDBIcon icon="bars" fas />
        </MDBNavbarToggler>
        <MDBCollapse navbar show={show}>
          <MDBNavbarNav
            right
            fullWidth={false}
            className="mb-auto mb-2 mb-lg-0"
          >
            <MDBNavbarItem className="active h5">
              <MDBNavbarLink
                aria-current="page"
                style={{ color: "white" }}
                href="/"
              >
                Home
              </MDBNavbarLink>
            </MDBNavbarItem>
            <MDBNavbarItem className="h5">
              <MDBNavbarLink href="/AddBlog" style={{ color: "white" }}>
                AddBlogs
              </MDBNavbarLink>
            </MDBNavbarItem>

            <MDBNavbarItem className="h5">
              <MDBNavbarLink href="/About" style={{ color: "white" }}>
                About
              </MDBNavbarLink>
            </MDBNavbarItem>
          </MDBNavbarNav>
        </MDBCollapse>
      </MDBContainer>
    </MDBNavbar>
  );
}

export default Navbar;
