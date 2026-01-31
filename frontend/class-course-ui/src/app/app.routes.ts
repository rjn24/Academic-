import { Routes } from '@angular/router';
import { ClassCoursesComponent } from './class-courses/class-courses.component';

export const routes: Routes = [
  { path: '', redirectTo: 'class-courses', pathMatch: 'full' },
  { path: 'class-courses', component: ClassCoursesComponent }
];
