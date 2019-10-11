import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';

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

const ELEMENT_DATA: PeriodicElement[] = [
  {
    Position:'1',
    InstituteName: 'UET',
    Admin:'xyz',
    AddedOn: moment().format('10/7/2018'),
    Edit: '',
    Delete: ''
  },
  {
    Position:'2',
    InstituteName: 'Fast',
    Admin:'xyz',
    AddedOn: moment().format('10/7/2018'),
    Edit: '',
    Delete: ''
  },
];


@Component({
  selector: 'app-all-institutes',
  templateUrl: './all-institutes.component.html',
  styleUrls: ['./all-institutes.component.css']
})
export class AllInstitutesComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  dataSource = ELEMENT_DATA;
  displayedColumns: string[] = ['Position', 'InstituteName', 'Admin', 'AddedOn', 'Edit', 'Delete'];


}
