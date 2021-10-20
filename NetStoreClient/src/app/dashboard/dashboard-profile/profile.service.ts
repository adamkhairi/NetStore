import {Injectable} from '@angular/core';
import {UserModel, UsersClientApi} from "../../shared/data/Client.Api";
import {SharedFunctions} from "../../shared/data/shared-functions";
import {finalize} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  public User !: UserModel;
  public isLoading: boolean = false;

  constructor(private client: UsersClientApi) {
  }

  public getUserInfo() {
    const userId = SharedFunctions.UserId()
    if (userId == null) return;
    this.isLoading = true

    this.client.getUser(userId)
        .pipe(finalize(() => {
          this.isLoading = false
        }))
        .subscribe(data => {
          this.User = data;

          console.log(data)
        }, err => {
          console.log(err)
        });
  }
}
