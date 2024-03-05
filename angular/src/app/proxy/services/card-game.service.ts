import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CardGame, CardGameItemDto } from '../models/models';

@Injectable({
  providedIn: 'root',
})
export class CardGameService {
  apiName = 'Default';
  

  addNewHighScoreByTextAndHighScore = (text: string, highScore: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, CardGameItemDto>({
      method: 'POST',
      url: '/api/app/card-game/new-high-score',
      params: { text, highScore },
    },
    { apiName: this.apiName,...config });
  

  calculateScoreByCards = (cards: CardGame[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>({
      method: 'POST',
      responseType: 'text',
      url: '/api/app/card-game/calculate-score',
      body: cards,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/card-game/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getCurrentHighScore = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, CardGameItemDto>({
      method: 'GET',
      url: '/api/app/card-game/current-high-score',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
