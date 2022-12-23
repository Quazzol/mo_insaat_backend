using Backend.Authorization;
using Backend.Datas.Enums;
using Backend.DTOs.Request;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController : ControllerBase
{
    private readonly IContentService _service;

    public ContentController(IContentService service)
    {
        _service = service;
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _service.Get(id));
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll(Guid? contentTypeId)
    {
        return Ok(await _service.GetAll(contentTypeId));
    }

    [HttpGet("get-all-by-type")]
    public async Task<IActionResult> GetAllByType(string languageCode, ContentType type)
    {
        return Ok(await _service.GetAll(languageCode, type));
    }

    [HttpGet("get-all-title")]
    public async Task<IActionResult> GetAllTitle(string languageCode)
    {
        return Ok(await _service.GetAllTitle(languageCode));
    }

    [Authorize(Policy = Policies.AtLeastModerators)]
    [HttpPost("insert")]
    public async Task<IActionResult> Insert(ContentInsertDTO content)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        return Ok(await _service.Insert(content));
    }

    [Authorize(Policy = Policies.AtLeastModerators)]
    [HttpPost("update")]
    public async Task<IActionResult> Update(ContentUpdateDTO content)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        return Ok(await _service.Update(content));
    }

    [Authorize(Policy = Policies.OnlyAdmins)]
    [HttpGet("delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);
        return Ok();
    }
}