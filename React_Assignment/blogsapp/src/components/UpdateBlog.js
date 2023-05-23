import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import "../index.css";
import axios from "axios";
import {
  MDBBtn,
  MDBInput,
  MDBTextArea,
  MDBValidation,
  MDBValidationItem,
} from "mdb-react-ui-kit";
import { useDispatch } from "react-redux";
import { toast } from "react-toastify";
import { updateBlog } from "../redux/features/BlogSlice";
function UpdateBlog() {
  const dispatch = useDispatch();
  // const { blog, loading, edit, body } = useSelector((state) => ({
  //   ...state.app,
  // }));

  const navigate = useNavigate();
  const [categoryerrmsg, setCategoryErrorMsg] = useState(null);
  const [values, setValues] = useState({
    Title: "",
    Content: "",
    Url: "",
    Categories: "",
  });

  const options = [
    "Travel",
    "Fashion",
    "Fitness",
    "Sports",
    "Food",
    "Education",
  ];

  const onInputChange = (event) => {
    setValues({
      ...values,
      [event.target.name]: event.target.value,
    });
  };

  const getDate = () => {
    let today = new Date();
    let dd = String(today.getDate()).padStart(2, "0");
    let mm = String(today.getMonth() + 1).padStart(2, "0");
    let yyyy = today.getFullYear();
    today = mm + "/" + dd + "/" + yyyy;
    console.log("date is ", today);
    return today;
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (!values.Categories) setCategoryErrorMsg("Please provide a Category");
    if (values.Title && values.Categories && values.Url && values.Content) {
      const currdate = getDate();
      const updatedvalues = { ...values, Date: currdate };
      console.log(updatedvalues);
      dispatch(
        updateBlog({
          id: id,
          Title: updatedvalues.Title,
          Content: updatedvalues.Content,
          Categories: updatedvalues.Categories,
          Date: updatedvalues.Date,
          Url: updatedvalues.Url,
        })
      );

      toast.success("Blog updated successfully");

      navigate("/");
      window.location.reload();
    }
  };

  const onCategoryChange = (e) => {
    setCategoryErrorMsg(null);
    setValues({
      ...values,
      Categories: e.target.value,
    });
  };
  const { id } = useParams();
  useEffect(() => {
    if (id) {
      getsingleblog();
    }
  }, [id]);

  const getsingleblog = async () => {
    const response = await axios.get(`http://localhost:8082/blog/${id}`);
    console.log(response);
    setValues({ ...response.data });
    console.log("monika", values);
  };

  return (
    <>
      <div
        style={{
          margin: "auto",
          padding: "5px",
          maxWidth: "400px",
          alignContent: "center",
        }}
      >
        <MDBValidation
          className="row g-3"
          style={{ marginTop: "50px" }}
          noValidate
          onSubmit={handleSubmit}
        >
          <p className="fs-2 fw-bold text-center">Update Blog</p>

          <MDBValidationItem feedback="Please provide a title" invalid>
            <MDBInput
              value={values.Title || ""}
              name="Title"
              type="text"
              onChange={onInputChange}
              required
              label="Title"
            />
          </MDBValidationItem>
          <br />
          <MDBValidationItem feedback="Please provide a Descrption" invalid>
            <MDBTextArea
              value={values.Content || ""}
              name="Content"
              type="text"
              onChange={onInputChange}
              required
              label="Content"
              rows={5}
            />
          </MDBValidationItem>
          <br />
          <MDBValidationItem feedback="Please provide a Url" invalid>
            <MDBInput
              value={values.Url || ""}
              name="Url"
              type="text"
              onChange={onInputChange}
              required
              label="Url"
            />
            <MDBValidationItem />
            <br />
            <select
              className="Categories"
              onChange={onCategoryChange}
              value={values.Categories}
            >
              <option>Please Select category</option>
              {options.map((option, index) => (
                <option value={option || ""} key={index}>
                  {option}
                </option>
              ))}
            </select>
            {categoryerrmsg && (
              <small style={{ color: "#cc0000" }}>{categoryerrmsg}</small>
            )}
            <br />
            <br />
            <MDBBtn type="submit" className="btn btn-secondary">
              Update
            </MDBBtn>
            <MDBBtn type="reset" className="btn btn-danger mx-4">
              Clear
            </MDBBtn>
          </MDBValidationItem>
        </MDBValidation>
      </div>
    </>
  );
}

export default UpdateBlog;
