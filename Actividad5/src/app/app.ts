import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductoList } from './producto-list/producto-list';

@Component({
  imports: [RouterOutlet, ProductoList],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('Actividad5');
}
