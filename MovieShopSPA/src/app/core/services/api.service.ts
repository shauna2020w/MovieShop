import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable} from 'rxjs';   //range filter map
import { map } from 'rxjs/operators';  //map used as select


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(protected http:HttpClient) { }

  getAll(path: string) : Observable<any[]> {  //method():return type <any[]> means any of array

    //https://localhost:44367/api/Genre
    return this.http.get(`${environment.apiUrl}${path}`).pipe(
      map(resp=>resp as any[]) 
    )

  }

  getById(path:string , id?:number):Observable<any>{  //method():return type; <any> means any of obj
    return this.http.get(`${environment.apiUrl}${path}`).pipe(
      map(resp=>resp as any)
    )
  }

  create(path: string, resource: any, options?: any): Observable<any> {

    return this.http.post(`${environment.apiUrl}${path}`, resource).pipe(
      map(response => response)
    )
  }
}
