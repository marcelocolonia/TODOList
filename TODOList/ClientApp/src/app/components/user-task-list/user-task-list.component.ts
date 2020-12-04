import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppRoutes } from '../../app-routes';
import { UserTaskModel } from '../../models/user-task-model';
import { UserTaskService } from '../../services/user-task.service';
import * as HttpStatus from 'http-status-codes';

@Component({
  selector: 'app-user-task-list',
  templateUrl: './user-task-list.component.html',
  styleUrls: ['./user-task-list.component.css']
})
export class UserTaskListComponent implements OnInit {

  public userTasks: UserTaskModel[] = [];

  constructor(private _userTaskService: UserTaskService,
    private _router: Router
  ) { }

  public get isListEmpty(): boolean {
    return this.userTasks.length == 0;
  }

  ngOnInit() {

    return this.loadUserTasks();

  }

  private loadUserTasks() {
    return this._userTaskService.getUserTasks()
      .subscribe((userTasks: UserTaskModel[]) => {

        this.userTasks = userTasks;

      },
        error => {

          if (error.status == HttpStatus.UNAUTHORIZED) {
            this._router.navigate([AppRoutes.LOGIN]);
          }
          else {
            console.log(' error while fetching user tasks ' + error);
          }

        });
  }

  public showNewTaskForm(): void {

    this._router.navigate([AppRoutes.NEW_USER_TASK]);

  }

  public deleteSelectedTasks(): void {

    this._userTaskService.deleteUserTasks(this.userTasks.filter(x => x.selected).map(x => x.id))
      .subscribe((userTasks: HttpResponse<any>) => {

        this.loadUserTasks();

      },
        error => {

          if (error.status == HttpStatus.UNAUTHORIZED) {
            this._router.navigate([AppRoutes.LOGIN]);
          }
          else {
            console.log(' error while deleting user tasks ' + error);
          }          

        });

  }

}
