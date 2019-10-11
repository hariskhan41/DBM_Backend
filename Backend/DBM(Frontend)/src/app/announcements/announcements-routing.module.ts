import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddAnnouncementsComponent } from './pages/add-announcements/add-announcements.component';

const routes: Routes = [
  { path: 'AddAnnouncements', component: AddAnnouncementsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AnnouncementsRoutingModule { }
