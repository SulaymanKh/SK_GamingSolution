﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace SK_GamingSolution.Entities
{
    public class CardGameItem : BasicAggregateRoot<Guid>
    {
        public string Text { get; set; }
    }
}
