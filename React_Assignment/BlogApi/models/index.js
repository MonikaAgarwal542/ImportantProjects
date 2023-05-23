const dbconfig = require("../config/dbconfig.js");
const Sequelize = require("sequelize");
const sequelize = new Sequelize(dbconfig.DB, dbconfig.USER, dbconfig.PASSWORD, {
  host: dbconfig.HOST,
  dialect: dbconfig.dialect,
  operatorsAliases: false,
});
sequelize
  .authenticate()
  .then(() => {
    console.log("connected");
  })
  .catch((err) => {
    console.log("error");
  });
const db = {};
db.Sequelize = Sequelize;
db.sequelize = sequelize;
db.Blogs = require("./BlogModel.js")(sequelize, Sequelize);

db.sequelize.sync({ force: false }).then(() => {
  console.log("resync");
});
module.exports = db;
