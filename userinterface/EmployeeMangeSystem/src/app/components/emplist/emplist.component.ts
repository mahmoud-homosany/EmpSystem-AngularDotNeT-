import { CommonModule, NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { EmpserviveService } from '../../../service/empservive.service';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-emplist',
  standalone: true,
  imports: [CommonModule, RouterLink, NgFor, FormsModule],
  templateUrl: './emplist.component.html',
  styleUrl: './emplist.component.css'
})
export class EmplistComponent implements OnInit {

  employees: any[] = [];
  searchName: string = '';

  constructor(private serviceEmpService: EmpserviveService) { }

  ngOnInit(): void {
    this.getAllEmployees();
  }

  getAllEmployees(): void {
    this.serviceEmpService.getAllEmployees().subscribe({
      next: (data) => {
        this.employees = data;
      },
      error: (err) => err
    });

  }


  onSearch(): void {
    if (this.searchName.trim() === '') {
      this.getAllEmployees();
    } else {
      this.serviceEmpService.getEmployeeByName(this.searchName).subscribe({
        next: (res) => {
          this.employees = res;
        },
        error: (err) => {
          console.error(err);
          this.employees = [];
        }
      });
    }
  }




  deleteEmployee(id: number): void {
    if (confirm("Are You Sure ?")) {
      this.serviceEmpService.deleteEmployee(id).subscribe({
        next: () => {
          this.getAllEmployees();
        },
        error: (err) => err
      });
    }
  }


















}
