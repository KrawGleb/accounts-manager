import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { tap } from 'rxjs';
import { Account } from 'src/app/models/account.model';
import { AccountsService } from 'src/app/services/accounts.service';

@Component({
  selector: 'acm-accounts-table',
  templateUrl: './accounts-table.component.html',
  styleUrls: ['./accounts-table.component.scss'],
})
export class AccountsTableComponent implements OnInit {
  public displayedColumns = [
    'select',
    'id',
    'name',
    'email',
    'registrationDate',
    'lastLoginDate',
    'status',
  ];
  public dataSource = new MatTableDataSource<Account>();
  public selection = new SelectionModel<Account>(true, []);

  constructor(private readonly accountsService: AccountsService) {
    this.loadAccounts();
  }

  ngOnInit(): void {}

  public isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;

    return numSelected === numRows;
  }

  public masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.data.forEach((row) => this.selection.select(row));
  }

  public loadAccounts() {
    this.accountsService
      .getAccounts()
      .pipe(
        tap((response) => {
          this.dataSource = new MatTableDataSource<Account>(response);
          this.selection.clear();
        })
      )
      .subscribe();
  }

  public deleteSelectedAccounts() {
    this.selection.selected.forEach((account) =>
      this.accountsService
        .deleteAccountById(account.id)
        .pipe(tap(() => this.loadAccounts()))
        .subscribe()
    );
  }

  public blockSelectedAccounts() {
    this.selection.selected.forEach((account) =>
      this.accountsService
        .blockAccountById(account.id)
        .pipe(tap(() => this.loadAccounts()))
        .subscribe()
    );
  }

  public unblockSelectedAccounts() {
    this.selection.selected.forEach((account) =>
      this.accountsService
        .unblockAccountById(account.id)
        .pipe(tap(() => this.loadAccounts()))
        .subscribe()
    );
  }
}
