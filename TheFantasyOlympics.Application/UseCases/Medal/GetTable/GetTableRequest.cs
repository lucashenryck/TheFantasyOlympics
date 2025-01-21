using MediatR;

namespace TheFantasyOlympics.Application.UseCases.Medal.GetTable
{
    public sealed record GetTableRequest : IRequest<GetTableResponse>;
}
