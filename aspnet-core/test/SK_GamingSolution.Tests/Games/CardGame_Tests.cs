using SK_GamingSolution.Interfaces;
using SK_GamingSolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SK_GamingSolution.Models;
using SK_GamingSolution.Services;
using SK_GamingSolution.Entities;
using Volo.Abp.Domain.Repositories;
using System.Text.Json;
using Moq;
using Volo.Abp.Application.Services;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;

namespace SK_GamingSolution.Tests.Games
{
    [TestClass()]
    public class CardGame_Tests
    {
        [TestMethod()]
        public void CalculateScore_ReturnsJsonString()
        {
            // Arrange
            var cardGameService = new CardGameAppService(null);
            var cards = new List<CardGame> { };

            // Act
            var fullResultMessage = cardGameService.CalculateScore(cards);
            bool isValidJson = false;

            try
            {
                var result = JsonSerializer.Deserialize<ResponseWrapper<string>>(fullResultMessage.Result);
                isValidJson = true;
            }
            catch (Exception ex)
            {
                isValidJson = false; 
            }

            // Assert
            Assert.IsTrue(isValidJson);
        }

        [TestMethod()]
        public void CalculateScore_ReturnsErrorMessage()
        {
            // Arrange
            var cardGameService = new CardGameAppService(null);
            var cards = new List<CardGame> { };

            // Act
            var fullResultMessage = cardGameService.CalculateScore(cards);
            var result = JsonSerializer.Deserialize<ResponseWrapper<string>>(fullResultMessage.Result);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ErrorMessage, "Card list cannot be empty.");
        }

        [TestMethod]
        public async Task PassInThreeJokers_ReturnsErrorMessage()
        {
            // Arrange 
            var cardGameItemRepository = new Mock<IRepository<CardGameItem, Guid>>();
            var cardGameService = new CardGameAppService(cardGameItemRepository.Object);
            string? message = null;

            var cardItems = new List<CardGame>
            {
                new CardGame { Value = 'J', Suit = 'K' },
                new CardGame { Value = 'J', Suit = 'K' },
                new CardGame { Value = 'J', Suit = 'K' }
            };

            // Act
            try
            {
                var results = cardGameService.CountJokers(cardItems);
            }
            catch (Exception ex) 
            { 
                message = ex.Message;
            }

            // Assert
            Assert.IsNotNull(message);
            Assert.AreEqual(message, "A hand cannot contain more than two Jokers.");
        }

        [TestMethod]
        public async Task PassDupes_ReturnsErrorMessage()
        {
            // Arrange 
            var cardGameItemRepository = new Mock<IRepository<CardGameItem, Guid>>();
            var cardGameService = new CardGameAppService(cardGameItemRepository.Object);
            string? message = null;

            var cardItems = new List<CardGame>
            {
                new CardGame { Value = '2', Suit = 'A' },
                new CardGame { Value = '2', Suit = 'A' }
            };

            // Act
            try
            {
               cardGameService.ValidateCardList(cardItems);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Assert
            Assert.IsNotNull(message);
            Assert.AreEqual(message, "Cards cannot be duplicated.");
        }

        [TestMethod]
        public async Task GetCardValue_ReturnsCorrectValue()
        {
            // Arrange 
            var cardGameItemRepository = new Mock<IRepository<CardGameItem, Guid>>();
            var cardGameService = new CardGameAppService(cardGameItemRepository.Object);

            // Act
            Assert.AreEqual(10, cardGameService.GetCardValue("T"));
            Assert.AreEqual(11, cardGameService.GetCardValue("J"));
            Assert.AreEqual(12, cardGameService.GetCardValue("Q"));
            Assert.AreEqual(13, cardGameService.GetCardValue("K"));
            Assert.AreEqual(14, cardGameService.GetCardValue("A"));
        }
    }
}
