import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, Inject } from '@angular/core';
import { RegisterModel } from 'src/app/Models/register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {


  registerModel: RegisterModel = new RegisterModel();
  confirmPassword: string = '';
  registerForm: FormGroup;


  constructor(
    @Inject(FormBuilder) private formBuilder: FormBuilder,
  ){}


  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      mobile: ['', [Validators.required, Validators.pattern(/^[0-9]{11}$/)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    }, {
      validators: this.passwordMatchValidator
    });
  }
  get f() {
    return this.registerForm.controls;
  }

  onSubmit() {
    if (this.registerForm.invalid) {
      return;
    }

    console.log(this.registerModel)
    // Form submission logic
  }

  getError(controlName: string, errorName: string): boolean | undefined {
    const control = this.registerForm.get(controlName);
    return control?.touched && control?.hasError(errorName);
  }

  passwordMatchValidator(control: AbstractControl) {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;
  
    if (password !== confirmPassword) {
      control.get('confirmPassword')?.setErrors({ passwordMismatch: true });
      return { passwordMismatch: true }; // Return an error object
    } else {
      return null; // Return null if passwords match
    }
  }
}



