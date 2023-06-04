import { Component, OnInit, ViewChild } from '@angular/core';

import { IncidentService } from '../api.service';

import { MatPaginator } from '@angular/material/paginator';

import { MatTableDataSource } from '@angular/material/table';

import { MatSort } from '@angular/material/sort';

import { ActivatedRoute } from '@angular/router';
import { Incident } from '../model/incident.model';





@Component({

  selector: 'app-incident-list',

  templateUrl: './incident-list.component.html',

  styleUrls: ['./incident-list.component.scss']

})

export class IncidentListComponent implements OnInit {




  // pendingIncidents: Incident[] = [];

  displayedColumns: string[] = [

    'incidentID',

    'incidentDate',

    'reportDate',

    'incidentType',

    'status',

    'edit'

  ];

  dataSource: MatTableDataSource<Incident>;




  @ViewChild(MatSort, {static: true}) sort: MatSort;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;




  incidentID: string;

  incident: any;

  constructor(private incidentApi: IncidentService,

    private readonly route: ActivatedRoute) { }





    ngOnInit(): void {

      this.getIncidents();

     

    }




  getIncidents() {

    this.incidentApi.getIncidents().subscribe((response) => {

      // this.pendingIncidents = response;

      this.dataSource = new MatTableDataSource(response);

      this.dataSource.paginator = this.paginator;

      this.dataSource.sort = this.sort;

    });

  }

 




  applyFilter(event: Event) {

    const filterValue = (event.target as HTMLInputElement).value;

    this.dataSource.filter = filterValue.trim().toLowerCase();

  }




//   pageChanged(event) {

//     const startIndex = (event.pageIndex * event.pageSize);

//     const endIndex = startIndex + event.pageSize;

//     if (endIndex > this.pendingIncidents.length) {

//       const slicedData = this.pendingIncidents.slice(startIndex, this.pendingIncidents.length);

//       const preSlicedData = this.pendingIncidents.slice(0, startIndex);

//       this.pendingIncidents = [...preSlicedData, ...slicedData];

//     } else {

//       this.pendingIncidents = this.pendingIncidents.slice(startIndex, endIndex);

//     }

//   }

//   sortDirection: 'asc' | 'desc' = 'asc';




// sorts(columnName: string) {

//   // Get a copy of the data array

//   const data = this.dataSource.data.slice();




//   // Sort the data array based on the selected column and sort direction

//   data.sort((a, b) => {

//     const valueA = a[columnName];

//     const valueB = b[columnName];

//     if (valueA === valueB) {

//       return 0;

//     }

//     return this.sortDirection === 'asc' ? (valueA < valueB ? -1 : 1) : (valueA > valueB ? -1 : 1);

//   });




//   // Toggle the sort direction for the next click

//   this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';




//   // Update the data source with the sorted data

//   this.dataSource.data = data;

// }




}