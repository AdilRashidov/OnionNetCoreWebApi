import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { ToDo } from './ToDo';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    todo: ToDo = new ToDo();   // изменяемый товар
    todos: ToDo[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadToDos();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadToDos() {
        this.dataService.getToDos()
            .subscribe((data: ToDo[]) => this.todos = data);
    }
    // сохранение данных
    save() {
        if (this.todo.id == null) {
            this.dataService.createToDo(this.todo)
                .subscribe((data: ToDo) => this.todos.push(data));
        } else {
            this.dataService.updateToDo(this.todo)
                .subscribe(data => this.loadToDos());
        }
        this.cancel();
    }
    editProduct(p: ToDo) {
        this.todo = p;
    }
    cancel() {
        this.todo = new ToDo();
        this.tableMode = true;
    }
    delete(p: ToDo) {
        this.dataService.deleteToDo(p.id)
            .subscribe(data => this.loadToDos());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}