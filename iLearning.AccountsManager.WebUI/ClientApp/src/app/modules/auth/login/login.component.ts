import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { pipe, tap } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'acm-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public formGroup = this.formBuilder.group({
    Email: [''],
    Password: [''],
  });

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
    const request = {
      Email: this.formGroup.value.Email,
      Password: this.formGroup.value.Password,
    };

    this.authService
      .login(request)
      .pipe(
        tap((response) => {
          this.router.navigateByUrl('/table')
        })
      )
      .subscribe();
  }
}
