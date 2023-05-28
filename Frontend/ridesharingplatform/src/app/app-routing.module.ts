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

const routes: Routes = [
  // { path: '', redirectTo: '/new-application', pathMatch: 'full' },
  { path: 'add-vehicle', component: AddvehicleComponent},
  { path: 'my-vehicle' , component: MyVehicleComponent},
  { path: 'inspect-vehicle', component: ApproveRejectVehicleComponent},
  { path: 'new-application', component: NewapplicationComponent },
  { path: 'application-request', component: ApplicationRequestComponent},
  { path: 'schedule-ride', component:ScheduleRideComponent},
  {path: 'login',component:LoginComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
