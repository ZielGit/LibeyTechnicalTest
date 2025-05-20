import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
@Injectable({
	providedIn: "root",
})
export class LibeyUserService {
	constructor(private http: HttpClient) {}
	Find(documentNumber: string): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.get<LibeyUser>(uri);
	}

	all(): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/all`;
		return this.http.get<LibeyUser>(uri);
	}

	save(user: LibeyUser): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.post<LibeyUser>(uri, user);
	}
}