import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AcademicService {

  // base API path of your controller
  private baseUrl = 'https://localhost:7004/api/Academic';

  constructor(private http: HttpClient) {}

  /* ---------- CLASSES ---------- */

  // GET all classes
  getClasses() {
    return this.http.get<any[]>(`${this.baseUrl}/classes`);
  }

  // POST create class
  addClass(data: any) {
    return this.http.post(`${this.baseUrl}/classes`, data);
  }

  // PUT update class
  updateClass(id: string, data: any) {
    return this.http.put(`${this.baseUrl}/classes/${id}`, data);
  }

  // DELETE class
  deleteClass(id: string) {
    return this.http.delete(`${this.baseUrl}/classes/${id}`);
  }

  /* ---------- COURSES ---------- */

  getCourses() {
    return this.http.get<any[]>(`${this.baseUrl}/courses`);
  }

  addCourse(data: any) {
    return this.http.post(`${this.baseUrl}/courses`, data);
  }

  updateCourse(code: string, data: any) {
    return this.http.put(`${this.baseUrl}/courses/${code}`, data);
  }

  deleteCourse(code: string) {
    return this.http.delete(`${this.baseUrl}/courses/${code}`);
  }
}
