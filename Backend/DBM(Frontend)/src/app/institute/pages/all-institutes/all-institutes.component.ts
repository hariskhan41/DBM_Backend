import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { AddInstituteServiceService } from 'src/app/shared/InstituteService/add-institute-service.service';
import { AddInstituteModelClass } from 'src/app/shared/InstituteModelClass/add-institute-model-class.model';

export interface Designation {
  value: string;
  viewValue: string;
}

export interface PeriodicElement {

  Position: string;
  InstituteName: string;
  Admin: string;
  AddedOn: string;
  Edit: string;
  Delete: string;

}
export interface Food {
  value: string;
  viewValue: string;
}

// const ELEMENT_DATA: PeriodicElement[] = [
//   {
//     Position: '1',
//     InstituteName: 'UET',
//     Admin: 'xyz',
//     AddedOn: moment().format('10/7/2018'),
//     Edit: '',
//     Delete: ''
//   },
//   {
//     Position: '2',
//     InstituteName: 'Fast',
//     Admin: 'xyz',
//     AddedOn: moment().format('10/7/2018'),
//     Edit: '',
//     Delete: ''
//   },
// ];


@Component({
  selector: 'app-all-institutes',
  templateUrl: './all-institutes.component.html',
  styleUrls: ['./all-institutes.component.css']
})
export class AllInstitutesComponent implements OnInit {

  designations: Designation[] = [
    { value: 'Teacher', viewValue: 'Teacher' },
    { value: 'Student', viewValue: 'Student' },
    { value: 'Admin', viewValue: 'Admin' }
  ];

  constructor(private service: AddInstituteServiceService) {

  }

  lst: AddInstituteModelClass[];

  ngOnInit() {
    this.service.getInstitutesList();
    this.lst = this.service.list;
  }

  dataSource = this.service.list;
  displayedColumns: string[] = ['instituteName'];


}
