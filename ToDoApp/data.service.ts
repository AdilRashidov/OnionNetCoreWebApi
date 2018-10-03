import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from './product';

@Injectable()
export class DataService {

    private url = "/api/todo";

    constructor(private http: HttpClient) {
    }

    getToDos() {
        return this.http.get(this.url);
    }

    createToDo(product: Product) {
        return this.http.post(this.url, product);
    }
    updateToDo(product: Product) {

        return this.http.put(this.url + '/' + product.id, product);
    }
    deleteToDo(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}