const studentcontroller = require('../controllers/StudentController.js')
const router = require('express').Router()
router.get('/',studentcontroller.start)
router.post('/addstudent',studentcontroller.addStudent)
router.get('/allstudents',studentcontroller.getAllStudents)
router.get('/:id',studentcontroller.getOneStudent)
router.delete('/:id',studentcontroller.deleteStudent)
router.put('/:id',studentcontroller.updateStudent)
router.get('/:Rollno/:Name',studentcontroller.SearchResult)

module.exports = router