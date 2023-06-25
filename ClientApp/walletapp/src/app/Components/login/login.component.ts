import { AuthenticationService } from './../../DataServices/Authentication.service';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthModel } from 'src/app/Models/Authentication/AuthModel';
import { LoginModel } from 'src/app/Models/loginModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

   loginForm: FormGroup;
   loginModel: LoginModel;
   authModel: AuthModel;

  constructor(
    @Inject(FormBuilder) private formBuilder: FormBuilder,
    private authService : AuthenticationService,
    private router: Router,
    ) {}

  ngOnInit(): void {

    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/user-profile']);
    }

    this.loginModel = new LoginModel();
    this.loginForm = this.formBuilder.group({
      mobileNumber: ['', [Validators.required, Validators.pattern(/^[0-9]{11}$/)]],
      password: ['', Validators.required]
    });
  }


  getError(controlName: string, errorName: string): boolean {
    return this.loginForm.controls[controlName].hasError(errorName);
  }

  get f() {
    return this.loginForm.controls;
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      return;
    }

    this.authService.login(this.loginModel)
    .subscribe({
      next: (authData) => {
        this.authModel = authData;
        this.authService.saveAurhData(this.authModel);
        this.router.navigate(["user-profile"]);
      },
      error: (e) => {
        console.error(e)
      },
      complete: () => {
      } 
    })
    this.loginForm.reset();
  }
}
