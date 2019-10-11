import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CoursesComponent } from './pages/courses.component';
import { AddCoursesComponent } from './pages/add-courses/add-courses.component';
import { AllcoursesComponent } from './pages/allcourses/allcourses.component';
import { CourseDashboardComponent } from './pages/course-dashboard/course-dashboard.component';



const routes: Routes = [
  { path: 'course', component: CoursesComponent, 
    children :[
      { path: 'AllCourses', component: AllcoursesComponent },
      {path:'AddCourses', component:AddCoursesComponent},
      {path:'CourseDashboard', component:CourseDashboardComponent}
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoursesRoutingModule { }
