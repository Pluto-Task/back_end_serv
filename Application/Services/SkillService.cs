using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Application.Abstractions;
using Domain.Enums;
using Domain.Shared;

namespace Application.Services;

public class SkillService : ISkillService
{
    public Result<IEnumerable<string>> GetAllSkillStrings(CancellationToken cancellationToken)
    {
        return Enum.GetNames<SkillName>().Select(GetDisplayName).ToList();
    }

    private static string GetDisplayName(string name)
    {
        var type = typeof(SkillName);

        var fieldInfo = type.GetField(name);

        if (fieldInfo != null)
        {
            if (Attribute.GetCustomAttribute(fieldInfo, typeof(DisplayAttribute)) is DisplayAttribute
                {
                    Name: not null
                } attribute)
            {
                return attribute.Name;
            }
        }

        return name;
    }
}