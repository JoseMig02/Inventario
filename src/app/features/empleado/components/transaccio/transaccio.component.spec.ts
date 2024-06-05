import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransaccioComponent } from './transaccio.component';

describe('TransaccioComponent', () => {
  let component: TransaccioComponent;
  let fixture: ComponentFixture<TransaccioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TransaccioComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TransaccioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
