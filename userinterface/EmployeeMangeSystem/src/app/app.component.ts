import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmplistComponent } from './components/emplist/emplist.component';
import { EmpcreateComponent } from "./components/empcreate/empcreate.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'EmployeeMangeSystem';
}
