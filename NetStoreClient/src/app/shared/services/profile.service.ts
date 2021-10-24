import {Injectable} from '@angular/core';
import {UserModel, UsersClientApi} from "../data/Client.Api";
import {SharedFunctions} from "../data/shared-functions";
import {finalize} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  public User !: UserModel;
  public isLoaded!: boolean;

  constructor(private client: UsersClientApi) {
  }

  public getUserInfo() {
    const userId = SharedFunctions.UserId()
    if (userId == null) return;
    this.isLoaded = false

    this.client.getUser(userId)
        .pipe(finalize(() => {
          this.isLoaded = true
        }))
        .subscribe(data => {
          this.User = data;

          console.log(data)
        }, err => {
          console.log(err)
        });
  }
}
