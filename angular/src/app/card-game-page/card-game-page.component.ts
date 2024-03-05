import { Component, OnInit } from '@angular/core';
import { CardGameService } from '@proxy/services';
import { CardGameItemDto } from '@proxy/models';

@Component({
  selector: 'app-card-game-page',
  templateUrl: './card-game-page.component.html',
  styleUrl: './card-game-page.component.scss'
})
export class CardGamePageComponent implements OnInit{
  cardList: string = "";
  result: { score: number, errorMessage?: string} = { score: 0 };
  currentHighScore = 0;
  highScoreAlert = "New HighScore!";
  showInstructions = false;

  constructor(
    private cardGameService: CardGameService
  ) {}

  ngOnInit(): void {
    this.getCurrentHighScore();
  }

  async calculateScore(){
    let cardGames = this.formatCards();

    await this.cardGameService.calculateScoreByCards(cardGames)
    .subscribe((response) => {
      const parsedResponseData = JSON.parse(response);
      this.result.errorMessage = parsedResponseData.IsError ? parsedResponseData.ErrorMessage : '';
      this.result.score = parsedResponseData.IsError ? 0 : parsedResponseData.Score;

      if (this.result.score > this.currentHighScore)
      {
        this.setNewHighScore();
      }

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

  async getCurrentHighScore(){
    await this.cardGameService.getCurrentHighScore()
    .subscribe((response) => { 
      this.currentHighScore = response.highScore;
    });
  }

  setNewHighScore(){
    this.cardGameService.addNewHighScoreByTextAndHighScore(this.highScoreAlert, this.result.score)
        .subscribe((response) => {
          this.getCurrentHighScore();
        });
  }

  toggleInstructions(){
    if (!this.showInstructions){
      this.showInstructions = true;
    } else {
      this.showInstructions = false;
    }
  }
}
