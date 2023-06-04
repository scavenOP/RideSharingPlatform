import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewapplicationComponent } from './UserVerification/newapplication/newapplication.component';
import { NavComponent } from './nav/nav.component';
import { HttpClientModule } from '@angular/common/http';
import { ApplicationRequestComponent } from './UserVerification/application-request/application-request.component';
import { LoginComponent } from './login/login.component'; 
import { RouterModule, Routes } from '@angular/router';
import { AddvehicleComponent } from './VehicleManagement/addvehicle/addvehicle.component';
import { LoadingComponent } from './loading/loading.component';
import { MyVehicleComponent } from './VehicleManagement/my-vehicle/my-vehicle.component';
import { ApproveRejectVehicleComponent } from './VehicleManagement/approve-reject-vehicle/approve-reject-vehicle.component';
import { ScheduleRideComponent } from './RideManagement/schedule-ride/schedule-ride.component';
import { SearchRidesComponent } from './RideManagement/search-rides/search-rides.component';
import { BookRideComponent } from './RideManagement/book-ride/book-ride.component';
import { NewIncidentComponent } from './IncidentManagement/new-incident/new-incident.component';
import { IncidentListComponent } from './IncidentManagement/incident-list/incident-list.component';
import { MatIconModule } from '@angular/material/icon';
import { MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { TrackIncidentComponent } from './IncidentManagement/track-incident/track-incident.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    NewapplicationComponent,
    NavComponent,
    ApplicationRequestComponent,
    LoginComponent,
    AddvehicleComponent,
    LoadingComponent,
    MyVehicleComponent,
    ApproveRejectVehicleComponent,
    ScheduleRideComponent,
    SearchRidesComponent,
    BookRideComponent,
    NewIncidentComponent,
    IncidentListComponent,
    TrackIncidentComponent,
    HomeComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([]),
    MatIconModule,
    MatSortModule,
    MatTableModule,
    MatPaginatorModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
