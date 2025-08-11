import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TodoModel } from '../models/todo-model';
import { schedulePromise } from 'rxjs/internal/scheduled/schedulePromise';

@Injectable({
  providedIn: 'root'
})
export class ApiService implements OnInit {
  private apiUrl = 'http://localhost:5000/todos';

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): Observable<TodoModel[]>{
    return this.http.get<TodoModel[]>(this.apiUrl);
  }

  getById(id:number){
    let item:any;
    this.http.get(`${this.apiUrl}/${id}`);
    return item;
  }

  addTodo(newTodo: TodoModel){
    return this.http.post<TodoModel>(`${this.apiUrl}`, newTodo);
  }

  toggleComplete(id:number){
    return this.http.put<TodoModel>(`${this.apiUrl}/${id}`, null);
  }

}
