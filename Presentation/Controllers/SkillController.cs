using Application.Abstractions;
using Application.ResponseApiModel;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;

namespace Presentation.Controllers;

[Route("api/skill/")]
public class SkillController : ApiController
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet("getAll")]
    public IActionResult GetAllSkillsString(CancellationToken cancellationToken)
    {
        var skillsResult = _skillService.GetAllSkillStrings(cancellationToken);

        return skillsResult.IsFailure ? HandleFailure(skillsResult) : Ok(skillsResult.Value);
    }
}