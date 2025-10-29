using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClueDialog : MonoBehaviour
{
    Transform clue;
    GameObject interactButton;
    [SerializeField] private GameObject dialog;
    private TextMeshProUGUI dialogText;
    private float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;
    private string dialogLine;


    public void Start()
    {
        clue = gameObject.transform;
        name = gameObject.name;
        dialogLine = "";
    }
    public void Interact()
    {
        if (clue != null)
        {
            foreach (Transform child in clue)
            {
                Debug.Log("Child name: " + child.name);
                if (child.name.Equals("Button"))
                {
                    interactButton = child.gameObject;
                    interactButton.SetActive(true);
                    break;
                }
            }
        }
    }

    public void InteractClue()
    {
        if (clue != null)
        {
            interactButton.SetActive(false);
            dialog.SetActive(true);
            foreach (Transform child in dialog.transform)
            {
                Debug.Log("Child name: " + child.name);
                if (child.name.Equals("DialogText"))
                {
                    dialogText = child.gameObject.GetComponent<TextMeshProUGUI>();
                    // Example dialog text
                    dialogLine = DialogRepository.GetDialog(clue.name, "");

                    // stop previous typing if still running
                    if (typingCoroutine != null)
                    {
                        StopCoroutine(typingCoroutine);
                    }

                    typingCoroutine = StartCoroutine(TypeText(dialogLine));
                    break;
                }
            }
        }
    }

    public void CancelClueDialog()
    {
        EndClue();
        if (interactButton != null)
        {
            interactButton.SetActive(true);
        }
    }


    public void EndClue()
    {
        if (interactButton != null && dialog != null)
        {
            interactButton.SetActive(false);
            dialog.SetActive(false);
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
