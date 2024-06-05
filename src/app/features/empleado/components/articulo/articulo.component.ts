import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ArticuloService } from '../../../../services/articulo.service';
import { TipoInventarioService } from '../../../../services/TipoInventario.service';
import { Articulo } from '../../../../models/Articulo';
import { TipoInventario } from '../../../../models/TipoInventario';
import { ConfirmationService, MessageService } from 'primeng/api';

interface Estado {
  label: string;
  value: string;
}

@Component({
  selector: 'app-articulo',
  templateUrl: './articulo.component.html',
  styleUrl: './articulo.component.scss'
})
export class ArticuloComponent implements OnInit {
  articulos: Articulo[] = [];
  tiposInventario: TipoInventario[] = [];
  displayDialog: boolean = false;
  articuloForm: FormGroup;
  isNew: boolean = false;
  selectedArticulos: Articulo[] = [];
  estados: Estado[] | undefined;
  selectedTipoInventario: TipoInventario | undefined;

  constructor(
    private fb: FormBuilder,
    private articuloService: ArticuloService,
    private tipoInventarioService: TipoInventarioService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {
    this.articuloForm = this.fb.group({
      id: [''],
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      estado: ['', Validators.required],
      idTipoInventario: ['', Validators.required],
      costoUnitario: ['', Validators.required],
      existencia: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadArticulos();
    this.loadTiposInventario();
    this.estados = [
      { label: 'Activo', value: 'activo' },
      { label: 'Inactivo', value: 'inactivo' }
    ];
  }

  loadArticulos(): void {
    this.articuloService.getArticulos().subscribe((data: Articulo[]) => {
      this.articulos = data;
    });
  }

  loadTiposInventario(): void {
    this.tipoInventarioService.getTipoInventarios().subscribe((data: TipoInventario[]) => {
      this.tiposInventario = data;
    });
  }

  openNew(): void {
    this.isNew = true;
    this.articuloForm.reset();
    this.articuloForm.patchValue({ estado: 'activo' });
    this.displayDialog = true;
  }

  editArticulo(articulo: Articulo): void {
    this.isNew = false;
    this.articuloForm.patchValue(articulo);
    this.displayDialog = true;
  }

  deleteArticulo(id: number): void {
    this.confirmationService.confirm({
      message: '¿Estás seguro de que quieres eliminar este artículo?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: "p-button-danger p-button-text",
      rejectButtonStyleClass: "p-button-text p-button-text",
      acceptIcon: "none",
      rejectIcon: "none",
      accept: () => {
        this.articuloService.deleteArticulo(id).subscribe(() => {
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Artículo eliminado' });
          this.loadArticulos();
        });
      }
    });
  }

  saveArticulo(): void {
    if (this.articuloForm.invalid) {
      this.articuloForm.markAllAsTouched();
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Completar Campos', life: 2000 });
      return;
    }
  
    const articulo:any = this.articuloForm.value as Articulo;
  
    if (this.isNew) {
      this.articuloService.createArticulo(articulo).subscribe(() => {
        this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Artículo creado' });
        this.loadArticulos();
        this.displayDialog = false;
      });
    } else {
      this.articuloService.updateArticulo(articulo.id, articulo).subscribe(() => {
        this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Artículo actualizado' });
        this.loadArticulos();
        this.displayDialog = false;
      });
    }
  }
  
  hideDialog(): void {
    this.displayDialog = false;
  }

  deleteSelectedArticulos(): void {
    this.confirmationService.confirm({
      message: '¿Estás seguro de que quieres eliminar los artículos seleccionados?',
      accept: () => {
        const deleteRequests = this.selectedArticulos.map(articulo => this.articuloService.deleteArticulo(articulo.id!));
        Promise.all(deleteRequests).then(() => {
          this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Artículos eliminados' });
          this.loadArticulos();
          this.selectedArticulos = [];
        });
      }
    });
  }
}
