
//const Sequelize = require('sequelize');
module.exports = (sequelize,Sequelize) =>{
    const Student = sequelize.define("student",{
        Rollno : {
            type:Sequelize.INTEGER,
            allowNull:false
        },
        Name : {
            type:Sequelize.STRING,
            allowNull:false
        },
        Dob : {
            type:Sequelize.DATEONLY,
            allowNull:false
        },
        Score : {
            type:Sequelize.FLOAT,
            allowNull:false
        }

    })
    return Student
}
