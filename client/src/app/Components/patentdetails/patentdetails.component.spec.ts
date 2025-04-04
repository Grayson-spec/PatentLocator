import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatentdetailsComponent } from './patentdetails.component';

describe('PatentdetailsComponent', () => {
  let component: PatentdetailsComponent;
  let fixture: ComponentFixture<PatentdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PatentdetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatentdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
