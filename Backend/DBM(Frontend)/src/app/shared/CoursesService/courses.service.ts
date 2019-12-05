import { Injectable } from '@angular/core';
import { Courses } from '../CoursesModelClass/courses.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {
  formData: Courses;
  teachersLst;
  readonly rootURL = 'http://localhost:3845/api/';
  list: Courses[];
  EnrollmentList:Courses[];
  editFlag: Boolean = false;


  constructor(private http: HttpClient) { }

  postAddCourse(formData: Courses) {
    return this.http.post(this.rootURL + 'Course/AddCourse', formData);
  }

  postAssignTeacher(formData: Courses) {
    return this.http.post(this.rootURL + 'Course/AssignTeacher', formData);
  }

  postTest(formData: Courses) {
    return this.http.post(this.rootURL + 'Course/PostGetAssignedTeacher', formData);
  }


  putAddCourse(formData: Courses) {
    return this.http.put(this.rootURL + 'Course/' + this.formData.id, formData);
  }

  postEnrolmentRequests(formData: Courses) {
    return this.http.post(this.rootURL + 'CourseEnrollment/EnrolmentPending', formData);
  }

  getEnrollmentRequests()
  {
    this.http.get(this.rootURL + 'CourseEnrollment/' + localStorage.getItem('Id')+'/'+localStorage.getItem('CourseName'))
    .toPromise()
    .then(
      res => {
        this.EnrollmentList = res as Courses[];
        console.log(res);
      }
    );
  }

  getCoursesList() {
    this.http.get(this.rootURL + 'Course/GetAllCourses/' + localStorage.getItem('Id'))
      .toPromise()
      .then(
        res => {
          this.list = res as Courses[];
          console.log(res);
        }
      );
  }

  
  getAssignedCourses() {
    console.log(this.formData);
    this.http.get(this.rootURL + 'Course/' + localStorage.getItem('Id'))
    .toPromise()
    .then(
      res => {
        this.list = res as Courses[];
        console.log(res);
      }
    );
  }

  getTeachersEmailList() {
    this.http.get(this.rootURL + 'Course/GetAllTeachers')
      .toPromise()
      .then(
        res => {
          this.teachersLst = res;
        }
      );
  }
}
