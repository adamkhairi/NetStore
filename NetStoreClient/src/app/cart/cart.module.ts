import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {CartComponent} from './cart/cart.component';
import {CartRoutingModule} from "./cart-routing.module";
import {SharedModule} from "../shared/shared.module";
import {MatExpansionModule} from "@angular/material/expansion";
import {NgParticlesModule} from "ng-particles";
import {NgxSkeletonLoaderModule} from "ngx-skeleton-loader";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    CartComponent
  ],
  imports: [
    CommonModule,
    CartRoutingModule,
    SharedModule,
    MatExpansionModule,
    NgParticlesModule,
    NgxSkeletonLoaderModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    ReactiveFormsModule,
    FormsModule,
  ]
})
export class CartModule {
}
