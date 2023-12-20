import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteFinanceComponent } from './delete-finance.component';

describe('DeleteFinanceComponent', () => {
  let component: DeleteFinanceComponent;
  let fixture: ComponentFixture<DeleteFinanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeleteFinanceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DeleteFinanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
