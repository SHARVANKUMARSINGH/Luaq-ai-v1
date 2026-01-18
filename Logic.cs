// FILE: Logic.cs
// PURPOSE: Natural Language Processing (NLP) & Context Management
using System;
using System.Collections.Generic;
using System.Linq;

public class CoreLogic {
    
    // The "Context Window" (Short-term memory)
    private List<string> conversationHistory = new List<string>();
    
    // Safety Filters
    private string[] forbiddenWords = { "hack", "exploit", "virus" };

    public string ProcessInput(string userInput) {
        // 1. Safety Check
        foreach(var word in forbiddenWords) {
            if(userInput.Contains(word)) return "Error: Safety Protocol Violation.";
        }

        // 2. Tokenization (Breaking sentences into chunks)
        string[] tokens = userInput.Split(' ');
        
        // 3. Update Memory
        conversationHistory.Add($"User: {userInput}");

        // 4. Determine Intent (Rule-based routing)
        if(userInput.Contains("code") || userInput.Contains("html")) {
            return "Intent: CODING_ASSISTANT";
        } else if (userInput.Contains("hi") || userInput.Contains("hello")) {
            return "Intent: GREETING";
        }

        return "Intent: GENERAL_QUERY";
    }

    public string FormatOutput(string rawResponse) {
        return $"[AI]: {rawResponse} \n(Processed via C# Logic)";
    }
}

