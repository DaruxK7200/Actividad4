import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Producto } from '../Models/ProductoModels';
import { API_CONFIG } from '../Core/api.config';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private readonly http = inject(HttpClient);

  private readonly url =
    `${API_CONFIG.baseURL}/productos`;

  getProductos(): Observable<Producto[]> {
    return this.http.get<Producto[]>(this.url);
  }

  deleteProducto(id: number) {
    return this.http.delete<boolean>(
      `${this.url}/${id}`
    );
  }
  createProducto(producto: any) {
    return this.http.post(
      this.url,
      producto
    );
  }
  updateProducto(id:number, producto:any) {

  return this.http.patch(
    `${this.url}/${id}`,
    producto
  );
}
 
}