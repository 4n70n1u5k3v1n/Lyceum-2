using System.Collections.Generic;
using UnityEngine;

public static class DialogRepository
{
    private static Dictionary<string, string> dialogLines = new Dictionary<string, string>()
    {
        { "Grandma_Dialog1", "Hello dear, have you eaten yet?" },
        //{ "Grandma_Dialog2", "Take care of yourself, okay?" },
        //{ "Shopkeeper_Dialog1", "Welcome! What do you want to buy?" },
        //{ "Shopkeeper_Dialog2", "Come again soon!" }
        { "Item", "What is this thing?" },
    };

    // Returns a dialog line based on NPC name and dialog name
    public static string GetDialog(string NPCName, string dialogName)
    {
        string key = "";
        if (dialogName.Equals(""))
        {
            key = NPCName;
        }
        else
        {
            key = NPCName + "_" + dialogName;
        }


        if (dialogLines.TryGetValue(key, out string line))
        {
            return line;
        }
        else
        {
            Debug.LogWarning("Dialog not found for key: " + key);
            return "";
        }
    }
}
