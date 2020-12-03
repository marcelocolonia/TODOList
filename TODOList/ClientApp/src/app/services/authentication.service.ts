import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private readonly endpoint: string = 'user';

  constructor(private _httpClient: HttpClient, @Inject('BASE_URL') private _baseUrl: string) { }

  public login(userName: string, password: string): Observable<HttpResponse<any>> {

    return this._httpClient.post<string>(this._baseUrl + this.endpoint, { userName, password },
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        }),
        observe: 'response'
      }
    );

  }

}
