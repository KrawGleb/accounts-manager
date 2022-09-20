import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'acm-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent{

  public formGroup = this.formBuilder.group({
    Email: [''],
    Password: ['']
  });

  constructor(private readonly formBuilder: FormBuilder)
  { }

}
