import { Component, OnInit } from '@angular/core';
import { Student } from './models/student.model';
import { StudentsService } from './service/students.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Students';
  students: Student[] = [];
  student: Student = {
    studentId: '',
    studentName: '',
    department: '',
    email: '',
    cgpa: 0
  }

  constructor(private studentService: StudentsService){}

  ngOnInit(): void{
    this.getAllStudents();
  }

  getAllStudents(){
    this.studentService.getAllStudents().subscribe(
      response => {
        this.students = response;
      }
    );
  }

  onSubmit(){
    if(this.student.studentId === ''){
      this.studentService.addStudent(this.student).subscribe(
        response => {
          this.getAllStudents();
          this.student = {
            studentId: '',
            studentName: '',
            department: '',
            email: '',
            cgpa: 0
          }
        }
      );
    }
    else{
      this.updateStudent(this.student);
    }
  }

  selectStudent(student: Student){
    this.student = student;
  }

  updateStudent(student: Student){
    this.studentService.updateStudent(student).subscribe(
      response => {
        this.getAllStudents();
      }
    );
  }

  deleteStudent(studentId: string){
    this.studentService.deleteStudent(studentId).subscribe(
      response => {
        this.getAllStudents();
      }
    );
  }

}
