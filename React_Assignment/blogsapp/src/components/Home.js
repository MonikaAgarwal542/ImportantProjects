import React, { useEffect } from "react";

import Blog from "./Blog";
import { MDBRow, MDBCol, MDBContainer, MDBSpinner } from "mdb-react-ui-kit";

import { toast } from "react-toastify";
import { AllBlogs, deleteBlog } from "../redux/features/BlogSlice";

import { useDispatch, useSelector } from "react-redux";

export default function Home() {
  const dispatch = useDispatch();
  const { blog, loading } = useSelector((state) => ({ ...state.app }));

  useEffect(() => {
    dispatch(AllBlogs());
  }, []);

  useEffect(() => {
    console.log("data is ", blog);
    console.log(loading);
  }, [blog]);

  const handleDelete = async (id) => {
    if (window.confirm("Are you sure that you want to delete this blog ?")) {
      console.log("id is ", id);
      dispatch(deleteBlog({ id }));
      toast.success("Blog Deleted Successfully");
      window.location.reload();
    } else {
      alert("Blog not deleted");
    }
  };

  const minimisestring = (str) => {
    if (str.length > 10) {
      str = str.substring(0, 50) + " ... ";
    }
    return str;
  };

  return (
    <>
      <MDBRow>
        <MDBCol>
          <MDBContainer>
            <MDBRow>
              {loading === true ? (
                <MDBSpinner color="success" role="status"></MDBSpinner>
              ) : (
                <>
                  {blog[0] &&
                    blog[0].map((item, index) => (
                      <Blog
                        key={index}
                        {...item}
                        minimisestring={minimisestring}
                        handleDelete={handleDelete}
                      />
                    ))}
                </>
              )}
            </MDBRow>
          </MDBContainer>
        </MDBCol>
      </MDBRow>
    </>
  );
}
