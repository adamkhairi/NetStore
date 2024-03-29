﻿import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {HomeRoutingModule} from './home-routing.module';
import {HomeComponent} from './home.component';
import {SharedModule} from '../shared/shared.module';
import {HomeProductsComponent} from './home-products/home-products.component';
import {NgParticlesModule} from 'ng-particles';

import {MatIconModule} from "@angular/material/icon";
import {MatCardModule} from "@angular/material/card";
import {MatButtonModule} from "@angular/material/button";
import {NgxSkeletonLoaderModule} from "ngx-skeleton-loader";

@NgModule({
  declarations: [HomeComponent, HomeProductsComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule,
    NgParticlesModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    NgxSkeletonLoaderModule,

  ]
})
export class HomeModule {
}
