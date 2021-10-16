import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class SharedFunctions {
  constructor() {

  }

  //Check if Any Data in LocalStorage
  public static isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
    const expiresOn = localStorage.getItem("expiresOn");
    console.log(expiresOn)
    if (token && expiresOn != null) {
      const dateExpiry = Date.parse(expiresOn);
      return dateExpiry > Date.now();
    } else {
      return false;
    }
  }

  //Save User To LocalStorage
  public static setToLocalStorage = (data: any) => {
    localStorage.setItem('username', (<any>data).username);
    localStorage.setItem('userId', (<any>data).userId);
    localStorage.setItem('email', (<any>data).email);
    localStorage.setItem('roles', (<any>data).roles);
    localStorage.setItem('token', (<any>data).token);
    localStorage.setItem('expiresOn', (<any>data).expiresOn);
  }

  //Get User From LocalStorage
  public static getDataFromLocalStorage = () => {
    let username = localStorage.getItem('username') ?? '';
    let userId = localStorage.getItem('userId') ?? '';
    let email = localStorage.getItem('email') ?? '';
    let roles = localStorage.getItem('roles') ?? '';
    let token = localStorage.getItem('token') ?? '';
    let expiresOn = localStorage.getItem('expiresOn') ?? '';

    if (token == '') return null;

    return {
      email: email,
      expiresOn: expiresOn,
      roles: roles,
      token: token,
      userId: userId,
      username: username
    };
  }

  public static LogOut = () => {
    localStorage.removeItem('username');
    localStorage.removeItem('userId');
    localStorage.removeItem('email');
    localStorage.removeItem('roles');
    localStorage.removeItem('token');
    localStorage.removeItem('expiresOn');
    window.location.reload(true);
  }

  public static GetToken = () => {
    return localStorage.getItem('token');
  }
  // public static  getUser=(userId: string)=>{
  //   if(userId){
  //     const user =
  //   }
  // }
}

