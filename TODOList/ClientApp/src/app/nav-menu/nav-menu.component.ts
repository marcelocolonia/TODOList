import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppRoutes } from '../app-routes';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private _router: Router,
    private _authenticationService: AuthenticationService,
  ) { }

  logout() {

    this._authenticationService.logout()
      .subscribe(_ => {

        this._router.navigate([AppRoutes.LOGIN]);

      });

  }

}
