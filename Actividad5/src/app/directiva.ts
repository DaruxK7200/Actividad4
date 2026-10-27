import { Directive, ElementRef, inject } from '@angular/core';

@Directive({
  selector: '[appDirectiva]',
  host: {
    '(mouseover)': 'colorar()',
    '(mouseout)': 'decolorar()'
  }
})
export class Directiva {

  private elemento = inject(ElementRef);

  colorar() {
    this.elemento.nativeElement.style.backgroundColor = 'red';
    this.elemento.nativeElement.style.color = 'white';
  }

  decolorar() {
    this.elemento.nativeElement.style.backgroundColor = '';
    this.elemento.nativeElement.style.color = '';
  }

}