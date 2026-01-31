import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassCourses } from './class-courses';

describe('ClassCourses', () => {
  let component: ClassCourses;
  let fixture: ComponentFixture<ClassCourses>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClassCourses]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClassCourses);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
