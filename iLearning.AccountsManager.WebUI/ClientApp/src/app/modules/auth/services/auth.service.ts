import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RegistrationRequest } from '../models/registration-request.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly BASE_URL = 'https://localhost:7286';

  constructor(private readonly httpClient: HttpClient) {}

  public register(registrationRequest: RegistrationRequest): Observable<any> {
    return this.httpClient.post(
      this.BASE_URL + '/api/Auth/register',
      registrationRequest
    );
  }
}
