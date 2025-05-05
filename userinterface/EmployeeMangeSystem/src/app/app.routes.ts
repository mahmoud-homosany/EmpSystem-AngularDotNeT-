import { Routes } from '@angular/router';
import { EmplistComponent } from './components/emplist/emplist.component';
import { EmpcreateComponent } from './components/empcreate/empcreate.component';
import { EmpupdateComponent } from './components/empupdate/empupdate.component';

export const routes: Routes = [
  { path: '', redirectTo: 'list', pathMatch: 'full' }, // Redirect from '' to '/list'
  { path: 'list', component: EmplistComponent },
  { path: 'create', component: EmpcreateComponent },
  { path: 'update/:id', component: EmpupdateComponent },
  { path: '**', redirectTo: 'list' } // Redirect for any unknown route update
];
