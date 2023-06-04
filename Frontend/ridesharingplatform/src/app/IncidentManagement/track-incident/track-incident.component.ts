import { Component, OnInit } from '@angular/core';

import { FormGroup, FormControl } from '@angular/forms';

import { ActivatedRoute } from '@angular/router';
import { TokenService } from 'src/app/app.tokenservice';

import { IncidentService } from '../api.service';





@Component({

 selector: 'app-track-incident',

 templateUrl: './track-incident.component.html',

 styleUrls: ['./track-incident.component.scss']

})

export class TrackIncidentComponent implements OnInit {

 incidentForm: FormGroup;

 incidentID: string;

 investigation: FormGroup;

 incidentTypes: any[]=[];

 investigationReport:any;
 isSecurity:boolean;






 constructor(private route: ActivatedRoute, private incidentService: IncidentService,private tokenService:TokenService) { }




 ngOnInit() {

  this.isSecurity=this.tokenService.getRole()=="SecurityHead";

  this.incidentForm = new FormGroup({

   incidentID: new FormControl(''),

   incidentDate: new FormControl(''),

   reportDate: new FormControl(''),

   incidentReportedByUserId: new FormControl(''),

   resolutionETA: new FormControl(''),

   investigatedByUserId: new FormControl(''),

   incidentSummary: new FormControl(''),

   incidentDetails: new FormControl(''),

   bookingId: new FormControl(''),

   status: new FormControl(''),

   finding: new FormControl(''),

   suggestions : new FormControl(''),

   investigationDate: new FormControl('')

  });

  // this.investigation = new FormGroup({

  // 

  // });




  this.route.paramMap.subscribe(params => {

   this.incidentID = params.get('incidentID');

   console.log(this.incidentID);

   if (this.incidentID) {

    this.getIncidentDetail();

   }

  });

 }




 getIncidentDetail() {

  this.incidentService.getIncident(this.incidentID).subscribe(response => {

   if (response) {

    this.incidentForm.patchValue(response);

   }

  });

 }




 // Rest of your component code

 onSubmit(): void {

  // Handle form submission here

  // You can access the form values using this.incidentForm.value

 

  this.updateStatusandInvestigation();

 }

 updateStatusandInvestigation(){

  this.incidentID = this.incidentForm.value.incidentID;

  const status = this.incidentForm.value.status;

   const finding= this.incidentForm.value.finding;

   const suggestions = this.incidentForm.value.suggestions;

   const investigationDate = this.incidentForm.value.investigationDate;

  this.incidentService.updateStatus(this.incidentID,status,finding,suggestions,investigationDate).subscribe((respone) =>

  {

   console.log('Status and investigation report');

  },

  (error) =>

  {

   console.log("Failed to update");

  }

  );

 }




}