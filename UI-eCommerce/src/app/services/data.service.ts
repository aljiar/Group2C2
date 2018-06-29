import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs';

@Injectable()
export class DataService {
  private numberOfProducts = new Subject<number>();
   
  numberOfProducts$ = this.numberOfProducts.asObservable();

  updateData(data: number) {
      this.numberOfProducts.next(data);
  }
}