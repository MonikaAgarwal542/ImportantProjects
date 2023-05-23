const blogcontroller = require("../controllers/BlogController.js");
const router = require("express").Router();
router.get("/", blogcontroller.start);
router.post("/addblogs", blogcontroller.addBlog);
router.get("/allblogs", blogcontroller.getAllBlogs);
router.get("/blog/:id", blogcontroller.getOneBlog);
router.delete("/:id", blogcontroller.deleteBlog);
router.put("/editblog/:id", blogcontroller.updateBlog);

module.exports = router;
