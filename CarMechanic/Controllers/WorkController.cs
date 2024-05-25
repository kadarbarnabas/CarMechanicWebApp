using CarMechanic.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CarMechanic.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkController : ControllerBase
{
    private readonly IWorkService _workService;
    private readonly IWorkEstimationService _workEstimationService;
    public WorkController(IWorkService workService,  IWorkEstimationService workEstimationService)
    {
        _workService = workService;
        _workEstimationService = workEstimationService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWork([FromBody] Work work)
    {
        var existingWork = await _workService.GetWork(work.MunkaId);

        if (existingWork is not null)
        {
            return Conflict();
        }

        await _workService.CreateWork(work);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteWork(Guid id)
    {
        var work = await _workService.GetWork(id);

        if (work is null)
        {
            return NotFound();
        }

        await _workService.DeleteWork(id);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Work>> GetWork(Guid id)
    {
        var work = await _workService.GetWork(id);

        if (work is null)
        {
            return NotFound();
        }

        return Ok(work);
    }

    [HttpGet("GetAllWorks")]
    public async Task<ActionResult<List<Work>>> GetAllWorks()
    {
        return Ok(await _workService.GetAllWorks());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateWork(Guid id, [FromBody] Work newWork)
    {
        if (id != newWork.MunkaId)
        {
            return BadRequest();
        }

        var existingWork = await _workService.GetWork(id);

        if (existingWork is null)
        {
            return NotFound();
        }

        await _workService.UpdateWork(newWork);

        return Ok();
    }

    [HttpGet("EstimateWorkHours")]
    public async Task<IActionResult> EstimateWorkHours([FromQuery] string category, [FromQuery] int carAge, [FromQuery] int severity)
    {
        try
        {
            var estimation = await _workEstimationService.EstimateWorkHoursAsync(category, carAge, severity);
            return Ok(estimation);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}