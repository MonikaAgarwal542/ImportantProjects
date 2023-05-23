const express=require('express')
const bodyParser = require("body-parser");
const cors=require('cors')
const app=express()

app.use(cors({

    origin : "*",
  
  }));
  app.use(bodyParser.json());

app.use(bodyParser.urlencoded({extended:true}))

const router = require('./routes/StudentRoutes.js')
app.use('/',router)



app.listen(8082)



console.log("Server is running on the port:- 8083")
