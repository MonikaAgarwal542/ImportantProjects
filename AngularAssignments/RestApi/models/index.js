const dbconfig=require('../config/dbconfig.js');
const Sequelize = require('sequelize');
const sequelize = new Sequelize(
    dbconfig.DB,
    dbconfig.USER,
    dbconfig.PASSWORD,{
        host:dbconfig.HOST,
        dialect:dbconfig.dialect,
        operatorsAliases:false,
        pool:{
            max:dbconfig.pool.max,
            min:dbconfig.pool.min,
            acquire:dbconfig.pool.acquire,
            idle:dbconfig.pool.idle
        }
    }
    
)
sequelize.authenticate()
.then(()=>{
    console.log("connected")
})
.catch(err => {
    console.log("error")
})
const db={}
db.Sequelize=Sequelize
db.sequelize=sequelize
db.students=require('./StudentModel.js')(sequelize,Sequelize)
db.sequelize.sync({force:false})
.then(()=>{
    console.log("resync")
})
module.exports=db