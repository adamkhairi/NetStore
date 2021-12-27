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

  public getCompletedOrders() {
    return this.client.completedOrders()
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error))
        );
  }

  public getOrderById(id: string) {
    return this.client.getOrder(id)
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error))
        );
  }

  public getOrderofUser(userId: string) {
    return this.client.orderByUser(userId)
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error))
        );
  }


  public countOrders() {
    return this.client.countOrders()
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error))
        );
  }

  public markOrderCompleted(orderId: string) {
    return this.client.markOrderCompleted(orderId)
        .pipe(
            map((data) => data),
            catchError((error: any) => throwError(error))
        );
  }
}
