import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllInstitutesComponent } from './pages/all-institutes/all-institutes.component';
import { AddInstitutesComponent } from './pages/add-institutes/add-institutes.component';
import { EditComponent } from './pages/edit/edit.component';


const routes: Routes = [
  { path: 'AllInstitutes', component: AllInstitutesComponent },
  { path: 'AddInstitutes', component: AddInstitutesComponent },
  { path: 'Institute/Edit', component: EditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InstituteRoutingModule { }
