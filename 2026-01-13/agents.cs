#!/usr/local/share/dotnet/dotnet run

#:package Azure.AI.Agents.Persistent@1.2.0-beta.8
#:package Azure.Identity@1.18.0-beta.2

using System;
using Azure.AI.Agents.Persistent;
using Azure.Identity;

// Parse command line arguments
if (args.Length == 0)
{
    Console.WriteLine("Usage:");
    Console.WriteLine("  agents list              - List all agents");
    Console.WriteLine("  agents delete [--yes]    - Delete all agents");
    return 1;
}

var command = args[0].ToLower();

switch (command)
{
    case "list":
        await ListAgentsAsync();
        break;
    
    case "delete":
        var skipConfirmation = args.Length > 1 && args[1] == "--yes";
        await DeleteAgentsAsync(skipConfirmation);
        break;
    
    default:
        Console.WriteLine($"Unknown command: {command}");
        Console.WriteLine("Valid commands: list, delete");
        return 1;
}

return 0;

// ---------- helper methods ----------
async Task ListAgentsAsync()
{
    var client = CreateClient();
    
    await foreach (var agent in client.Administration.GetAgentsAsync())
    {
        Console.WriteLine($"{agent.Id}\t{agent.Name}");
    }
}

async Task DeleteAgentsAsync(bool skipConfirmation)
{
    var client = CreateClient();

    // enumerate first (pagination-safe)
    var ids = new List<string>();
    await foreach (var agent in client.Administration.GetAgentsAsync())
        ids.Add(agent.Id);

    if (ids.Count == 0)
    {
        Console.WriteLine("No agents found.");
        return;
    }

    if (!skipConfirmation)
    {
        Console.Write($"Delete {ids.Count} agents? (yes): ");
        if (Console.ReadLine() != "yes")
            return;
    }

    foreach (var id in ids)
    {
        Console.WriteLine($"Deleting {id}");
        await client.Administration.DeleteAgentAsync(id);
    }
}

static PersistentAgentsClient CreateClient()
{
    var endpoint = Environment.GetEnvironmentVariable("AZURE_AI_ENDPOINT")!;
    return new PersistentAgentsClient(endpoint, new DefaultAzureCredential());
}