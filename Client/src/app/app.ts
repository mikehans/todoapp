import { Component, signal } from '@angular/core';
import { AppHeader } from "./app-header/app-header";
import { AppFooter } from "./app-footer/app-footer";
import { TodoList } from './todo-list/todo-list';
import { MaterialModule } from './material/material-module';

@Component({
  selector: 'app-root',
  imports: [AppHeader, AppFooter, TodoList, MaterialModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Client');
}
