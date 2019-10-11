import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
@Component({
  selector: 'app-add-groups',
  templateUrl: './add-groups.component.html',
  styleUrls: ['./add-groups.component.css']
})
export class AddGroupsComponent {
  permissions = new FormControl();
  permissionList: string[] = ['Abc', 'Xyz', 'Klm', 'per1'];
  constructor() { }

 

}
