import { Component, OnInit } from '@angular/core';
import { AddInstituteServiceService} from "src/app/shared/InstituteService/add-institute-service.service";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-add-institutes',
  templateUrl: './add-institutes.component.html',
  styleUrls: ['./add-institutes.component.css']
})
export class AddInstitutesComponent implements OnInit {


  constructor(private service: AddInstituteServiceService, private httpService: HttpClient) {

  }
  

  ngOnInit() {
  }

}
