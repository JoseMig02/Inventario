// src/app/components/tipo-inventario/tipo-inventario.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { TipoInventarioService } from '../../../../services/TipoInventario.service';
import { TipoInventario } from '../../../../models/TipoInventario';

@Component({
  selector: 'app-tipo-inventario',
  templateUrl: './tipo-inventario.component.html',
  styleUrls: ['./tipo-inventario.component.scss'],
  providers: [MessageService, ConfirmationService]
})
export class TipoInventarioComponent implements OnInit {
  tipoInventarios: TipoInventario[] = [];
  selectedTipoInventarios: TipoInventario[] = [];
  tipoInventarioForm: FormGroup;
  displayDialog: boolean = false;
  estados: { label: string, value: string }[] = [
    { label: 'Activo', value: 'Activo' },
    { label: 'Inactivo', value: 'Inactivo' }
  ];

  constructor(
    private tipoInventarioService: TipoInventarioService,
    private fb: FormBuilder,
    private messageService: MessageService,
    private confirmationService: ConfirmationService
  ) {
    this.tipoInventarioForm = this.fb.group({
      id: null,
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      cuentaContable: ['', Validators.required],
      estado: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadTipoInventarios();
  }

  loadTipoInventarios(): void {
    this.tipoInventarioService.getTipoInventarios().subscribe(
      data => {
        this.tipoInventarios = data;
      },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Error al cargar los tipos de inventario', life: 2000 });
      }
    );
  }

  openNew(): void {
    this.tipoInventarioForm.reset();
    this.tipoInventarioForm.patchValue({
     
      nombre: '',
      descripcion: '',
      cuentaContable: '',
      estado: null
    });
    this.displayDialog = true;
  }

  editTipoInventario(tipoInventario: TipoInventario): void {
    this.tipoInventarioForm.patchValue(tipoInventario);
    this.displayDialog = true;
  }

  deleteTipoInventario(id: number): void {
    this.confirmationService.confirm({
      message: '¿Está seguro de que desea eliminar este tipo de inventario?',
      header: 'Confirmación de eliminación',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass:"p-button-danger p-button-text",
      rejectButtonStyleClass:"p-button-text p-button-text",
      acceptIcon:"none",
      rejectIcon:"none",
      accept: () => {
        this.tipoInventarioService.deleteTipoInventario(id).subscribe(
          () => {
            this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Tipo de inventario eliminado', life: 4000 });
            this.loadTipoInventarios();
          },
          error => {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Error al eliminar el tipo de inventario', life: 2000 });
          }
        );
      }
    });
  }

  hideDialog(): void {
    this.displayDialog = false;
  }

  saveTipoInventario(): void {
    if (this.tipoInventarioForm.invalid) {
      this.tipoInventarioForm.markAllAsTouched();
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Completar todos los campos', life: 2000 });
      return;
    }

    if (this.tipoInventarioForm.valid) {
      const tipoInventario: TipoInventario = this.tipoInventarioForm.value;
      console.log(tipoInventario)
      if (tipoInventario.id) {
        this.tipoInventarioService.updateTipoInventario(tipoInventario.id, tipoInventario).subscribe(() => {
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Tipo de inventario actualizado', life: 2000 });
          this.loadTipoInventarios();
          this.displayDialog = false;
        });
      } else {
        this.tipoInventarioService.createTipoInventario(tipoInventario).subscribe(() => {
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Tipo de inventario creado', life: 2000 });
          this.loadTipoInventarios();
          this.displayDialog = false;
        });
      }
    }
  }
}
