import { Component, OnInit } from '@angular/core';
import { IconName } from '@fortawesome/fontawesome-common-types';
import { MatIcon } from '@angular/material';

export interface PeriodicElement {
  name: string;
  position: number;
  Edit: string;
  Delete: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Lecture 1', Edit: '', Delete: ''},
  { position: 2, name: 'Lecture 2', Edit: '', Delete: ''},
  { position: 3, name: 'Lecture 3', Edit: '', Delete: ''},
  { position: 4, name: 'Lecture 4', Edit: '', Delete: ''},
  { position: 5, name: 'Lecture 5', Edit: '', Delete: ''},
];

@Component({
  selector: 'app-lectures',
  templateUrl: './lectures.component.html',
  styleUrls: ['./lectures.component.css']
})
export class LecturesComponent implements OnInit {

  constructor() { }

  displayedColumns: string[] = ['position', 'name', 'Edit', 'Delete'];
  dataSource = ELEMENT_DATA;

  ngOnInit() {
  }

}
