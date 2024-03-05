using SK_GamingSolution.Entities;
using SK_GamingSolution.Interfaces;
using SK_GamingSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SK_GamingSolution.Services
{
    public class CardGameAppService : ApplicationService, ICardGameService
    {
        private readonly IRepository<CardGameItem, Guid> _cardGameItemRepository;

        public CardGameAppService(IRepository<CardGameItem, Guid> cardGameItemRepository)
        {
            _cardGameItemRepository = cardGameItemRepository;
        }

        public async Task<CardGameItemDto> GetCurrentHighScore()
        {
            var allItems = await _cardGameItemRepository.GetListAsync();


            var highestScoreItem = allItems.OrderByDescending(score => score.HighScore).FirstOrDefault();

            return new CardGameItemDto
            {
                Id = highestScoreItem.Id,
                Text = highestScoreItem.Text,
                HighScore = highestScoreItem.HighScore,
            };
        }

        public async Task<CardGameItemDto> AddNewHighScore(string text, int highScore)
        {
            var items = await _cardGameItemRepository.InsertAsync(
                new CardGameItem { Text = text, HighScore = highScore }
            );

            return new CardGameItemDto
            {
                Id = items.Id,
                Text = items.Text, 
                HighScore = highScore
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _cardGameItemRepository.DeleteAsync(id);
        }

        public async Task<string> CalculateScore(List<CardGame> cards)
        {
            try
            {
                ValidateCardList(cards);

                int jokerCount = CountJokers(cards);
                int totalScore = CalculateTotalScore(cards, jokerCount);

                var successfulResponse = new ResponseWrapper<string>
                {
                    Score = JsonSerializer.Serialize(totalScore),
                    IsError = false
                };

                return JsonSerializer.Serialize(successfulResponse);
            }
            catch (Exception ex)
            {
                var unsuccessfulResponse = new ResponseWrapper<string>
                {
                    Score = null,
                    IsError = true,
                    ErrorMessage = ex.Message
                };

                return JsonSerializer.Serialize(unsuccessfulResponse);
            }
    
        }

        public void ValidateCardList(List<CardGame> cards)
        {
            if (cards == null || cards.Count == 0)
            {
                throw new ArgumentException("Card list cannot be empty.");
            }

            var cardsList = new List<string>();

            foreach (var card in cards)
            {
                var cardKey = $"{card.Value}{card.Suit}";

                if (cardsList.Contains(cardKey) && (cardKey != "JK"))
                {
                    throw new ArgumentException("Cards cannot be duplicated.");
                }

                cardsList.Add(cardKey);
            }
        }

        public int CountJokers(List<CardGame> cards)
        {
            int jokerCount = 0;

            foreach (var card in cards)
            {
                if (card.Value == 'J' && card.Suit == 'K')
                {
                    jokerCount++;

                    if (jokerCount > 2)
                    {
                        throw new ArgumentException("A hand cannot contain more than two Jokers.");
                    }
                }
            }

            return jokerCount;
        }

        public int CalculateTotalScore(List<CardGame> cards, int jokerCount)
        {
            int totalScore = 0;

            foreach (var card in cards)
            {
                if (card.Value != 'J' || card.Suit != 'K')
                {
                    int cardValue = GetCardValue(card.Value.ToString());
                    int suitMultiplier = GetSuitMultiplier(card.Suit.ToString());

                    totalScore += cardValue * suitMultiplier;
                }
            }

            return ApplyJokerMultiplier(totalScore, jokerCount);
        }

        public int GetCardValue(string value)
        {
            switch (value)
            {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    return int.Parse(value.ToString());
                case "T":
                    return 10;
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    throw new ArgumentException("Card not recogonised.");
            }
        }

        public int GetSuitMultiplier(string suit)
        {
            switch (suit)
            {
                case "C":
                    return 1;
                case "D":
                    return 2;
                case "H":
                    return 3;
                case "S":
                    return 4;
                default:
                    throw new ArgumentException("Card not recogonised.");
            }
        }

        public int ApplyJokerMultiplier(int totalScore, int jokerCount)
        {
            for (int i = 0; i < jokerCount; i++)
            {
                totalScore *= 2;
            }

            return totalScore;
        }
    }
}
