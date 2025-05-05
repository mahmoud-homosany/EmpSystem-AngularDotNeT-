import { Component } from '@angular/core';
import { EmpserviveService } from '../../../service/empservive.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-empcreate',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './empcreate.component.html',
  styleUrl: './empcreate.component.css'
})
export class EmpcreateComponent {

  employee: any = {
    firstName: '',
    lastName: '',
    email: '',
    position: ''
  };


  constructor(private empService: EmpserviveService, public router: Router) { }

  createEmployee(): void {
    this.empService.createEmployee(this.employee).subscribe({
      next: () => {
        alert('Created Suceess');
        this.router.navigate(['/']);
      },
      error: (err) => err
    });
  }


}
