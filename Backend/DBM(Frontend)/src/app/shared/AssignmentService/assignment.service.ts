import { Injectable } from '@angular/core';
import { Assignment } from '../CourseAssignementModelClass/assignment.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AssignmentService {

  formData: Assignment;
  readonly rootURL = 'http://localhost:3845/api/';


  constructor(public http: HttpClient) { }

  postAddAssignment(formData: Assignment) {
    return this.http.post(this.rootURL + 'Assignment', formData);
  }

  postFile(fileToUpload: File) {
    const endpoint = 'assets/UploadedImage/';
    const formData2: FormData = new FormData();
    formData2.append('fileKey', fileToUpload, fileToUpload.name);
    return this.http.post(endpoint, formData2);
    
  }
}
