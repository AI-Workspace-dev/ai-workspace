using AIWorkspace.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIWorkspace.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkspaceController : ControllerBase
{
    private readonly IWorkspaceService _workspaceService;

    public WorkspaceController(IWorkspaceService workspaceService)
    {
        _workspaceService = workspaceService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "AI Workspace API is running",
            service = _workspaceService.GetStatus()
        });
    }
}