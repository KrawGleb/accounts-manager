import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ComponentsModule } from './components/components.module';
import { LoginComponent } from './modules/auth/login/login.component';
import { RegistrationComponent } from './modules/auth/registration/registration.component';
import { AuthModule } from './modules/auth/auth.module';
import { AccountsTableComponent } from './components/accounts-table/accounts-table.component';
import { AuthGuard } from './modules/auth/guards/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegistrationComponent },
      { path: 'table', component: AccountsTableComponent, canActivate: [AuthGuard]  }
    ]),
    ComponentsModule,
    AuthModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
