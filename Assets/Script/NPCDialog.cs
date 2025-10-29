using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    Transform NPC;
    GameObject talkButton;
    private TextMeshProUGUI dialogText;
    private float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;
    private string dialogLine;


    public void Start()
    {
        NPC = gameObject.transform;
        name = gameObject.name;
        dialogLine = "";
    }
    public void Talk()
    {
        if (NPC != null)
        {
            foreach (Transform child in NPC)
            {
                Debug.Log("Child name: " + child.name);
                if (child.name.Equals("TalkButton"))
                {
                    talkButton = child.gameObject;
                    talkButton.SetActive(true);
                    break;
                }
            }
        }
    }

    public void TalkToGrandma()
    {
        if (NPC != null)
        {
            foreach (Transform child in NPC)
            {
                Debug.Log("Child name: " + child.name);
                if (child.name.Equals("Dialog1"))
                {
                    talkButton.SetActive(false);
                    child.gameObject.SetActive(true);
                    foreach (Transform grandchild in child)
                    {
                        Debug.Log("Grandchild name: " + grandchild.name);
                        if (grandchild.name.Equals("DialogText"))
                        {
                            dialogText = grandchild.gameObject.GetComponent<TextMeshProUGUI>();
                            // Example dialog text
                            dialogLine = DialogRepository.GetDialog(NPC.name, child.name);

                            // stop previous typing if still running
                            if (typingCoroutine != null)
                            {
                                StopCoroutine(typingCoroutine);
                            }

                            typingCoroutine = StartCoroutine(TypeText(dialogLine));
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }

    public void CancelTalkToGrandma()
    {
        EndDialog();
        if (talkButton != null)
        {
            talkButton.SetActive(true);
        }
    }

    public void EndDialog()
    {
        if (NPC != null)
        {
            foreach (Transform child in NPC)
            {
                Debug.Log("Child name: " + child.name);
                child.gameObject.SetActive(false);  
            }
        }
    }

    private IEnumerator TypeText(string fullText)
    {
        dialogText.text = "";
        foreach (char c in fullText)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
