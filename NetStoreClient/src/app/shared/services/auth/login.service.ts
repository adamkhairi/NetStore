import {Injectable} from '@angular/core';
import {Router} from "@angular/router";
import {AuthClientApi, TokenRequestModel} from "../../data/Client.Api";
import {FormBuilder, Validators} from "@angular/forms";
import {SharedFunctions} from "../../data/shared-functions";
import {NotificationService} from "../notification.service";
import {finalize, map} from "rxjs/operators";

@Injectable()
export class LoginService {
  invalidLogin!: boolean;
  public error: string | undefined;

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
        .pipe(finalize(() => {
              //TODO!! Show Responce.Message
              this.notification.error(this.error as string)

            }),
            map((response) => {
              // this.notification.error(response as string)
              return response
            }),
        )
        .subscribe(async data => {
          // const token = (<any>data).token;
          if (data.isAuthenticated) {
            SharedFunctions.setToLocalStorage(data);
            await this.router.navigate(['/']);
            this.notification.success('Welcome Back !' + data.username);
          } else {
            console.log(data);
            this.error = data.message;
          }
        })
  }
}
