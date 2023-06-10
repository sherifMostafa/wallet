import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string;
  password: string;

  login(): void {
    // Perform login logic here
    // You can use a service to communicate with the backend or simulate the login process
  }
}
