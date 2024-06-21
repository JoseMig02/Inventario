import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppLayoutComponent } from './layout/app.layout.component';
import { NofoundComponent } from './shared/components/nofound/nofound.component';

import { SigninComponent } from './features/empleado/components/signin/signin.component';

import { EmpleadoComponent } from './features/empleado/components/empleado/empleado.component';


import { AuthGuard } from './guards/auth-guard.guard';
import { AdminGuard } from './guards/admin-guard.guard';
import { OnlyAdminGuard } from './guards/admin.guard';
import { AccessComponent } from './shared/components/access/access.component';

import { TipoInventarioComponent } from './features/empleado/components/tipo-inventario/tipo-inventario.component';
import { AlmacenComponent } from './features/empleado/components/almacen/almacen.component';
import { ArticuloComponent } from './features/empleado/components/articulo/articulo.component';
import { TransaccioComponent } from './features/empleado/components/transaccio/transaccio.component';
import { ConsultasComponent } from './features/empleado/components/consultas/consultas.component';


const routes: Routes = [
  {
    path: '',
    component: AppLayoutComponent,
    children: [

     
      { path: 'empleado/empleados', component: EmpleadoComponent, canActivate:[OnlyAdminGuard] }, // Requiere ser administrador
      { path: 'empleado/Articulos', component: ArticuloComponent }, // Requiere ser administrador
     
      { path: 'empleado/Tipoinventario', component: TipoInventarioComponent },
      { path: 'empleado/Almacen', component: AlmacenComponent },
      { path: 'empleado/Transacciones', component: TransaccioComponent },
      { path: 'empleado/consultas', component: ConsultasComponent },
      // { path: 'empleado/reportes', component: ReporteComponent },
      // Otras rutas dentro del layout
    ]
  },
  { path: 'empleado', loadChildren: () => import('../app/features/empleado/empleado/empleado.module').then(m => m.EmpleadoModule) },
  
  // Ruta por defecto que carga el componente SigninComponent
  { path: '', redirectTo: '/empleado/signIn', pathMatch: 'full' },
  
  // Ruta para el componente SigninComponent
  { path: 'empleado/signIn', component: SigninComponent },
    // Ruta para el componente AccessDeniedComponent
    { path: 'access-denied', component:AccessComponent },

  // Catch-all route for 404 - Not Found
  { path: '**', component: NofoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
