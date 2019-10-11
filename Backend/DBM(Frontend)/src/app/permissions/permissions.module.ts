import { NgModule ,CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';
import{MatCheckboxModule} from '@angular/material/checkbox';
import {FlexLayoutModule} from '@angular/flex-layout';
import { PermissionsRoutingModule } from './permissions-routing.module';
import {MatSelectModule} from '@angular/material/select'
import { AddGroupsComponent } from './pages/add-groups/add-groups.component';
import { PermissionsComponent } from './pages/permissions.component';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import { PermissionManagementComponent } from './pages/permission-management/permission-management.component';
import{MatButtonModule} from '@angular/material/button';
import{MatInputModule} from '@angular/material/input';
@NgModule({
  declarations: [AddGroupsComponent, PermissionsComponent, PermissionManagementComponent],
  imports: [
    
    CommonModule,
    MatSelectModule,
    MatCheckboxModule,
    MatCardModule,
    FlexLayoutModule,
    PermissionsRoutingModule,
    MatTableModule,
    MatButtonModule,
    MatInputModule
  ],
  schemas:[
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class PermissionsModule { }
