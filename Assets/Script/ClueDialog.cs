using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClueDialog : MonoBehaviour
{
    Transform clue;
    GameObject interactButton;
    private TextMeshProUGUI dialogText;
    private float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;
    private Dictionary<string, string> dialogLines;
    [SerializeField] private GameObject dialog;
    [SerializeField] private Image characterPortrait;
    private const string characterPortraitPath = "CharacterPortrait/";

    public void Start()
    {
        clue = gameObject.transform;
        name = gameObject.name;
        dialogLines = null;
    }

    public void Interact()
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
                    dialogLines = DialogRepository.GetDialog(clue.name);

                    // stop previous typing if still running
                    if (typingCoroutine != null)
                    {
                        StopCoroutine(typingCoroutine);
                    }

                    if (dialogLines != null)
                    {
                        typingCoroutine = StartCoroutine(TypeText(dialogLines));
                    }
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

    private IEnumerator TypeText(Dictionary<string, string> fullText)
    {
        foreach (KeyValuePair<string, string> entry in dialogLines)
        {
            string line = entry.Value;
            dialogText.text = "";
            foreach (char c in line)
            {
                dialogText.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
