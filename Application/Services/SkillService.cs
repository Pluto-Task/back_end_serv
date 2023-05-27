using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Application.Abstractions;
using Application.Helpers;
using Application.ResponseApiModel;
using Domain.Enums;
using Domain.Shared;

namespace Application.Services;

public class SkillService : ISkillService
{
    public Result<IEnumerable<SkillResponseApiModel>> GetAllSkillStrings(CancellationToken cancellationToken)
    {
        var enumType = typeof(SkillName);
        var enumValues = Enum.GetValues(enumType);

        var skillList = new List<SkillResponseApiModel>();

        foreach (var value in enumValues)
        {
            var fieldName = EnumStringHelper.GetDisplayName(Enum.GetName(enumType, value)!);
            var fieldValue = (int)value;
            skillList.Add(new SkillResponseApiModel(fieldValue, fieldName));
        }

        return skillList;
    }
}