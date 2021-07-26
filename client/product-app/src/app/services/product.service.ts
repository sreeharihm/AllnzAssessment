import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }
  
  public getProduct(){
    return this.http.get(environment.baseUrl + environment.product);
  }
  public getProductById(id: string){
    const params = new HttpParams().set('id', id);
    return this.http.get(environment.baseUrl +environment.productDetails, { params: params });
  }
}
