import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { Ubigeo } from "src/app/entities/ubigeo";
@Injectable({
	providedIn: "root",
})
export class UbigeoService {
	constructor(private http: HttpClient) {}
	getDepartment(): Observable<Ubigeo> {
		const uri = `${environment.pathLibeyTechnicalTest}Ubigeo`;
		return this.http.get<Ubigeo>(uri);
	}
	getProvince(provinceCode: string): Observable<Ubigeo> {
		const uri = `${environment.pathLibeyTechnicalTest}Ubigeo/province/${provinceCode}`;
		return this.http.get<Ubigeo>(uri);
	}
	getRegion(regionCode: string): Observable<Ubigeo> {
		const uri = `${environment.pathLibeyTechnicalTest}Ubigeo/region/${regionCode}`;
		return this.http.get<Ubigeo>(uri);
	}
}