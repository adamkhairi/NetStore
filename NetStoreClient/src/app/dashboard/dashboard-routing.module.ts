import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {DashboardIndexComponent} from './dashboard-index/dashboard-index.component';
import {DashboardLayoutComponent} from './dashboard-layout/dashboard-layout.component';
import {DashboardOrderComponent} from './dashboard-order/dashboard-order.component';
import {DashboardProfileComponent} from './dashboard-profile/dashboard-profile.component';
import {DashboardSavedItemComponent} from './dashboard-saved-item/dashboard-saved-item.component';
import {DashboardProductsComponent} from "./dashboard-products/dashboard-products.component";
import {DashboardCategoriesComponent} from "./dashboard-categories/dashboard-categories.component";
import {DashboardUsersComponent} from "./dashboard-users/dashboard-users.component";
import {AuthGuardService} from "../shared/guards/auth.guard.service";

const DashboardChildrenRoute: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: DashboardIndexComponent,
    canActivate: [AuthGuardService],
  },
  {
    path: 'saved-items',
    component: DashboardSavedItemComponent
  },
  {
    path: 'profile',
    component: DashboardProfileComponent
  },
  {
    path: 'orders',
    component: DashboardOrderComponent
  },
  {
    path: 'products',
    component: DashboardProductsComponent
  },
  {
    path: 'categories',
    component: DashboardCategoriesComponent
  },
  {
    path: 'users',
    component: DashboardUsersComponent
  }
];

const routes: Routes = [
  {
    path: '',
    component: DashboardLayoutComponent,
    children: DashboardChildrenRoute
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {
}
