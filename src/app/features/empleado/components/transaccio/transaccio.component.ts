import { Component, OnInit } from '@angular/core';
import { Articulo } from '../../../../models/Articulo';
import { TransaccionService } from '../../../../services/transaccion.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ArticuloService } from '../../../../services/articulo.service';
import { Transaccion } from '../../../../models/Transaccion'
import { ConfirmationService, MessageService } from 'primeng/api';

interface Estado {
  label: string;
  value: string;
}
@Component({
  selector: 'app-transaccio',
  templateUrl: './transaccio.component.html',
  styleUrl: './transaccio.component.scss'
})
export class TransaccioComponent implements OnInit {
  articulos: Articulo[] = [];
  transaccionForm: FormGroup;
  displayDialog: boolean = false;
  isNew: boolean = false;
  selectedArticulo: Articulo | undefined;
  estados: Estado[] | undefined;
  transacciones: Transaccion[] = [];
  

  constructor(
    private fb: FormBuilder,
    private articuloService: ArticuloService,
    private transaccionService:TransaccionService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {
    this.transaccionForm = this.fb.group({
      id: [''],
      tipoTransaccion: ['', Validators.required],
      idArticulo: ['', Validators.required],
      fecha: ['', Validators.required],
      cantidad: ['', Validators.required],
      costo: ['', Validators.required],
      observaciones: ['']
    });
  }

  ngOnInit(): void {
    this.loadArticulos();
    this.loadTransacciones();
    this.estados = [
      { label: 'Activo', value: 'activo' },
      { label: 'Inactivo', value: 'inactivo' }
    ];
  }
  loadTransacciones(): void {
    this.transaccionService.getTransacciones().subscribe((data: Transaccion[]) => {
      this.transacciones = data;
    });
  }

  loadArticulos(): void {
    this.articuloService.getArticulos().subscribe((data: Articulo[]) => {
      this.articulos = data;
    });
  }

  openNew(): void {
    this.isNew = true;
    this.transaccionForm.reset();
    this.displayDialog = true;
  }

  editTransaccion(transaccion: Transaccion): void {
    this.isNew = false;
    this.transaccionForm.patchValue(transaccion);
    this.displayDialog = true;
  }
  saveTransaccion(): void {
    if (this.transaccionForm.invalid) {
      this.transaccionForm.markAllAsTouched();
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Completar Campos', life: 2000 });
      return;
    }
  
    const transaccion: any = this.transaccionForm.value as Transaccion;
  
    if (this.isNew) {
      this.transaccionService.createTransaccion(transaccion).subscribe(() => {
        this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Transacción creada' });
        this.loadTransacciones();
        this.displayDialog = false;
      });
    } else {
      this.transaccionService.updateTransaccion(transaccion.id, transaccion).subscribe(() => {
        this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Transacción actualizada' });
        this.loadTransacciones();
        this.displayDialog = false;
      });
    }
  }
  deleteTransaccion(id: number): void {
    this.confirmationService.confirm({
      message: '¿Estás seguro de que quieres eliminar esta transacción?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: "p-button-danger p-button-text",
      rejectButtonStyleClass: "p-button-text p-button-text",
      acceptIcon: "none",
      rejectIcon: "none",
      accept: () => {
        this.transaccionService.deleteTransaccion(id).subscribe(() => {
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Transacción eliminada' });
          this.loadTransacciones();
        });
      }
    });
  }
  hideDialog(): void {
    this.displayDialog = false;
  }

}
