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
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
