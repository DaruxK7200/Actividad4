import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Producto } from '../Models/ProductoModels';
import { PipePersonalizadoPipe } from '../pipe-personalizado-pipe';

@Component({
  imports: [PipePersonalizadoPipe],
  selector: 'app-producto-card',
  templateUrl: './producto-card.html',
  styleUrl: './producto-card.css'
})
export class ProductoCard {

  @Input()
  producto!: Producto;

  @Output()
  eliminar = new EventEmitter<number>();

  onEliminar() {
  this.eliminar.emit(this.producto.id);
  }
  @Output()
  editar = new EventEmitter<Producto>();

  onEditar() {
    this.editar.emit(this.producto);
  }

}
