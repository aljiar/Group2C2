import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs';

@Injectable()
export class DataService {
  private numberOfProducts = new Subject<number>();
  private reset = new Subject<boolean>();
   
  numberOfProducts$ = this.numberOfProducts.asObservable();
  reset$ = this.reset.asObservable();

  updateData(data: number) {
      this.numberOfProducts.next(data);
  }

  resetData(data: boolean) {
    this.reset.next(data);
  }
}