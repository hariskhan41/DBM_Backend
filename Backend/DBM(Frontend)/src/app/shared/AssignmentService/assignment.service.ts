import { Injectable } from '@angular/core';
import { Assignment } from '../CourseAssignementModelClass/assignment.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AssignmentService {

  formData: Assignment;
  readonly rootURL = 'http://localhost:3845/api/';
  s: String = null;


  constructor(public http: HttpClient) { }


  postAddAssignment(formData: Assignment) {
    return this.http.post(this.rootURL + 'Assignment/SaveAssignment/' + localStorage.getItem('CourseName'), formData);
  }

  onUploadAssignment(selectedFile) {
    
    const fd = new FormData();
    fd.append('image', selectedFile, selectedFile.name);
    return this.http.post(this.rootURL + 'Assignment/Upload', fd)
      // .subscribe(
      //   res => {
      //     console.log(res);
      //   }
      // );
  }

  // postFile(fileToUpload: File) {
  //   const endpoint = 'assets/UploadedImage/';
  //   const formData2: FormData = new FormData();
  //   formData2.append('fileKey', fileToUpload, fileToUpload.name);
  //   return this.http.post(endpoint, formData2);

  // }
}
