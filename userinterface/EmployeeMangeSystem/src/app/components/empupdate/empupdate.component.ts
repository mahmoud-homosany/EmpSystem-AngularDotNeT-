import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { EmpserviveService } from '../../../service/empservive.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-empupdate',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './empupdate.component.html',
  styleUrl: './empupdate.component.css'
})
export class EmpupdateComponent implements OnInit {

  id!: number;
  employee: any = null;

  constructor(
    private route: ActivatedRoute,
    private empService: EmpserviveService,
    private router: Router
  ) { }



  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));


    this.empService.getEmployeeById(this.id).subscribe(
      (data) => {

        this.employee = data.entity;

        console.log(data);

      },
      (error) => {
        console.error('Error fetching employee data:', error);
      }
    );

  }

  updateEmployee() {
    this.empService.updateEmployee(this.employee).subscribe(() => {
      alert('Employee updated successfully!');
      this.router.navigate(['/']);
    });
  }



}
