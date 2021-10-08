import {Injectable} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {AuthClientApi, RegisterModel} from 'src/app/app.component';
import {Router} from "@angular/router";


@Injectable({
  providedIn: 'root'
})
export class SignupService {
  private _baseUrl = 'https://localhost:5001'

  constructor(private client: AuthClientApi, public router: Router, public fb: FormBuilder) {
  }

  public register!: RegisterModel;

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
    const obj = {
      ...this.signupForm.value
    };

    const model = RegisterModel.fromJS(obj);
    this.client.register(model)
      .pipe(

      )
      .subscribe(data => {
        console.log(data)
        if (data) {
          this.router.navigate(['/']);
        }
      })

  }
}
