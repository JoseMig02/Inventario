import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { AlmacenService } from '../../../../services/almacen.service';
import { Almacen } from '../../../../models/Almacen';

@Component({
  selector: 'app-almacen',
  templateUrl: './almacen.component.html',
  styleUrls: ['./almacen.component.scss'],
  providers: [MessageService, ConfirmationService]
})
export class AlmacenComponent implements OnInit {
  almacenes: Almacen[] = [];
  selectedAlmacenes: Almacen[] = [];
  almacenForm: FormGroup;
  displayDialog: boolean = false;
  estados: { label: string, value: string }[] = [
    { label: 'Activo', value: 'Activo' },
    { label: 'Inactivo', value: 'Inactivo' }
  ];

  constructor(
    private almacenService: AlmacenService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {
    this.almacenForm = this.fb.group({
      id: null,
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      estado: ['', Validators.required],
      direccion: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadAlmacenes();
  }

  loadAlmacenes(): void {
    this.almacenService.getAll().subscribe(
      data => {
        this.almacenes = data;
      },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Error al cargar los almacenes', life: 2000 });
      }
    );
  }

  openNew(): void {
    this.almacenForm.reset();
    this.almacenForm.patchValue({
      nombre: '',
      descripcion: '',
      estado: null,
      direccion: ''
    });
    this.displayDialog = true;
  }

  editAlmacen(almacen: Almacen): void {
    this.almacenForm.patchValue(almacen);
    this.displayDialog = true;
  }

  deleteAlmacen(id: number): void {
    this.confirmationService.confirm({
      message: '¿Está seguro de que desea eliminar este almacén?',
      header: 'Confirmación de eliminación',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass:"p-button-danger p-button-text",
      rejectButtonStyleClass:"p-button-text p-button-text",
      acceptIcon:"none",
      rejectIcon:"none",
      accept: () => {
        this.almacenService.delete(id).subscribe(
          () => {
            this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Almacén eliminado', life: 4000 });
            this.loadAlmacenes();
          },
          error => {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Error al eliminar el almacén', life: 2000 });
          }
        );
      }
    });
  }

  hideDialog(): void {
    this.displayDialog = false;
  }

  saveAlmacen(): void {
    if (this.almacenForm.invalid) {
      this.almacenForm.markAllAsTouched();
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Completar todos los campos', life: 2000 });
      return;
    }

    if (this.almacenForm.valid) {
      const almacen: Almacen = this.almacenForm.value;
      if (almacen.id) {
        this.almacenService.update(almacen.id, almacen).subscribe(() => {
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Almacén actualizado', life: 2000 });
          this.loadAlmacenes();
          this.displayDialog = false;
        });
      } else {
        this.almacenService.create(almacen).subscribe(() => {
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Almacén creado', life: 2000 });
          this.loadAlmacenes();
          this.displayDialog = false;
        });
      }
    }
  }
}
