using Application.Abstractions;
using Domain.Entity;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Services
{
    public class EventSkillService : IEventSkillsService
    {
        private readonly IGenericRepository<EventSkills> _eventSkillsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EventSkillService(IGenericRepository<EventSkills> eventSkillsRepository, IUnitOfWork unitOfWork)
        {
            _eventSkillsRepository = eventSkillsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddSkillsService(EventSkills eventSkills, CancellationToken cancellationToken)
        {
            await _eventSkillsRepository.CreateAsync(eventSkills,cancellationToken);

            return Result.Success();
        }
    }
}
