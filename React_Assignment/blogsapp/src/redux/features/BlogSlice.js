import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

export const getBlog = createAsyncThunk("blog/getBlogs", async ({ id }) => {
  return fetch(`http://localhost:8082/blog/${id}`).then((res) => res.json());
});

export const AllBlogs = createAsyncThunk("blog/allBlogs", async () => {
  return fetch(`http://localhost:8082/allblogs`).then((res) => res.json());
});

export const deleteBlog = createAsyncThunk(
  "blog/deleteblog",
  async ({ id }) => {
    return fetch(`http://localhost:8082/${id}`, {
      method: "DELETE",
    }).then((res) => res.json());
  }
);

export const createBlog = createAsyncThunk("blog/addblog", async (values) => {
  return fetch(`http://localhost:8082/addblogs`, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-type": "application/json",
    },
    body: JSON.stringify({
      Title: values.Title,
      Content: values.Content,
      Categories: values.Categories,
      Url: values.Url,
      Date: values.Date,
      Like: values.Like,
      Dislike: values.Dislike,
    }),
  }).then((res) => res.json());
});
export const updateBlog = createAsyncThunk(
  "blog/updateblog",
  async ({ id, Title, Categories, Content, Url, Date }) => {
    return fetch(`http://localhost:8082/editblog/${id}`, {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-type": "application/json",
      },
      body: JSON.stringify({
        Title,
        Content,
        Categories,
        Date,
        Url,
      }),
    }).then((res) => res.json());
  }
);
export const updatelikedislike = createAsyncThunk(
  "blog/updatelikedislike",
  async ({ id, Like, Dislike }) => {
    return fetch(`http://localhost:8082/editblog/${id}`, {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-type": "application/json",
      },
      body: JSON.stringify({
        id,
        Like,
        Dislike,
      }),
    }).then((res) => res.json());
  }
);
const BlogSlice = createSlice({
  name: "blog",
  initialState: {
    loading: false,
    blog: [],
    error: null,
    body: "",
    edit: false,
  },
  reducers: {
    setEdit: (state, action) => {
      state.body = action.payload.body;
      state.edit = action.payload.edit;
    },
  },
  extraReducers: {
    [getBlog.pending]: (state, action) => {
      state.loading = true;
    },
    [getBlog.fulfilled]: (state, action) => {
      state.loading = false;
      state.blog = [action.payload];
    },
    [getBlog.rejected]: (state, action) => {
      state.loading = false;
      state.error = action.payload;
    },
    [deleteBlog.pending]: (state, action) => {
      state.loading = true;
    },
    [deleteBlog.fulfilled]: (state, action) => {
      state.loading = false;
      state.blog = [action.payload];
    },
    [deleteBlog.rejected]: (state, action) => {
      state.loading = false;
      state.error = action.payload;
    },
    [createBlog.pending]: (state, action) => {
      state.loading = true;
    },
    [createBlog.fulfilled]: (state, action) => {
      state.loading = false;
      state.blog = [action.payload];
    },
    [createBlog.rejected]: (state, action) => {
      state.loading = false;
      console.log("hello", action.payload);
      state.error = action.payload;
    },
    [updateBlog.pending]: (state, action) => {
      state.loading = true;
    },
    [updateBlog.fulfilled]: (state, action) => {
      state.loading = false;
      state.blog = [action.payload];
    },
    [updateBlog.rejected]: (state, action) => {
      state.loading = false;
      state.error = action.payload;
    },
    [AllBlogs.pending]: (state, action) => {
      state.loading = true;
    },
    [AllBlogs.fulfilled]: (state, action) => {
      state.loading = false;
      state.blog = [action.payload];
    },
    [AllBlogs.rejected]: (state, action) => {
      state.loading = false;
      state.error = action.payload;
    },
    [updatelikedislike.pending]: (state, action) => {
      state.loading = true;
    },
    [updatelikedislike.fulfilled]: (state, action) => {
      state.loading = false;
      state.blog = [action.payload];
    },
    [updatelikedislike.rejected]: (state, action) => {
      state.loading = false;
      state.error = action.payload;
    },
  },
});

export const { setEdit } = BlogSlice.actions;
export default BlogSlice.reducer;
