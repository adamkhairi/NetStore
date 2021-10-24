import {Component, OnInit} from '@angular/core';
import {OrdersService} from "../../shared/services/orders.service";
import {finalize, map} from "rxjs/operators";

@Component({
  selector: 'app-dashboard-index',
  templateUrl: './dashboard-index.component.html',
  styleUrls: ['./dashboard-index.component.scss']
})
export class DashboardIndexComponent implements OnInit {
  orders: any[] = [];
  public isLoaded!: boolean;

  constructor(public service: OrdersService) {
  }

  ngOnInit(): void {
    this.isLoaded = false;
    this.service.getPendingOrders()
        .pipe(
            map((data) => data),
            finalize(() => {
              this.isLoaded = true
            })
        ).subscribe();

    this.orders = [
      {
        id: 'e5dcdfsf',
        orderBy: 'Dean Lynch',
        productId: 'cdfsfe5d',
        created: '25.05.2021, 10:00',
        status: 'complated',
        price: 2145.0
      },
      {
        id: 'e5dcdfsf',
        orderBy: 'Lynch Dean',
        productId: 'cdfsfe5d',
        created: '25.05.2021, 10:00',
        status: 'pending',
        price: 2145.0
      },
      {
        id: 'e5dcdfsf',
        orderBy: 'Lynch Dean',
        productId: 'cdfsfe5d',
        created: '25.05.2021, 10:00',
        status: 'rejected',
        price: 2145.0
      },
      {
        id: 'e5dcdfsf',
        orderBy: 'Dean Lynch',
        productId: 'cdfsfe5d',
        created: '25.05.2021, 10:00',
        status: 'initialized',
        price: 2145.0
      },
      {
        id: 'e5dcdfsf',
        orderBy: 'Dean Lynch',
        productId: 'cdfsfe5d',
        created: '25.05.2021, 10:00',
        status: 'complated',
        price: 2145.0
      }
    ];
  }
}
