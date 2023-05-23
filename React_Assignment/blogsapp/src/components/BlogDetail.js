import React, { useEffect } from "react";
import { MDBSpinner } from "mdb-react-ui-kit";
import { useSelector, useDispatch } from "react-redux";

import Container from "react-bootstrap/esm/Container";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Card from "react-bootstrap/Card";
import ThumbUpIcon from "@mui/icons-material/ThumbUp";
import ThumbDownIcon from "@mui/icons-material/ThumbDown";
import { updatelikedislike } from "../redux/features/BlogSlice";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";

import { getBlog } from "../redux/features/BlogSlice";
const BlogDetail = () => {
  const dispatch = useDispatch();
  const { blog, loading } = useSelector((state) => ({ ...state.app }));

  const navigate = useNavigate();
  const { id } = useParams();

  const handleLikes = () => {
    let like = blog[0].Like;
    let dislike = blog[0].Dislike;
    dispatch(
      updatelikedislike({
        id: id,
        Like: ++like,
        Dislike: dislike,
      })
    );

    dispatch(getBlog({ id }));

    navigate(`/blog/${id}`);
  };
  const handleDislikes = () => {
    let like = blog[0].Like;
    let dislike = blog[0].Dislike;
    dispatch(
      updatelikedislike({
        id: id,
        Like: like,
        Dislike: ++dislike,
      })
    );

    dispatch(getBlog({ id }));
    navigate(`/blog/${id}`);
  };

  useEffect(() => {
    dispatch(getBlog({ id }));
  }, []);
  useEffect(() => {}, [blog]);

  return (
    <>
      <div>
        {loading === true ? (
          <MDBSpinner color="success" role="status"></MDBSpinner>
        ) : (
          <>
            <Container className="pt-4">
              <Row>
                <Col xs md="12">
                  <Card>
                    <Card.Header className="bg-warning h3">
                      {blog[0].Title}
                      <span>
                        <button
                          className="btn btn-primary"
                          style={{ position: "absolute", right: 100 }}
                          onClick={handleLikes}
                        >
                          <ThumbUpIcon></ThumbUpIcon>
                          <b>{blog[0].Like}</b>
                        </button>
                        <button
                          type="button"
                          className="btn btn-danger"
                          style={{ position: "absolute", right: 5 }}
                          onClick={handleDislikes}
                        >
                          <ThumbDownIcon></ThumbDownIcon>{" "}
                          <b>{blog[0].Dislike}</b>
                        </button>
                      </span>
                    </Card.Header>
                    <Card.Body className="text-dark">
                      <img
                        src={blog[0] && blog[0].Url}
                        style={{ width: "100%", height: "580px" }}
                      />
                      <br />
                      <br />
                      <Card.Text className="text-dark">
                        {blog[0].Content}
                      </Card.Text>
                    </Card.Body>
                    <Card.Footer className="h6">
                      <p>
                        Last Updated :-
                        <b className="text-warning">{blog[0].Date}</b>
                      </p>
                    </Card.Footer>
                  </Card>
                </Col>
              </Row>
            </Container>
          </>
        )}
      </div>
    </>
  );
};

export default BlogDetail;
