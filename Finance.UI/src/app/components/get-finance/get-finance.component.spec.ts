import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetFinanceComponent } from './get-finance.component';

describe('GetFinanceComponent', () => {
  let component: GetFinanceComponent;
  let fixture: ComponentFixture<GetFinanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GetFinanceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetFinanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
