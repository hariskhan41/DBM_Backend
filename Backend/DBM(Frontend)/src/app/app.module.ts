import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";

import {MatGridListModule} from '@angular/material/grid-list'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { SharedModule } from './shared/shared.module';
import { CoursesModule } from './courses/courses.module';
import { MatCardModule } from '@angular/material/card';


import { LoginRegistrationModule } from './login-registration/login-registration.module';
import { AnnouncementsModule } from './announcements/announcements.module';
import { PermissionsModule } from './permissions/permissions.module';
import { NotesModule } from './notes/notes.module';
import { MainPageComponent } from './main-page/main-page.component';
import { AssignmentsModule } from './assignments/assignments.module';
import { TeacherModule } from './teacher/teacher.module';
import { InstituteModule } from './institute/institute.module';







@NgModule({

  declarations: [
    AppComponent,

    MainPageComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatButtonModule,
    MatCheckboxModule,
    MatGridListModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    SharedModule,
    CoursesModule,
    LoginRegistrationModule,
    AnnouncementsModule,
    PermissionsModule,
    NotesModule,
    AssignmentsModule,
    TeacherModule,
    InstituteModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
