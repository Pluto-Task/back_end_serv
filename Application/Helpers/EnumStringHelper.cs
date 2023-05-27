using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.Helpers;

public static class EnumStringHelper
{
    public static string GetDisplayName(string name)
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