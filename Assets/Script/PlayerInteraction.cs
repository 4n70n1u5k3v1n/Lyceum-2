using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Collider2D collidedObject;
    [SerializeField] private GameObject talkButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") || collision.gameObject.CompareTag("Clue"))
        {
            if (talkButton != null)
            {
                talkButton.SetActive(true);
            }
        }
        collidedObject = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC") || collision.gameObject.CompareTag("Clue"))
        {
            Debug.Log("dont talk with npc");
            if (talkButton != null)
            {
                talkButton.SetActive(false);

                if (collision.GetComponent<InteractionDialog>() != null)
                {
                    collision.GetComponent<InteractionDialog>().EndDialog();
                }
            }
        }
            collidedObject = null;
    }

    public void OnInteract()
    {
        if (collidedObject.CompareTag("NPC") || collidedObject.CompareTag("Clue"))
        {
            if (collidedObject.GetComponent<InteractionDialog>() != null)
            {
                collidedObject.GetComponent<InteractionDialog>().Interact();
            }
        }
    }
}
