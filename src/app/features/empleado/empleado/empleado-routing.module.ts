import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from '../components/signup/signup.component';
import { SigninComponent } from '../components/signin/signin.component';


import { EmpleadoComponent } from '../components/empleado/empleado.component';


const routes: Routes = [
  { path: 'signup', component: SignupComponent } ,
  { path: 'signIn', component: SigninComponent},
  { path: 'empleados', component:EmpleadoComponent},



];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmpleadoRoutingModule { }
