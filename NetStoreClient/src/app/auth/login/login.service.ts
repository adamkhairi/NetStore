import {Injectable} from '@angular/core';
import {Router} from "@angular/router";
import {AuthClientApi, TokenRequestModel} from "../../shared/data/Client.Api";
import {FormBuilder, Validators} from "@angular/forms";
import {SharedFunctions} from "../../shared/data/shared-functions";
import {NotificationService} from "../../shared/notification.service";

@Injectable()
export class LoginService {
  invalidLogin!: boolean;

  constructor(
      public router: Router,
      public client: AuthClientApi,
      public fb: FormBuilder,
      public notification: NotificationService,
  ) {
  }

  public loginForm = this.fb.group({
    email: ['', [Validators.required]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  })

  login() {
    const credentials = {
      ...this.loginForm.value
    }

    const model = TokenRequestModel.fromJS(credentials);

    this.client.login(model)
        .subscribe(async data => {
          const token = (<any>data).token;
          if (data.isAuthenticated) {
            SharedFunctions.setToLocalStorage(data)
            await this.router.navigate(['/']);
            this.notification.success('Welcome Back !' + data.username)
          } else {
            console.log(data.message)
          }
        }, error => {
          this.invalidLogin = true
        })
  }
}
