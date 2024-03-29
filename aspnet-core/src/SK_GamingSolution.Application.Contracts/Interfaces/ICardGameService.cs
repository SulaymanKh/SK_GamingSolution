﻿using SK_GamingSolution.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SK_GamingSolution.Interfaces
{
    public interface ICardGameService : IApplicationService
    {
        Task<CardGameItemDto> GetCurrentHighScore();
        Task<CardGameItemDto> AddNewHighScore(string text, int highScore);
        Task DeleteAsync(Guid id);
        Task<string> CalculateScore(List<CardGame> cards);
    }
}
