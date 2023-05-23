const db = require('../models')

const Student = db.students
const start = async(req,res)=>{
    res.status(200).send("msg printed")

}
const addStudent = async(req,res) =>{
    let info ={
        Rollno : req.body.Rollno,
        Name  : req.body.Name,
        Dob  : req.body.Dob,
        Score : req.body.Score
    }

    const student = await Student.create(info)
    res.send(student)
  


}


const getAllStudents =  async(req,res) =>{
    let students =  await Student.findAll({})
    res.status(200).send(students)
}



const getOneStudent =  async(req,res) =>{
    let id = req.params.id

    let student =  await Student.findOne({where:{id:id }
    })
    res.status(200).send(student)
}
const SearchResult =  async(req,res) =>{
    let roll = req.params.Rollno
    let name=req.params.Name

    let student =  await Student.findOne({where:{Rollno:roll , Name:name }
    })
    if(student ===undefined)res.send({message: "Result was not found!"})
    else res.send(student)
}


const updateStudent =  async(req,res) =>{
    let id = req.params.id
    let student =  await Student.update(req.body,{where:{id:id}})
    res.send(student)
}


const deleteStudent =  async(req,res) =>{
    let id = req.params.id
   await Student.destroy({where:{id:id}})
   res.send({

    message: "Result was deleted successfully!"

  });

}

module.exports = {
    addStudent,
    getAllStudents,
    getOneStudent,
    updateStudent,
    deleteStudent,
    start,
    SearchResult
    

}



