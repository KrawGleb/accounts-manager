import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { catchError, of, pipe, tap } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'acm-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public formGroup = new FormGroup({
    Email: new FormControl(''),
    Password: new FormControl('')
  });

  public errorMessages: string[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly authService: AuthService,
    private readonly router: Router
  ) {}

  ngOnInit(): void {
    if (!!localStorage.getItem('token')) {
      this.router.navigateByUrl('/table');
    }
  }

  public login() {
    this.errorMessages = [];
    const request = {
      Email: this.formGroup.value.Email,
      Password: this.formGroup.value.Password,
    };

    this.authService
      .login(request)
      .pipe(
        tap((response) => {
          this.router.navigateByUrl('/table');
        }),
        catchError((err) => {
          console.log(err);

          let result = err.error.errors
            ? Object.entries(err.error.errors).map(([k, v]) => v)
            : Object.entries(err.error).map(([k, v]) => v);
          this.errorMessages = result
            .flat(1)
            .filter((error) => error) as string[];

          return of();
        })
      )
      .subscribe();
  }
}
