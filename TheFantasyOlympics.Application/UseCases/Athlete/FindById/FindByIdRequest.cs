using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Athlete.FindById
{
    public sealed record FindByIdRequest(int Id) : IRequest<FindByIdResponse>;
}
