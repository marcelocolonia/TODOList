import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AppRoutes } from '../../app-routes';
import { UserTaskService } from '../../services/user-task.service';

@Component({
  selector: 'app-new-user-task-form',
  templateUrl: './new-user-task-form.component.html',
  styleUrls: ['./new-user-task-form.component.css']
})
export class NewUserTaskFormComponent implements OnInit {

  public newTaskForm: FormGroup;

  public get isFormValid(): boolean {
    return this.newTaskForm.valid;
  }

  constructor(private _router: Router,
    private _formBuilder: FormBuilder,
    private _userTaskService: UserTaskService,
  ) { }

  ngOnInit() {

    this.configureForm();

  }

  private configureForm() {
    this.newTaskForm = this._formBuilder.group({
      description: ''
    });
  }

  public showTaskList(): void {

    this._router.navigate([AppRoutes.USER_TASK_LIST]);

  }

  public saveTask(): void {

    //  todo: find a way to type safe this
    this._userTaskService.addNewTask(this.newTaskForm.get('description').value)
      .subscribe((response: HttpResponse<any>) => {

        this._router.navigate([AppRoutes.USER_TASK_LIST]);

      },
        error => {

          console.log('could not add new task ' + error);

        });

  }

}
