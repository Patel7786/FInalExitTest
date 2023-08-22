import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclineFormComponent } from './decline-form.component';

describe('DeclineFormComponent', () => {
  let component: DeclineFormComponent;
  let fixture: ComponentFixture<DeclineFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeclineFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeclineFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
