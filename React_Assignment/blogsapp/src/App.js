import { Routes, Route, BrowserRouter } from "react-router-dom";
import AddBlog from "./components/AddBlog";
import Navbar from "./components/Navbar";
import BlogDetail from "./components/BlogDetail";
import Home from "./components/Home";
import ErrorPage from "./components/ErrorPage";
import About from "./components/About";
import Footer from "./components/Footer";
import UpdateBlog from "./components/UpdateBlog";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
function App() {
  return (
    <>
      <BrowserRouter>
        <div className="App">
          <ToastContainer />
          <Navbar />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/AddBlog" element={<AddBlog />} />
            <Route path="/blog/:id" element={<BlogDetail />} />
            <Route path="/editblog/:id" element={<UpdateBlog />} />
            <Route path="/About" element={<About />} />
            <Route path="*" element={<ErrorPage />} />
          </Routes>
          {/* <Footer /> */}
        </div>
      </BrowserRouter>
    </>
  );
}

export default App;
