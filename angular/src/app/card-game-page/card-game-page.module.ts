import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { CardGamePageComponent } from './card-game-page.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [CardGamePageComponent],
    imports: [
      SharedModule, 
      FormsModule
    ],
  })
  export class CardGamePageModule {}