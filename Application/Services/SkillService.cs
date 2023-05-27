using Application.Abstractions;
using Domain.Enums;
using Domain.Shared;

namespace Application.Services;

public class SkillService : ISkillService
{
    public Result<IEnumerable<string>> GetAllSkillStrings(CancellationToken cancellationToken)
    {
        return Enum.GetNames<SkillName>();
    }
}