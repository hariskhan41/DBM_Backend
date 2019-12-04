import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CoursesComponent } from './pages/courses.component';
import { AddCoursesComponent } from './pages/add-courses/add-courses.component';
import { AllcoursesComponent } from './pages/allcourses/allcourses.component';
import { CourseDashboardComponent } from './pages/course-dashboard/course-dashboard.component';
import { AssignCourseComponent } from './pages/assign-course/assign-course.component';
import { EnrollmentRequestsComponent } from './pages/enrollment-requests/enrollment-requests.component';




const routes: Routes = [
  { path: 'AddCourse', component: AddCoursesComponent },
  { path: 'AllCourses', component: AllcoursesComponent },
  { path: 'AssignCourse', component: AssignCourseComponent },
  { path: 'EnrollmentRequests', component: EnrollmentRequestsComponent },
  { path: 'CourseDashboard', component: CourseDashboardComponent },

  // { path: 'course', component: CoursesComponent, 
  //   children :[
  //     { path: 'AllCourses', component: AllcoursesComponent },
  //     {path:'AddCourses', component:AddCoursesComponent},
  //     {path:'CourseDashboard', component:CourseDashboardComponent}
  //   ]
  // },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoursesRoutingModule { }
