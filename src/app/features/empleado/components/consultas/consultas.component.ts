import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConsultasService } from '../../../../services/consultas.service';
import { Transaccion } from '../../../../models/Transaccion'; // Asegúrate de ajustar la importación al lugar correcto según tu estructura de archivos
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-consultas',
  templateUrl: './consultas.component.html',
  styleUrls: ['./consultas.component.scss']
})
export class ConsultasComponent implements OnInit {
  transacciones: Transaccion[] = [];
  consultaForm: FormGroup;
  displayDialog: boolean = false;

  constructor(
    private fb: FormBuilder,
    private consultasService: ConsultasService,
    private messageService: MessageService
  ) {
    this.consultaForm = this.fb.group({
      idArticulo: ['', Validators.required],
      fechaInicio: ['', Validators.required],
      fechaFin: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // Método opcional: carga inicial de datos o configuraciones iniciales
  }

  buscarPorArticulo(): void {
    if (this.consultaForm.controls['idArticulo'].invalid) {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Debe especificar un ID de artículo válido' });
      return;
    }

    const idArticulo = this.consultaForm.value.idArticulo;

    this.consultasService.filtrarPorArticulo(idArticulo).subscribe(
      data => {
        this.transacciones = data;
        this.displayDialog = true; // Muestra el diálogo con los resultados
      },
      error => {
        console.error('Error al buscar por artículo:', error);
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Ocurrió un error al buscar por artículo' });
      }
    );
  }

  buscarPorRangoFechas(): void {
    if (this.consultaForm.invalid) {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Debe completar las fechas de inicio y fin' });
      return;
    }

    const fechaInicio = this.consultaForm.value.fechaInicio;
    const fechaFin = this.consultaForm.value.fechaFin;

    this.consultasService.filtrarPorRangoFechas(fechaInicio, fechaFin).subscribe(
      data => {
        this.transacciones = data;
        this.displayDialog = true; // Muestra el diálogo con los resultados
      },
      error => {
        console.error('Error al buscar por rango de fechas:', error);
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Ocurrió un error al buscar por rango de fechas' });
      }
    );
  }

  hideDialog(): void {
    this.displayDialog = false;
  }

}
