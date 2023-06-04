import { HttpClient, HttpClientModule } from '@angular/common/http';

import { Component, OnInit } from '@angular/core';

import { FormControl, FormGroup, Validators } from '@angular/forms';

import { IncidentService } from '../api.service';

import { formatDate } from '@angular/common';
import { TokenService } from 'src/app/app.tokenservice';





@Component({

 selector: 'app-new-incident',

 templateUrl: './new-incident.component.html',

 styleUrls: ['./new-incident.component.scss']

})

export class NewIncidentComponent implements OnInit{




 // incidentTypes = ["Traffic accidents","Passenger misconduct","Driver misconduct","Payment dispute","Theft or loss"];

 incidentTypes: any[]=[];

 newincident : FormGroup;




 constructor(private incidentUrl : IncidentService,private tokenService:TokenService){}




 ngOnInit() {

 

  this.newincident = new FormGroup({

   incidentDate : new FormControl('',Validators.required),

   reportDate : new FormControl(formatDate(new Date(),'MM/dd/yyyy','en-US'),Validators.required),

   incidentReportedByUserId : new FormControl(Number(this.tokenService.getid())),

   investigatedByUserId : new FormControl(0),

   incidentSummary : new FormControl('',Validators.required),

   incidentDetails : new FormControl('',Validators.required),

   bookingId : new FormControl(0,Validators.required),

   status : new FormControl('Pending'),

   incidentTypeId : new FormControl('Choose an incident type',Validators.required)

  });




  // Fetch incident Type from incident API

  this.incidentUrl.getIncidentType().subscribe((response: any[]) =>

  {

   this.incidentTypes = response;

  })

 }

 onSubmit(){

  console.log(this.newincident.value);

  this.addIncident();

 }




 addIncident(){

  const incidentFormValue=this.newincident.value;

  //ConvertincidentReportedByUserIdtoint

  // incidentFormValue.incidentReportedByUserId=parseInt("23");

  incidentFormValue.incidentTypeId=parseInt(incidentFormValue.incidentTypeId);

 

  // incidentFormValue.investigatedByUserId=parseInt("2");




  incidentFormValue.bookingId=parseInt(incidentFormValue.bookingId);






  //ModifythereportDatevalue

  const modifiedReportDate= new Date(incidentFormValue.reportDate);

  modifiedReportDate.setDate(modifiedReportDate.getDate()+1);

  incidentFormValue.reportDate=modifiedReportDate.toISOString();

 

 

  this.incidentUrl.addIncident(incidentFormValue).subscribe((response) =>

  {

   console.log(response);

  })

 }





}