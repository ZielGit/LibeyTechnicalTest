import { Component, OnInit } from "@angular/core";
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";
import { LibeyUser } from "src/app/entities/libeyuser";

@Component({
	selector: "app-usercards",
	templateUrl: "./usercards.component.html",
	styleUrls: ["./usercards.component.css"],
})
export class UsercardsComponent implements OnInit {
	users: LibeyUser[] = [];

	constructor(private libeyUserService: LibeyUserService) {}
	ngOnInit(): void {
		this.libeyUserService.all().subscribe((data: any) => {
			this.users = Array.isArray(data) ? data : [data];
		});
	}
}