import { Component } from '@angular/core';
import { CardGameService } from '@proxy/services';
import { CardGameItemDto } from '@proxy/models';

@Component({
  selector: 'app-card-game-page',
  templateUrl: './card-game-page.component.html',
  styleUrl: './card-game-page.component.scss'
})
export class CardGamePageComponent {
  cardList: string = "";
  result: { score: number, errorMessage?: string} = { score: 0 };

  constructor(
    private cardGameService: CardGameService
  ) {}

  calculateScore(){
    let cardGames = this.formatCards();

    this.cardGameService.calculateScoreByCards(cardGames)
    .subscribe((response) => {
      const parsedResponseData = JSON.parse(response);
      this.result.errorMessage = parsedResponseData.IsError ? parsedResponseData.ErrorMessage : '';
      this.result.score = parsedResponseData.IsError ? 0 : parsedResponseData.Score;
    });
  }

  formatCards() {
    let cardsArray: string[] = this.cardList.split(',');
    let cardGames: any[] = [];

    for (let cardString of cardsArray) {
      let value: any = cardString.slice(0, -1);
      let suit: string = cardString.slice(-1);
      let cardGame = { value: value, suit: suit };

      cardGames.push(cardGame);
    }
    return cardGames;
  }

}
