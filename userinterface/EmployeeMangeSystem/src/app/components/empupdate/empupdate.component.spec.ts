import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpupdateComponent } from './empupdate.component';

describe('EmpupdateComponent', () => {
  let component: EmpupdateComponent;
  let fixture: ComponentFixture<EmpupdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmpupdateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmpupdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
