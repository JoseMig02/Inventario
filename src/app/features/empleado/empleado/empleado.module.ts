import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmpleadoRoutingModule } from './empleado-routing.module';
import { SignupComponent } from '../components/signup/signup.component';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputNumberModule } from 'primeng/inputnumber';
import { CalendarModule } from "primeng/calendar";
import { DropdownModule } from 'primeng/dropdown';
import { ToastModule } from 'primeng/toast';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { ConfirmationService, MessageService } from 'primeng/api';
import { SigninComponent } from '../components/signin/signin.component';
import { PasswordModule } from 'primeng/password';
import { CheckboxModule } from 'primeng/checkbox';
import { HttpClientModule } from '@angular/common/http';


import { DialogModule } from 'primeng/dialog';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { RatingModule } from 'primeng/rating';
import { ToolbarModule } from 'primeng/toolbar';
import { FileUploadModule } from 'primeng/fileupload';
import { InputTextareaModule } from 'primeng/inputtextarea';



import { EmpleadoComponent } from '../components/empleado/empleado.component';

import { PanelModule } from 'primeng/panel';

import { ImageModule } from 'primeng/image';

import { TipoInventarioComponent } from '../components/tipo-inventario/tipo-inventario.component';
import { AlmacenComponent } from '../components/almacen/almacen.component';
import { ArticuloComponent } from '../components/articulo/articulo.component';
import { TransaccioComponent } from '../components/transaccio/transaccio.component';

@NgModule({
  declarations: [
    SignupComponent,
    SigninComponent,
 
    EmpleadoComponent,
ArticuloComponent,

   
    TipoInventarioComponent,
    AlmacenComponent,
    TransaccioComponent



  ],
  imports: [
    CommonModule,
    EmpleadoRoutingModule,
    InputTextModule,
    ReactiveFormsModule,
    InputNumberModule,
    CalendarModule,
    DropdownModule,
    ToastModule,
    ButtonModule,
    RippleModule,
    CheckboxModule,
    InputTextModule,
    FormsModule,
    PasswordModule,
    HttpClientModule,
    DialogModule,
    TableModule,
    ConfirmDialogModule,
    RatingModule,
    ToolbarModule,
    FileUploadModule,
    InputTextareaModule,
    TagModule,
    PanelModule,
    ImageModule



],
exports: [ToastModule],
  providers: [MessageService,ConfirmationService]
})
export class EmpleadoModule { }
