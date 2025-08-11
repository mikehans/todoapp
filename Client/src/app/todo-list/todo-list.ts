import { Component } from '@angular/core';
import { AddTodo } from '../add-todo/add-todo';
import { TodoModel } from '../models/todo-model';
import { MaterialModule } from '../material/material-module';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-todo-list',
  imports: [AddTodo, MaterialModule],
  templateUrl: './todo-list.html',
  styleUrl: './todo-list.scss',
})
export class TodoList {
  listItems: TodoModel[] = [];


  constructor(private api:ApiService){}

  ngOnInit(): void {
    this.api.getAll().subscribe({
      next: (value: TodoModel[]) => {
        this.listItems = value;
        console.log('this.listItems', this.listItems)
      },
      error: (err) => console.log('err', err)
    });
  }

  onAddTodo(newTodo: TodoModel): void {
    this.api.addTodo(newTodo).subscribe({
      next: (value: TodoModel) => {
        console.log('add todo value', value);
        this.listItems.push(value);
      },
      error: (err: any) => console.log('err', err)
    });
  }

  completeTask(id: number): void {
    console.log('called completetask with id:', id)
    this.api.toggleComplete(id).subscribe({
      next: (value: any) => {
        console.log('completeTask value', value);
      },
      error: (err: any) => console.log('err', err)
    })
  }

  slideToggleChanged(ev: any, id: number): void {
    const item = this.listItems.find((it) => it.id == id);
    if (item) {
      // item.isCompleted = !item.isCompleted;
      this.completeTask(id);
    }
  }


}
