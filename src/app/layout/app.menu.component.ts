import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';
import { EmpleadoService } from '../services/empleado.service';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];

    constructor(
        public layoutService: LayoutService,
        private empleadoService: EmpleadoService
    ) { }

    async ngOnInit() {
        // Verificar si el usuario es administrador
        const esAdmin =  this.empleadoService.isAdmin();

        this.model = [
            {
                label: 'Home',
                items: [
                    { label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] }
                ]
            },
            {
                label: 'Menu',
                items: [
                   
                    { label: 'Tipo de inventario', icon: 'pi pi-fw pi-share-alt', routerLink: ['/empleado/Tipoinventario'] },
                    { label: 'Almacenes', icon: 'pi pi-fw pi-share-alt', routerLink: ['/empleado/Almacen'] },
                    { label: 'Articulos', icon: 'pi pi-fw pi-share-alt', routerLink: ['/empleado/Articulos'] },
                    { label: 'Transacciones', icon: 'pi pi-fw pi-share-alt', routerLink: ['/empleado/Transacciones'] },
                    { label: 'Consultas', icon: 'pi pi-fw pi-share-alt', routerLink: ['/empleado/consultas'] }
                
                    
                ]
            }
        ];

        // Si el usuario es administrador, agregar el ítem de Empleados
        // if (esAdmin) {
        //     this.model[1].items.push(
        //         { label: 'Empleados', icon: 'pi pi-fw pi-users', routerLink: ['/empleado/empleados'] }
        //     );
        // }
    }
}
