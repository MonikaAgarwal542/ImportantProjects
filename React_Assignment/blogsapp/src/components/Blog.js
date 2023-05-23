import {
  MDBCardFooter,
  MDBCol,
  MDBCardBody,
  MDBCardImage,
  MDBCard,
  MDBCardTitle,
  MDBCardText,
  MDBBtn,
  MDBIcon,
} from "mdb-react-ui-kit";

import React from "react";
import { Link } from "react-router-dom";
import Badge from "./Badge";
function Blog({
  Title,
  Content,
  Categories,
  Date,
  Url,
  id,
  minimisestring,
  handleDelete,
}) {
  return (
    <MDBCol size="4" className="mb-4 mt-5">
      <MDBCard className=" h-100" style={{ maxWidth: "65rem" }}>
        <MDBCardImage
          src={Url}
          position="top"
          alt="..."
          style={{ width: "auto", height: "15rem" }}
        />
        <hr />
        <MDBCardBody>
          <MDBCardTitle>{Title}</MDBCardTitle>
          <MDBCardText>
            {minimisestring(Content)}

            <Link to={`/blog/${id}`}>read more</Link>
          </MDBCardText>
          <Badge>{Categories}</Badge>
          <span style={{ display: "flex", justifyContent: "center" }}>
            <MDBBtn
              className="mt-1 mx-4"
              tag="a"
              color="none"
              onClick={() => handleDelete(id)}
            >
              <MDBIcon
                fas
                icon="trash"
                style={{ color: "#dd4b39" }}
                size="xl"
              />
            </MDBBtn>

            <Link to={`/editblog/${id}`}>
              <MDBIcon fas icon="edit" style={{ color: "#55acee" }} size="xl" />
            </Link>
          </span>
        </MDBCardBody>
        <MDBCardFooter
          className="text-muted"
          style={{ backgroundColor: "lightgrey" }}
        >
          Last Updated On {Date}
        </MDBCardFooter>
      </MDBCard>
    </MDBCol>
  );
}

export default Blog;
