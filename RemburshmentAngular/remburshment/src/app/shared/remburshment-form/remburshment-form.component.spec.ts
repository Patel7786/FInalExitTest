import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemburshmentFormComponent } from './remburshment-form.component';

describe('RemburshmentFormComponent', () => {
  let component: RemburshmentFormComponent;
  let fixture: ComponentFixture<RemburshmentFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RemburshmentFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RemburshmentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
