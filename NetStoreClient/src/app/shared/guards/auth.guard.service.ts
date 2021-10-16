import {Injectable} from "@angular/core";
import {CanActivate, Router} from "@angular/router";
import {JwtHelperService} from "@auth0/angular-jwt";
import {SharedFunctions} from "../data/shared-functions";

@Injectable({
  providedIn: "root"
})
export class AuthGuardService implements CanActivate {
  constructor(private router: Router, private jwt: JwtHelperService) {
  }

  canActivate() {
    const token = SharedFunctions.GetToken();
    if (token && !this.jwt.isTokenExpired(token))
      return true;
    this.router.navigate(["auth/login"])
    return false;
  }

}
