﻿using TheFantasyOlympics.Domain.Entities.Base;
using TheFantasyOlympics.Domain.Enumerations;

namespace TheFantasyOlympics.Domain.Entities
{
    public sealed class Modality : Entity
    {
        public Enumerations.Type Type { get; private set; }
        public Genre Genre { get; private set; }
        public int AllowedPlayersCount { get; private set; }
        public int SportId { get; private set; }
        public Sport? Sport { get; private set; } 
    }
}
