import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoriesFinancesComponent } from './stories-finances.component';

describe('StoriesFinancesComponent', () => {
  let component: StoriesFinancesComponent;
  let fixture: ComponentFixture<StoriesFinancesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StoriesFinancesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StoriesFinancesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
