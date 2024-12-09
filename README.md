# Conductor C# Basic Worker Example

This project demonstrates a basic worker implementation using the Orkes Conductor C# SDK. It shows how to create a simple task worker that can process tasks from a Conductor workflow.

## Prerequisites

- .NET 9.0 or later
- An Orkes Conductor account
- Access key and secret from Orkes Conductor

## Installation

1. Clone this repository:
   ```bash
   git clone <repository-url>
   cd csharp-basic-worker
   ```

2. Install dependencies:
   ```bash
   dotnet restore
   ```

## Configuration

1. Update the `Program.cs` file with your Conductor server details:
   ```csharp
   var configuration = new Configuration()
   {
       BasePath = "YOUR_CONDUCTOR_SERVER_URL/api",
       AuthenticationSettings = new OrkesAuthenticationSettings(
           "YOUR_KEY", 
           "YOUR_SECRET"
       )
   };
   ```

   Replace:
   - `YOUR_CONDUCTOR_SERVER_URL` with your Conductor server URL
   - `YOUR_KEY` with your Orkes Conductor key
   - `YOUR_SECRET` with your Orkes Conductor secret

## Running the Worker

1. Build the project:
   ```bash
   dotnet build
   ```

2. Run the worker:
   ```bash
   dotnet run
   ```

The worker will start polling for tasks of type "test-java-sdk". You should see output similar to:
```
Starting worker host...
Worker initialized with task type: test-java-sdk
Application started. Press Ctrl+C to shut down.
```

## Worker Implementation

The example includes a simple worker that:
- Polls for tasks of type "test-java-sdk"
- Processes input data
- Returns a "Hello world" message combined with input parameters
- Marks tasks as completed

## Workflow Definition

To use this worker, create a workflow in Conductor with a task that has:
- Task type: "test-java-sdk"
- Input parameters as needed

Example workflow definition:
```json
{
  "name": "test_workflow",
  "version": 1,
  "tasks": [
    {
      "name": "test_task",
      "taskReferenceName": "test_task_ref",
      "type": "test-java-sdk",
      "inputParameters": {
        "key": "value"
      }
    }
  ]
}
```

## Troubleshooting

If the worker isn't processing tasks:
1. Verify your Conductor server URL and credentials
2. Check that the task type matches exactly in both worker and workflow
3. Ensure the workflow is properly registered in Conductor
4. Check the Conductor UI for task status and any error messages

## Dependencies

- conductor-csharp (v3.14.0)
- .NET 9.0

## Additional Resources

- [Orkes Conductor Documentation](https://orkes.io/content)
- [C# SDK Documentation](https://github.com/conductor-sdk/conductor-csharp)
- [Conductor Worker Documentation](https://orkes.io/content/docs/reference-docs/workers)

