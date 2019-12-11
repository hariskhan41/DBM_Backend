import { Injectable } from '@angular/core';
import { Announcement } from '../AnnouncementModelClass/announcement.model';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class AnnouncementService {
    formData: Announcement;
    readonly rootURL = 'http://localhost:3845/api/';
  constructor(private http: HttpClient) { }

  postAddAnnouncement(formData: Announcement) {
    return this.http.post(this.rootURL + 'Announcement/AddAnnouncement', formData);
  }
}
