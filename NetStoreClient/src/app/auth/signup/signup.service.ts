import {Injectable} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {AuthClientApi, RegisterModel} from 'src/app/app.component';
import {Router} from "@angular/router";
import {NotificationService} from "../../shared/notification.service";
import {HttpClient} from "@angular/common/http";
import {finalize} from "rxjs/operators";
import {SharedFunctions} from "../../shared/data/shared-functions";


@Injectable()
export class SignupService {

  constructor(
      private client: AuthClientApi,
      public router: Router,
      public fb: FormBuilder,
      public http: HttpClient,
      public notification: NotificationService,
  ) {
    // this.client = new AuthClientApi(this.http);
  }

  public register!: RegisterModel;
  public isLoading = false;
  public signupForm = this.fb.group({
    firstName: [null, [Validators.required]],
    lastName: [null, [Validators.required]],
    username: [null, [Validators.required]],
    email: [null, [Validators.email, Validators.required]],
    password: [null, [Validators.required]],
    birthDate: [null, []],
    gender: [null, []],
    address: [null, [Validators.required]],
    country: [null, [Validators.required]],
    state: [null, [Validators.required]],
    city: [null, [Validators.required]],
    zipCode: [null, [Validators.required]]
  });

  public onSubmit() {
    this.isLoading = true;
    const obj = {
      ...this.signupForm.value
    };

    const model = RegisterModel.fromJS(obj);
    this.client.register(model)
        .pipe(
            finalize(() => this.isLoading = false)
        )
        .subscribe(async data => {
          console.log(data)
          if (data.message == null && data.isAuthenticated) {
            SharedFunctions.setToLocalStorage(data)
            await this.router.navigate(['/']);
            this.notification.success('Welcome ' + data.username)
          } else {
            this.notification.error(data.message as string)
          }
        })

  }
}
