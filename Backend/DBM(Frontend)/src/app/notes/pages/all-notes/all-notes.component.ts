import { Component, OnInit } from '@angular/core';
import { IconName } from '@fortawesome/fontawesome-common-types';
import { MatIcon } from '@angular/material';

export interface PeriodicElement {
  name: string;
  position: number;
  Edit: string;
  Delete: string;
  UploadedBy: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Lecture 1', UploadedBy: 'ABC', Edit: '', Delete: '' },
  { position: 2, name: 'Lecture 2', UploadedBy: 'ABC', Edit: '', Delete: '' },
  { position: 3, name: 'Lecture 3', UploadedBy: 'ABC', Edit: '', Delete: '' },
  { position: 4, name: 'Lecture 4', UploadedBy: 'ABC', Edit: '', Delete: '' },
  { position: 5, name: 'Lecture 5', UploadedBy: 'ABC', Edit: '', Delete: '' },
];


@Component({
  selector: 'app-all-notes',
  templateUrl: './all-notes.component.html',
  styleUrls: ['./all-notes.component.css']
})
export class AllNotesComponent implements OnInit {

  constructor() { }

  displayedColumns: string[] = ['position', 'name', 'UploadedBy', 'Edit', 'Delete'];
  dataSource = ELEMENT_DATA;

  ngOnInit() {
  }

}
