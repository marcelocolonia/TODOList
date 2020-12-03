import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UserTaskListComponent } from './components/user-task-list/user-task-list.component';
import { NewUserTaskFormComponent } from './components/new-user-task-form/new-user-task-form.component';
import { AppRoutes } from './app-routes';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UserTaskListComponent,
    NewUserTaskFormComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: UserTaskListComponent, pathMatch: 'full' },
      { path: AppRoutes.USER_TASK_LIST, component: UserTaskListComponent },
      { path: AppRoutes.NEW_USER_TASK, component: NewUserTaskFormComponent },
      { path: AppRoutes.LOGIN, component: LoginComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


