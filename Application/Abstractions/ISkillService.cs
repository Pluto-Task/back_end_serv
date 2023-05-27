using Domain.Shared;

namespace Application.Abstractions;

public interface ISkillService
{
    Result<IEnumerable<string>> GetAllSkillStrings(CancellationToken cancellationToken);
}