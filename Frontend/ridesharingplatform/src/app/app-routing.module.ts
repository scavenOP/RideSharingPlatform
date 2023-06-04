import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewapplicationComponent } from './UserVerification/newapplication/newapplication.component';
import { ApplicationRequestComponent } from './UserVerification/application-request/application-request.component';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';
import { AddvehicleComponent } from './VehicleManagement/addvehicle/addvehicle.component';
import { MyVehicleComponent } from './VehicleManagement/my-vehicle/my-vehicle.component';
import { ApproveRejectVehicleComponent } from './VehicleManagement/approve-reject-vehicle/approve-reject-vehicle.component';
import { ScheduleRideComponent } from './RideManagement/schedule-ride/schedule-ride.component';
import { SearchRidesComponent } from './RideManagement/search-rides/search-rides.component';
import { BookRideComponent } from './RideManagement/book-ride/book-ride.component';
import { NewIncidentComponent } from './IncidentManagement/new-incident/new-incident.component';
import { IncidentListComponent } from './IncidentManagement/incident-list/incident-list.component';
import { TrackIncidentComponent } from './IncidentManagement/track-incident/track-incident.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component:HomeComponent },
  { path: 'add-vehicle', component: AddvehicleComponent},
  { path: 'my-vehicle' , component: MyVehicleComponent},
  { path: 'inspect-vehicle', component: ApproveRejectVehicleComponent},
  { path: 'new-application', component: NewapplicationComponent },
  { path: 'application-request', component: ApplicationRequestComponent},
  { path: 'schedule-ride', component:ScheduleRideComponent},
  { path: 'search-ride', component:SearchRidesComponent},
  {path: 'book-ride', component:BookRideComponent},
  {path:'new-incident',component:NewIncidentComponent},
  {path:'incident-list',component:IncidentListComponent},
  {path:'track-incident/:incidentID',component:TrackIncidentComponent},
  {path: 'login',component:LoginComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
