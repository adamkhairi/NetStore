import {Injectable} from '@angular/core';
import {OrdersClientApi} from "../data/Client.Api";
import {catchError, map} from "rxjs/operators";
import {throwError} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(private client: OrdersClientApi) {
  }

  public getPendingOrders() {

    return this.client.pendingOrders()
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error))
        );
  }
}
