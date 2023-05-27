using Application.ResponseApiModel;
using Domain.Shared;

namespace Application.Abstractions;

public interface ISkillService
{
    Result<IEnumerable<SkillResponseApiModel>> GetAllSkillStrings(CancellationToken cancellationToken);
}