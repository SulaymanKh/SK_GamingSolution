import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardGamePageComponent } from './card-game-page.component';

describe('CardGamePageComponent', () => {
  let component: CardGamePageComponent;
  let fixture: ComponentFixture<CardGamePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardGamePageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardGamePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
