﻿using TheFantasyOlympics.Application.Dtos;

namespace TheFantasyOlympics.Application.UseCases.Medal.ListBySport
{
    public sealed record ListMedalsBySportResponse(
        int Id,
        string Position,
        string Country,
        SportDto Sport,
        ModalityDto Modality
    );
}
