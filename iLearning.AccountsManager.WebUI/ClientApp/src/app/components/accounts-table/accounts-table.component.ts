import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs';
import { Account } from 'src/app/models/account.model';
import { AccountsService } from 'src/app/services/accounts.service';

@Component({
  selector: 'acm-accounts-table',
  templateUrl: './accounts-table.component.html',
  styleUrls: ['./accounts-table.component.scss'],
})
export class AccountsTableComponent implements OnInit {
  public accounts: Account[] = [];

  constructor(private readonly accountsService: AccountsService) {}

  ngOnInit(): void {
    this.accountsService
      .getAccounts()
      .pipe(
        tap((response) => {
          console.log(response);
          this.accounts = response;
        })
      )
      .subscribe();
  }

  public dateToString(date: Date) {
    return `${date.getDay()}.${date.getMonth()}.${date.getFullYear()}`
  }
}
