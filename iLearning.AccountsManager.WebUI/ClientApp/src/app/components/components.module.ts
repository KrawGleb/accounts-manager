import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { AccountsTableComponent } from './accounts-table/accounts-table.component';

import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    HeaderComponent,
    AccountsTableComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatCheckboxModule,
    MatButtonModule
  ],
  exports: [
    HeaderComponent,
  ]
})
export class ComponentsModule { }
