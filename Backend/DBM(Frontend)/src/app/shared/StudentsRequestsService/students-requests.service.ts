import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import{StudentsRequests} from 'src/app/shared/StudentsRequestsModelClass/students-requests.model';
@Injectable({
  providedIn: 'root'
})
export class StudentsRequestsService {
  formData = new StudentsRequests();
  readonly rootURL = 'http://localhost:3845/api'
  list: StudentsRequests[];
  constructor(private http:HttpClient) { }
  getStudentRequestsList() {
    this.http.get(this.rootURL + '/UsersRequests/GetAllStudentsRequests/'+localStorage.getItem('Id'))
    .toPromise()
    .then(res => {
      
      this.list = res as StudentsRequests[];
     // console.log(res);
    });
  }

  postEnrolmentRequests(formData: StudentsRequests) {
    //alert("aa");
    //return this.http.post(this.rootURL + '/UsersRequests/ApproveRequest', formData);
    console.log(formData);
    // return this.http.post(this.rootURL + '/UsersRequests/Approve', 3);
    return this.http.get(this.rootURL + '/UsersRequests/Approve/4')
    .toPromise()
    .then(
      res =>
      {
        alert("approved");
      }
    );
  }
}
