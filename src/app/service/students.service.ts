import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  baseurl = 'https://localhost:7087/api/students';

  constructor(private http: HttpClient) { }

  getAllStudents(): Observable<Student[]>{
    return this.http.get<Student[]>(this.baseurl);
  }
  
  addStudent(student: Student): Observable<Student>{
    student.studentId = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Student>(this.baseurl, student);
  }

  updateStudent(student: Student): Observable<Student>{
    return this.http.put<Student>(this.baseurl+'/'+student.studentId, student);
  }

  deleteStudent(studentId: string): Observable<Student>{
    return this.http.delete<Student>(this.baseurl+'/'+studentId);
  }
}
