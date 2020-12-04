import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AppRoutes } from '../../app-routes';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  public errorMessage: string;

  public get isFormValid(): boolean {
    return this.loginForm.valid;
  }

  constructor(private _router: Router,
    private _formBuilder: FormBuilder,
    private _authenticationService: AuthenticationService,
  ) { }

  ngOnInit() {

    this.configureForm();

  }

  private configureForm() {
    this.loginForm = this._formBuilder.group({
      userName: '',
      password: ''
    });
  }

  public login(): void {

    //  todo: find a way to type safe this
    this._authenticationService.login(
      this.loginForm.get('userName').value,
      this.loginForm.get('password').value,
    )
      .subscribe((response: HttpResponse<any>) => {

        this._router.navigate([AppRoutes.USER_TASK_LIST]);

      },
        error => {

          this.errorMessage = 'User name and/or password invalid';

        });

  }

}
