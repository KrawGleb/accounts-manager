import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account } from '../models/account.model';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  private readonly BASE_URL = 'https://localhost:7286/api';


  constructor(private readonly httpClient: HttpClient) { }

  public getAccounts() {
    const tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + localStorage.getItem('token')});
    return this.httpClient.get<Account[]>(this.BASE_URL + '/accounts', {headers: tokenHeader})
  }
}
