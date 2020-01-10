import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { AssignmentService } from 'src/app/shared/AssignmentService/assignment.service';

@Component({
  selector: 'app-add-assignments',
  templateUrl: './add-assignments.component.html',
  styleUrls: ['./add-assignments.component.css']
})
export class AddAssignmentsComponent implements OnInit {
  public progress: number;
  public message: string;
  @Output() public onUploadFinished = new EventEmitter();

  form: FormGroup;
  
  // constructor(private fb: FormBuilder, private http: HttpClient) {

  // }

  constructor (private service: AssignmentService) {

  }



  ngOnInit() {
    // this.form = this.fb.group({
    //   file: []
    // })
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      SubmissionDate: '',
      FilePath: '',
      Title: ''
    }
  }

  onSubmit(form: NgForm) {
    this.insertRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postAddAssignment(form.value).subscribe(
      res => {
        this.resetForm(form);
      },
      err => {
        console.log(err);
      }
    )
  }


  // public uploadFile = (files) => {
  //   if (files.length === 0) {
  //     return;
  //   }
  //   let fileToUpload = <File>files[0];
  //   const formData = new FormData();
  //   formData.append('file', fileToUpload, fileToUpload.name);


  //   this.http.post('http://localhost:3845/api/Assignment', formData, {reportProgress: true, observe: 'events'})
  //     .subscribe(event => {
  //       if (event.type === HttpEventType.UploadProgress)
  //         this.progress = Math.round(100 * event.loaded / event.total);
  //       else if (event.type === HttpEventType.Response) {
  //         this.message = 'Upload success.';
  //         this.onUploadFinished.emit(event.body);
  //       }
  //     });
  // }

  

}
