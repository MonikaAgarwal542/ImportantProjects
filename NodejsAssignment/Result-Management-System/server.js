const express = require("express");
const bodyParser = require("body-parser");
const app = express();
const path = require("path");
var hbs = require("hbs");
//configuration
app.use(bodyParser.json());
//app.use(bodyParser.urlencoded({ extended: true }));
app.set("view engine", "hbs");
app.set("views", path.join(__dirname, "views"));
hbs.registerPartials(path.join(__dirname, "views/partials"), (err) => {});
app.use(express.static(__dirname + "/public"));

//SQL Connection
const mysql = require("mysql2");
var mysqlConnection = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "root",
  database: "StudentResultManagement",
});
const db = require("./models");

const studentsdb = db.students;

mysqlConnection.connect((err) => {
  if (!err) console.log("Connected");
  else console.log("Failure");
});
app.listen(8082);

app.get("/", (req, res) => {
  res.render("index");
});
app.get("/search", (req, res) => {
  res.render("search");
});

app.get("/add", (req, res) => {
  res.render("adddetails");
});

app.get("/findresult", (req, res) => {
  mysqlConnection.query(
    "Select * from students where rollno = ? and name = ?",
    [req.query.rollno, req.query.name],
    (err, rows) => {
      if (!err) {
        if (rows.length == 0) {
          res.render("search", { msgF: true });
        } else {
          res.render("result", {
            msg: true,
            msgF: false,
            name: rows[0].name,
            rollno: rows[0].rollno,
            dob:
              rows[0].dob.getFullYear() +
              "-" +
              (rows[0].dob.getMonth() + 1) +
              "-" +
              rows[0].dob.getDate(),
            score: rows[0].score,
            result: rows[0].score >= 33 ? "PASS" : "FAIL",
          });
        }
      } else console.log(err);
    }
  );
});

app.get("/addstudents", (req, res) => {
  msgF = false;
  //console.log("1st line");
  mysqlConnection.query(
    "Select * from students where rollno = ?",
    [req.query.rollno],
    (err, rows) => {
      if (!err) {
        // console.log(err + "inside if ");
        if (rows.length > 0) {
          // console.log("inside 2nd if");
          res.render("AddDetails", { msgF: true });
        } else {
          // console.log("inside else ");
          mysqlConnection.query(
            "Select MAX(id) as maxs from students",
            (err, allrow) => {
              const a = allrow[0].maxs;
              console.log("date is '" + req.query.dob);
              mysqlConnection.query(
                "insert into students values(?,?,?,?,?,?,?)",
                [
                  a + 1,
                  req.query.rollno,
                  req.query.name,
                  req.query.dob,
                  req.query.score,
                  "2004-12-12",
                  "2004-12-12",
                ],
                (er, result) => {
                  console.log(er);
                  if (!er) res.redirect("/alldetails");
                }
              );
            }
          );
        }
      } else console.log(err);
    }
  );
});

app.get("/alldetails", (req, res) => {
  mysqlConnection.query(
    "select * from students order by rollno",
    (err, results) => {
      console.log(results);
      if (err) console.log(err);
      else {
        mysqlConnection.query(
          "select count(*) as c  from students",
          (err, ans) => {
            console.log(ans[0].c);
            console.log(new Date(results[0].dob));
            for (var i = 0; i < ans[0].c; i++) {
              // results[i].dob = new Date(results[i].dob);
              console.log(typeof results[i].dob);
              results[i].dob =
                results[i].dob.getFullYear() +
                "-" +
                (results[i].dob.getMonth() + 1) +
                "-" +
                results[i].dob.getDate();
            }
            // console.log(dob);
            // results.dob = new Date(results.dob);
            res.render("Alldetails", { data: results, c: ans[0].c });
          }
        );
      }
    }
  );
});

app.get("/details/:id", (req, res) => {
  mysqlConnection.query(
    "Select * from students where id = ?",
    [req.params.id],
    (err, rows) => {
      if (!err) res.render("update", { data: rows });
      else console.log(err);
    }
  );
});

//update student
app.get("/updatedetails", (req, res) => {
  mysqlConnection.query(
    "UPDATE students SET name=?, rollno = ?, dob = ?, score = ? WHERE id = ?",
    [
      req.query.name,
      req.query.rollno,
      req.query.dob,
      req.query.score,
      req.query.id,
    ],
    (err, rows) => {
      if (!err) res.redirect("/alldetails");
      else console.log(err);
    }
  );
});

//delete student
app.get("/delete/:id", (req, res) => {
  mysqlConnection.query(
    "Delete from students where id = ?",
    [req.params.id],
    (err, rows) => {
      if (!err) res.redirect("/alldetails");
      else console.log(err);
    }
  );
});
app.get("**", (req, res) => {
  res.render("404Page");
});

console.log("Server is running on the port:- 8082");
