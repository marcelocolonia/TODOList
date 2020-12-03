import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserTaskModel } from '../models/user-task-model';

@Injectable({
  providedIn: 'root'
})
export class UserTaskService {

  constructor(private _httpClient: HttpClient, @Inject('BASE_URL') private _baseUrl: string) { }

  public GetUserTasks(): Observable<UserTaskModel[]> {

    return this._httpClient.get<UserTaskModel[]>(this._baseUrl + 'userTasks');

  }

}
