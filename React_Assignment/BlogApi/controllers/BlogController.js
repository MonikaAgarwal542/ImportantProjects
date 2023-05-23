const db = require("../models");

const Blogs = db.Blogs;
const start = async (req, res) => {
  res.status(200).send("msg printed");
};
const addBlog = async (req, res) => {
  try {
    let info = {
      Title: req.body.Title,
      Content: req.body.Content,
      Url: req.body.Url,
      Categories: req.body.Categories,
      Date: req.body.Date,
      Like: req.body.Like,
      Dislike: req.body.Dislike,
    };

    const blogs = await Blogs.create(info);
    res.send(blogs);
  } catch (err) {
    console.log(err);
  }
};

const getAllBlogs = async (req, res) => {
  let blogs = await Blogs.findAll({});
  res.status(200).send(blogs);
};

const getOneBlog = async (req, res) => {
  let id = req.params.id;

  let blogs = await Blogs.findOne({ where: { id: id } });
  res.status(200).send(blogs);
};

const updateBlog = async (req, res) => {
  let id = req.params.id;
  let blogs = await Blogs.update(req.body, { where: { id: id } });
  res.send(blogs);
};

const deleteBlog = async (req, res) => {
  let id = req.params.id;
  Blogs.destroy({ where: { id: id } })
    .then((num) => {
      if (num == 1) {
        res.send({ message: true });
      } else {
        res.send({ message: false });
      }
    })
    .catch((err) => {
      res.status(500).send({ message: false });
    });
};

module.exports = {
  addBlog,
  getAllBlogs,
  getOneBlog,
  updateBlog,
  deleteBlog,
  start,
};
