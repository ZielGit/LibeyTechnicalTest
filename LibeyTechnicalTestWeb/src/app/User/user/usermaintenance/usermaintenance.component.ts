import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { DocumentTypeService } from 'src/app/core/service/documenttype/documenttype.service';
import { DocumentType } from 'src/app/entities/documenttype';
import { UbigeoService } from 'src/app/core/service/ubigeo/ubigeo.service';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {
  documentTypes: DocumentType[] = [];
  selectedDocumentType: any;
  departments: Ubigeo[] = [];
  provinces: Ubigeo[] = [];
  regions: Ubigeo[] = [];
  selectedDepartment: any;
  selectedProvince: any;
  selectedRegion: any;
  documentNumber: string = '';
  name: string = '';
  fathersLastName: string = '';
  mothersLastName: string = '';
  address: string = '';
  phone: string = '';
  email: string = '';
  password: string = '';

  constructor(
    private documentTypeService: DocumentTypeService,
    private ubigeoService: UbigeoService,
    private libeyUserService: LibeyUserService
  ) { }

  ngOnInit(): void {
    this.documentTypeService.all().subscribe((data: any) => {
      this.documentTypes = Array.isArray(data) ? data : [data];
    });
    this.ubigeoService.getDepartment().subscribe((data: any) => {
      this.departments = Array.isArray(data) ? data : [data];
    });
  }

  onDepartmentChange() {
    this.selectedProvince = null;
    this.selectedRegion = null;
    this.provinces = [];
    this.regions = [];
    if (this.selectedDepartment) {
      this.ubigeoService.getProvince(this.selectedDepartment).subscribe((data: any) => {
        this.provinces = Array.isArray(data) ? data : [data];
      });
    }
  }

  onProvinceChange() {
    this.selectedRegion = null;
    this.regions = [];
    if (this.selectedProvince) {
      this.ubigeoService.getRegion(this.selectedProvince).subscribe((data: any) => {
        this.regions = Array.isArray(data) ? data : [data];
      });
    }
  }

  Submit() {
    const user: LibeyUser = {
      documentTypeId: this.selectedDocumentType,
      documentNumber: this.documentNumber,
      name: this.name,
      fathersLastName: this.fathersLastName,
      mothersLastName: this.mothersLastName,
      address: this.address,
      ubigeoCode: this.selectedDepartment,
      provinceCode: this.selectedProvince,
      regionCode: this.selectedRegion,
      phone: this.phone,
      email: this.email,
      password: this.password,
      active: true
    };
    this.libeyUserService.save(user).subscribe({
      next: () => swal.fire("Éxito", "Usuario guardado correctamente", "success"),
      error: () => swal.fire("Error", "No se pudo guardar el usuario", "error")
    });
  }
}