import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AssignmentService } from 'src/app/shared/AssignmentService/assignment.service';

@Component({
  selector: 'app-submit-assignment',
  templateUrl: './submit-assignment.component.html',
  styleUrls: ['./submit-assignment.component.css']
})
export class SubmitAssignmentComponent implements OnInit {

  form: FormGroup;
  public RegistrationNumbers: any[] = [{
    RegNo: ''
  }];
  constructor(private service: AssignmentService, private http: HttpClient) {

  }

  ngOnInit() {
    // this.form = this.fb.group({
    //   file: []
    // })
    this.resetForm();
  }

  addGroupMember() {
    this.RegistrationNumbers.push({
      RegNo: ''
    });
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formDataSubmitAssignment = {
      Id: 0,
      SubmissionDate: new Date(),
      FilePath: '',
      Title: '',
      Email: '',
      StartDateTime: new Date(),
      GroupId: 0,
      GroupRegNo: []
    }
  }

  onSubmit(form: NgForm) {
    console.log(form);
    console.log(this.RegistrationNumbers);
    
  }

}
