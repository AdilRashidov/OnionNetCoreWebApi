import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToDo } from './todo';

@Injectable()
export class DataService {

    private url = "/api/todo";

    constructor(private http: HttpClient) {
    }

    getToDos() {
        return this.http.get(this.url);
    }

    createToDo(todo: ToDo) {
        return this.http.post(this.url, todo);
    }
    updateToDo(todo: ToDo) {

        return this.http.put(this.url + '/' + todo.id, todo);
    }
    deleteToDo(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}