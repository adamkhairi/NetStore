import {Component, OnInit} from '@angular/core';
import {LoginService} from '../../shared/services/auth/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [LoginService]
})
export class LoginComponent implements OnInit {

  constructor(public service: LoginService) {
  }

  ngOnInit(): void {
  }

}
