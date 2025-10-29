using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour

{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("talk to npc");
            if (collision.GetComponent<NPCDialog>() != null)
            {
                collision.GetComponent<NPCDialog>().Talk();
            }
        }
        else if (collision.gameObject.CompareTag("Clue"))
        {
            Debug.Log("interact with clue");
            if (collision != null)
            {
                if (collision.GetComponent<ClueDialog>() != null)
                {
                    collision.GetComponent<ClueDialog>().Interact();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("dont talk with npc");
            if (collision.GetComponent<NPCDialog>() != null)
            {
                collision.GetComponent<NPCDialog>().EndDialog();
            }
        }
        else if (collision.gameObject.CompareTag("Clue"))
        {
            Debug.Log("interact with clue");
            if (collision != null)
            {
                if (collision.GetComponent<ClueDialog>() != null)
                {
                    collision.GetComponent<ClueDialog>().EndClue();
                }
            }
        }
    }
}
