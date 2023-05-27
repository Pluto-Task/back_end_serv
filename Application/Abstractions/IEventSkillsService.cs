using Domain.Entity;
using Domain.Shared;

namespace Application.Abstractions
{
    public interface IEventSkillsService
    {
        Task<Result> AddSkillsService(EventSkills eventSkills, CancellationToken cancellationToken);
    }
}
