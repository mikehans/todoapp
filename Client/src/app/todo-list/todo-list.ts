import { Component } from '@angular/core';
import { AddTodo } from '../add-todo/add-todo';
import { TodoModel } from '../models/todo-model';
import { MaterialModule } from '../material/material-module';

@Component({
  selector: 'app-todo-list',
  imports: [AddTodo, MaterialModule],
  templateUrl: './todo-list.html',
  styleUrl: './todo-list.scss',
})
export class TodoList {
  listItems: TodoModel[] = [
    {
      id: 1,
      title: 'Add a todo',
      description: 'You have to start somewhere',
    },
    {
      id: 2,
      title: 'Mark "Add a todo" (and also this todo) as done',
    },
  ];

  onAddTodo(newTodo: TodoModel): void {
    let nextId = Math.max(...this.listItems.map((it) => it.id)) + 1;

    this.listItems.push({ ...newTodo, id: nextId });
  }

  completeTask(isComplete: boolean, id: number): void {
    const item = this.listItems.find((it) => it.id == id);
    if (item) {
      item.isCompleted = !item.isCompleted;
    }
  }

  slideToggleChanged(ev: any, id: number): void {
    const item = this.listItems.find((it) => it.id == id);
    if (item) {
      item.isCompleted = !item.isCompleted;
    }
  }
}
