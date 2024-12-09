using Conductor.Api;
using Conductor.Client.Extensions;
using Conductor.Definition;
using Conductor.Client.Worker;
using Conductor.Client;
using Conductor.Client.Models;
using Conductor.Client.Interfaces;
using Task = Conductor.Client.Models.Task;
using System.Text.Json;
using Conductor.Executor;
using Conductor.Client.Authentication;
using Conductor.Definition.TaskType;
using System;
using System.Threading;
using System.Threading.Tasks;
var configuration = new Configuration()
{
    BasePath = "CONDUCTOR_SERVER_URL/api",
    AuthenticationSettings = new OrkesAuthenticationSettings("YOUR_KEY", "YOUR_SECRET")
};
var host = WorkflowTaskHost.CreateWorkerHost(configuration, Microsoft.Extensions.Logging.LogLevel.Information, new SimpleWorker());
await host.StartAsync();
Thread.Sleep(TimeSpan.FromSeconds(100));
public class SimpleWorker : IWorkflowTask
{
    public string TaskType
    {
        get;
    }
    public WorkflowTaskExecutorConfiguration WorkerSettings
    {
        get;
    }
    public SimpleWorker(string taskType = "simple")
    {
        TaskType = taskType;
        WorkerSettings = new WorkflowTaskExecutorConfiguration();
    }
    public async System.Threading.Tasks.Task<TaskResult> Execute(Task task, CancellationToken token =
        default)
    {
        return await System.Threading.Tasks.Task.Run(() =>
        {
            var result = task.Completed();
            string outputString = "Hello world";
            result.OutputData = new Dictionary<string, object>
            {
                {
                    "result",
                    outputString += " " + string.Join(" ", [task.InputData["key"]])
                }
            };
            return result;
        });
    }
    public TaskResult Execute(Task task)
    {
        throw new NotImplementedException();
    }
}