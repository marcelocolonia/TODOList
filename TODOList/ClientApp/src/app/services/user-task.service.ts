import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserTaskModel } from '../models/user-task-model';

@Injectable({
  providedIn: 'root'
})
export class UserTaskService {

  private readonly endpoint: string = 'userTasks';

  constructor(private _httpClient: HttpClient, @Inject('BASE_URL') private _baseUrl: string) { }

  public getUserTasks(): Observable<UserTaskModel[]> {

    return this._httpClient.get<UserTaskModel[]>(this._baseUrl + this.endpoint);

  }

  public addNewTask(description: string): Observable<HttpResponse<any>> {

    return this._httpClient.post<string>(this._baseUrl + this.endpoint + '/create', { description },
      {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        }),
        observe: 'response'
      }
    );

  }

}
