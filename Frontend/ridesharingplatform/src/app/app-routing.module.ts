import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewapplicationComponent } from './UserVerification/newapplication/newapplication.component';
import { ApplicationRequestComponent } from './UserVerification/application-request/application-request.component';
import { NavComponent } from './nav/nav.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  // { path: '', redirectTo: '/new-application', pathMatch: 'full' },
  { path: 'new-application', component: NewapplicationComponent },
  { path: 'application-request', component: ApplicationRequestComponent},
  {path: 'login',component:LoginComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
