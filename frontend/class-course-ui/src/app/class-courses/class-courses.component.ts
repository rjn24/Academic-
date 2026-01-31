import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AcademicService } from '../academic.service';

@Component({
  selector: 'app-class-courses',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './class-courses.component.html'
})
export class ClassCoursesComponent implements OnInit {

  classes: any[] = [];
  courses: any[] = [];

  // form models
  classModel: any = {};
  courseModel: any = {};

  // editing flags
  editingClass = false;
  editingCourse = false;

  // visibility flags
  showClasses = false;
  showCourses = false;
  showJoined  = false;

  constructor(private api: AcademicService) {}

  ngOnInit() {
    // initial load
    this.loadClasses();
    this.loadCourses();
  }

  /* ===== LOAD ===== */

  loadClasses() {
    this.api.getClasses().subscribe(d => this.classes = d);
  }

  loadCourses() {
    this.api.getCourses().subscribe(d => this.courses = d);
  }

  /* ===== CLASS CRUD ===== */

  saveClass() {
    if (this.editingClass) {
      this.api.updateClass(this.classModel.classID, this.classModel)
        .subscribe(() => { this.resetClass(); this.loadClasses(); });
    } else {
      this.api.addClass(this.classModel)
        .subscribe(() => { this.resetClass(); this.loadClasses(); });
    }
  }

  editClass(c: any) {
    this.classModel = { ...c }; // copy values to form
    this.editingClass = true;
  }

  deleteClass(id: string) {
    this.api.deleteClass(id).subscribe(() => this.loadClasses());
  }

  resetClass() {
    this.classModel = {};
    this.editingClass = false;
  }

  /* ===== COURSE CRUD ===== */

  saveCourse() {
    if (this.editingCourse) {
      this.api.updateCourse(this.courseModel.courseCode, this.courseModel)
        .subscribe(() => { this.resetCourse(); this.loadCourses(); });
    } else {
      this.api.addCourse(this.courseModel)
        .subscribe(() => { this.resetCourse(); this.loadCourses(); });
    }
  }

  editCourse(c: any) {
    this.courseModel = { ...c };
    this.editingCourse = true;
  }

  deleteCourse(code: string) {
    this.api.deleteCourse(code).subscribe(() => this.loadCourses());
  }

  resetCourse() {
    this.courseModel = {};
    this.editingCourse = false;
  }

  /* ===== TOGGLES ===== */

  toggleClasses() { this.showClasses = !this.showClasses; }
  toggleCourses() { this.showCourses = !this.showCourses; }
  toggleJoined()  { this.showJoined  = !this.showJoined; }
}
