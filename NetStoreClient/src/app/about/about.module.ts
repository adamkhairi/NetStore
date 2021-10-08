import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {AboutRoutingModule} from './about-routing.module';
import {AboutComponent} from './about.component';
import {SharedModule} from '../shared/shared.module';
import {MatIconModule} from "@angular/material/icon";

@NgModule({
  declarations: [AboutComponent],
  imports: [CommonModule, AboutRoutingModule, SharedModule, MatIconModule]
})
export class AboutModule {
}
