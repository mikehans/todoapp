import { Component, EventEmitter, Output, signal, WritableSignal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material-module';

@Component({
  selector: 'app-add-todo',
  imports: [ReactiveFormsModule, MaterialModule],
  templateUrl: './add-todo.html',
  styleUrl: './add-todo.scss'
})
export class AddTodo {
  @Output() todoAdded = new EventEmitter<any>();

  newTodoForm = new FormGroup({
    title: new FormControl(''),
    description: new FormControl(''),
  });

  handleSubmit() {
    console.log(this.newTodoForm.value)

    this.todoAdded.emit(this.newTodoForm.value);
    this.newTodoForm.reset();
  }
}
