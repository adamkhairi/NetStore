import {Injectable} from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class HomeService {
  private _baseUrl = 'https://localhost:5001'

  // public topProducts !: ProductListResponce;

  constructor() {
  }

  init() {
    // this.client.getTopProducts().subscribe((data) => {
    //   // @ts-ignore
    //   this.topProducts = data;
    // });
  }
}
