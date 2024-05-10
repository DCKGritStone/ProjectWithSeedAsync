using AutoMapper;
using MediatR;
using ProjectWithSeedAsync.Application.Dto;
using ProjectWithSeedAsync.Domain;
using ProjectWithSeedAsync.Domain.Entity;

namespace ProjectWithSeedAsync.Application.Command._State.CreateState
{
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, StateDto>
    {
        private readonly IRepository Repository;
        private readonly IMapper mapper;

        public CreateStateCommandHandler(IRepository stateRepository, IMapper mapper)
        {
            this.Repository = stateRepository;
            this.mapper = mapper;
        }
        public async Task<StateDto> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var createState = new State
            {
                Name = request.Name,
                Code = request.Code,
                CountryId = request.CountryId
            };

            var result = await Repository.CreateStateAsync(createState);

            return mapper.Map<StateDto>(result);
        }
    }
}
