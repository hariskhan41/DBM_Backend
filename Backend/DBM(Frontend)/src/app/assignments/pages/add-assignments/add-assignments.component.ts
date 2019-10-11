import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-assignments',
  templateUrl: './add-assignments.component.html',
  styleUrls: ['./add-assignments.component.css']
})
export class AddAssignmentsComponent implements OnInit {

  form: FormGroup;
  constructor(private fb: FormBuilder) {

  }

  ngOnInit() {
    this.form = this.fb.group({
      file: []
    })
  }

}
