import { Component, OnInit } from '@angular/core';
import { UserTaskModel } from '../../models/user-task-model';
import { UserTaskService } from '../../services/user-task.service';

@Component({
  selector: 'app-user-task-list',
  templateUrl: './user-task-list.component.html',
  styleUrls: ['./user-task-list.component.css']
})
export class UserTaskListComponent implements OnInit {

  public userTasks: UserTaskModel[] = [];

  constructor(private _userTaskService: UserTaskService) { }

  ngOnInit() {

    return this.loadUserTasks();

  }

  private loadUserTasks() {
    return this._userTaskService.GetUserTasks()
      .subscribe((userTasks: UserTaskModel[]) => {

        this.userTasks = userTasks;

      },
        error => {

          console.log(' error while fetching user tasks ' + error);

        });
  }
}
