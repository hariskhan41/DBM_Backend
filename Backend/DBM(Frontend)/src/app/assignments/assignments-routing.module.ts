import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddAssignmentsComponent } from './pages/add-assignments/add-assignments.component';
import { SubmitAssignmentComponent } from './pages/submit-assignment/submit-assignment.component';


const routes: Routes = [
  { path: 'AddAssignment', component: AddAssignmentsComponent },
  { path: 'SubmitAssignment', component: SubmitAssignmentComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssignmentsRoutingModule { }
