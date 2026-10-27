import { Component, inject, OnInit, signal } from '@angular/core';
import { ProductoService } from '../Service/ProductoService';
import { Producto } from '../Models/ProductoModels';
import { PipePersonalizadoPipe } from '../pipe-personalizado-pipe';
import { Directiva } from '../directiva';
import { ProductoCard } from '../producto-card/producto-card';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-producto-list',
  imports: [
    PipePersonalizadoPipe,
    Directiva,
    ProductoCard,
    FormsModule
  ],
  templateUrl: './producto-list.html',
  styleUrl: './producto-list.css'
})
export class ProductoList implements OnInit {

  private readonly productoService =
    inject(ProductoService);

  readonly productos =
    signal<Producto[]>([]);
    nombre = '';
    precio = 0;
    stock = 0;
    categoriaId = 1;

  ngOnInit(): void {
    this.cargarProductos();
  }

  cargarProductos(): void {
    this.productoService.getProductos()
      .subscribe({
        next: (data) => {
          this.productos.set(data);
        },
        error: (error) => {
          console.error(error);
        }
      });
  }

  eliminarProducto(id: number) {

  this.productoService
    .deleteProducto(id)
    .subscribe({

      next: () => {
        this.cargarProductos();
      },

      error: (error) => {
        console.error(error);
      }

    });
  }

  guardarProducto() {

  const nuevoProducto = {
    nombre: this.nombre,
    precio: this.precio,
    stock: this.stock,
    categoriaId: this.categoriaId
  };

  if (this.editandoId !== null) {
    this.productoService
      .updateProducto(
        this.editandoId,
        nuevoProducto
      )
      .subscribe({
        next: () => {
          this.cargarProductos();
          this.limpiarFormulario();
        },
        error: (error) => {
          console.error(error);
        }
      });

  } else {
    this.productoService
      .createProducto(nuevoProducto)
      .subscribe({
        next: () => {
          this.cargarProductos();
          this.limpiarFormulario();
        },
        error: (error) => {
          console.error(error);
        }
      });
  }

  this.productoService
    .createProducto(nuevoProducto)
    .subscribe({

      next: () => {
        this.cargarProductos();
        this.nombre = '';
        this.precio = 0;
        this.stock = 0;
      },

      error: (error) => {
        console.error(error);
      }
    });
  }
  editandoId: number | null = null;

  editarProducto(producto: Producto) {
  this.editandoId = producto.id;
  this.nombre = producto.nombre;
  this.precio = producto.precio;
  this.stock = producto.stock;
}
  limpiarFormulario(){
    this.nombre = '';
    this.precio = 0;
    this.stock = 0;
    this.editandoId = null;
  }
}
