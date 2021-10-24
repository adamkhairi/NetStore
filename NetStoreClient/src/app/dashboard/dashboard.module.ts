import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {DashboardRoutingModule} from './dashboard-routing.module';
import {DashboardLayoutComponent} from './dashboard-layout/dashboard-layout.component';
import {DashboardIndexComponent} from './dashboard-index/dashboard-index.component';
import {SharedModule} from '../shared/shared.module';
import {DashboardSavedItemComponent} from './dashboard-saved-item/dashboard-saved-item.component';
import {DashboardProfileComponent} from './dashboard-profile/dashboard-profile.component';
import {DashboardOrderComponent} from './dashboard-order/dashboard-order.component';
import {DashboardProductsComponent} from './dashboard-products/dashboard-products.component';
import {DashboardCategoriesComponent} from './dashboard-categories/dashboard-categories.component';
import {DashboardUsersComponent} from './dashboard-users/dashboard-users.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    DashboardLayoutComponent,
    DashboardIndexComponent,
    DashboardSavedItemComponent,
    DashboardProfileComponent,
    DashboardOrderComponent,
    DashboardProductsComponent,
    DashboardCategoriesComponent,
    DashboardUsersComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
  ]
  ,
  exports: [
    DashboardProductsComponent,
    DashboardCategoriesComponent,
    DashboardUsersComponent,

  ]
})
export class DashboardModule {
}
