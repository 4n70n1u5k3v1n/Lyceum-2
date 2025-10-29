using System.Collections.Generic;
using System.Numerics;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static Cinemachine.CinemachineOrbitalTransposer;

public static class DialogRepository
{
    private static Dictionary<string, Dictionary<string, string>> dialogLines = new Dictionary<string, Dictionary<string, string>>()
    {
        { "Mrs. Bourbon", new Dictionary<string, string>()
            {
                { "Mrs. Bourbon", "Ah, young detective! I'm currently baking cookies, please do have them once they're ready." },
                { "Eris", "Thank you Mrs. Bourbon, I'll gladly eat it. On the topic of food, did you just refill Lila's bowl recently?" },
                { "Mrs. Bourbon1", "I think I did yesterday, I was hoping maybe if she's just hiding inside the house, she wouldn't go hungry..." },
                { "Eris1", "Thank you for the confirmation Mrs. Bourbon, I was also wondering if it's possible to investigate the master bedroom since Lila would sleep there." },
                { "Mrs. Bourbon2", "Of course! It seems like I forgot to unlock it for you kids... Come, I'll open it for you." },
            }
        },
        { "Item", new Dictionary<string, string>()
            {
                { "Eris", "A trail of spith leading to the kitchen." },
            }
        },
        //{ "Grandma_Dialog2", "Take care of yourself, okay?" },
        //{ "Shopkeeper_Dialog1", "Welcome! What do you want to buy?" },
        //{ "Shopkeeper_Dialog2", "Come again soon!" }
    };

    // Returns a dialog line based on NPC name and dialog name
    public static Dictionary<string, string> GetDialog(string NPCName)
    {
        string key = NPCName;

        if (dialogLines.TryGetValue(key, out Dictionary<string, string> lines))
        {
            return lines;
        }
        else
        {
            Debug.LogWarning("Dialog not found for key: " + key);
            return null;
        }
    }
}
