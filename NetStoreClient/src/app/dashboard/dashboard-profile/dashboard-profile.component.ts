import {Component, OnInit, Output} from '@angular/core';
import {ProfileService} from './profile.service';
import {UserModel} from "../../shared/data/Client.Api";

@Component({
  selector: 'app-dashboard-profile',
  templateUrl: './dashboard-profile.component.html',
  styleUrls: ['./dashboard-profile.component.scss']
})
export class DashboardProfileComponent implements OnInit {
  @Output() User!: UserModel | null;

  constructor(public service: ProfileService) {
    this.service.getUserInfo()
  }

  ngOnInit(): void {
    if (this.service.isLoading) {
      this.User = this.service.User
    }
  }
}
