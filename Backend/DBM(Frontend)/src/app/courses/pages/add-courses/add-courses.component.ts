import { Component, OnInit } from '@angular/core';
import { VERSION } from '@angular/platform-browser-dynamic';
import { FormBuilder, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-add-courses',
  templateUrl: './add-courses.component.html',
  styleUrls: ['./add-courses.component.css']
})
export class AddCoursesComponent implements OnInit {


  form: FormGroup;
  constructor(private fb: FormBuilder) {

  }

  ngOnInit() {
    this.form = this.fb.group({
      file: []
    })
  }

}
