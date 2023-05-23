//const Sequelize = require('sequelize');
module.exports = (sequelize, Sequelize) => {
  const Student = sequelize.define("student", {
    rollno: {
      type: Sequelize.INTEGER,
      allowNull: false,
      unique: true,
    },
    dob: {
      type: Sequelize.DATEONLY,
      allowNull: false,
    },
    name: {
      type: Sequelize.STRING,
      allowNull: false,
    },

    score: {
      type: Sequelize.FLOAT,
      allowNull: false,
    },
  });
  return Student;
};
