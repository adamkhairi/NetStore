import {Injectable} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  constructor(private snack: MatSnackBar) {
  }

  public success(message: string): void {
    this.show(message, 'success');
  }

  public warn(message: string): void {
    this.show(message, 'warning');
  }

  public error(message: string): void {
    this.show(message, 'error');
  }

  public info(message: string): void {
    this.show(message, 'info');
  }

  private show(message: string, style: 'none' | 'success' | 'warning' | 'error' | 'info') {
    this.snack.open(message, '', {
      panelClass: ['snackbar', style],
      horizontalPosition: 'center',
      verticalPosition: 'bottom',
      duration: 5000
    });
  }
}
