import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AHeaderComponent } from './aheader.component';

describe('AHeaderComponent', () => {
  let component: AHeaderComponent;
  let fixture: ComponentFixture<AHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AHeaderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
