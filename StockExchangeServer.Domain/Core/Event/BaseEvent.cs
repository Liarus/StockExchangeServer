﻿using StockExchangeServer.Domain.SharedKernel.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchangeServer.Domain.Definitions.Event
{
    public abstract class BaseEvent : IEvent
    {
        protected BaseEvent(Guid identity)
        {
            this.Identity = identity;
            this.TimeStamp = DateTime.Now;
        }

        public readonly Guid Identity;

        public readonly DateTimeOffset TimeStamp;
    }
}
