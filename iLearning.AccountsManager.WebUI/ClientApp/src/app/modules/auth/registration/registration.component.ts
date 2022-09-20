import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'acm-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss'],
})
export class RegistrationComponent {
  public formGroup = this.formBuilder.group({
    Name: ['', Validators.required],
    Email: ['', [Validators.required, Validators.email]],
    Passwords: this.formBuilder.group({
      Password: ['', Validators.required],
      ConfirmPassword: ['', Validators.required],
    }),
  });

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly authService: AuthService
  ) {}

  public register()
  {
    let request = {
      Name: this.formGroup.value.Name,
      Email: this.formGroup.value.Email,
      Password: this.formGroup.value.Passwords.Password,
    }

    this.authService.register(request).subscribe();
  }
}
