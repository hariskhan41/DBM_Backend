import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllInstitutesComponent } from './pages/all-institutes/all-institutes.component';
import { AddInstitutesComponent } from './pages/add-institutes/add-institutes.component';
import { EditComponent } from './pages/edit/edit.component';
import { AuthGuard } from '../shared/auth/auth.guard';


const routes: Routes = [
  { path: 'AllInstitutes', component: AllInstitutesComponent, canActivate: [AuthGuard], data: {permittedRoles: ['Admin']} },
  { path: 'AddInstitutes', component: AddInstitutesComponent, canActivate: [AuthGuard] },
  { path: 'Institute/Edit', component: EditComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InstituteRoutingModule { }
