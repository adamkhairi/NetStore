import {Component, OnInit} from '@angular/core';
import {SignupService} from "./signup.service";

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
  providers: [SignupService]
})
export class SignupComponent implements OnInit {

  constructor(public service: SignupService) {
  }

  ngOnInit(): void {
  }

}
