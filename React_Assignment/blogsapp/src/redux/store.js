import { configureStore } from "@reduxjs/toolkit";
import BlogSlice from "./features/BlogSlice";
export default configureStore({
  reducer: {
    app: BlogSlice,
  },
});
