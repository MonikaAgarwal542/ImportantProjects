module.exports = (sequelize, Sequelize) => {
  const Blogs = sequelize.define("Blogs", {
    Title: {
      type: Sequelize.STRING,
      allowNull: false,
    },

    Content: {
      type: Sequelize.TEXT("long"),
      allowNull: false,
    },
    Url: {
      type: Sequelize.TEXT("medium"),
      allowNull: false,
    },
    Categories: {
      type: Sequelize.STRING,
      allowNull: false,
    },
    Date: {
      type: Sequelize.STRING,
      allowNull: false,
    },
    Like: {
      type: Sequelize.INTEGER,
      allowNull: false,
    },
    Dislike: {
      type: Sequelize.INTEGER,
      allowNull: false,
    },
  });
  return Blogs;
};
