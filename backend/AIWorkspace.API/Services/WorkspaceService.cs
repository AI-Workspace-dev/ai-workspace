namespace AIWorkspace.API.Services;

public class WorkspaceService : IWorkspaceService
{
    public string GetStatus()
    {
        return "Workspace service is healthy";
    }
}