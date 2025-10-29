using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class InteractionDialog : MonoBehaviour
{
    private Transform NPC;
    private TextMeshProUGUI dialogText;
    private float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;
    private Dictionary<string, string> dialogLines;
    [SerializeField] private GameObject dialog;
    [SerializeField] private Image characterPortrait;
    private const string characterPortraitPath = "CharacterPortrait/";

    public void Start()
    {
        NPC = gameObject.transform;
        name = gameObject.name;
        dialogLines = null;
    }

    public void Interact()
    {
        if (NPC != null && dialog != null)
        {
            dialog.SetActive(true);
            foreach (Transform child in dialog.transform)
            {
                Debug.Log("Child name: " + child.name);
                if (child.name.Equals("DialogText"))
                {
                    dialogText = child.gameObject.GetComponent<TextMeshProUGUI>();
                    dialogLines = DialogRepository.GetDialog(NPC.name);

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
        else
        {
            Debug.Log("NPC or Dialog is null");
        }
    }

    public void EndDialog()
    {
        if (NPC != null && dialog != null)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            dialog.SetActive(false);
        }
    }

    private IEnumerator TypeText(Dictionary<string, string> dialogLines)
    {
        foreach (KeyValuePair<string, string> entry in dialogLines)
        {
            string line = entry.Value;
            dialogText.text = "";
            DialogCharacter(entry.Key);
            foreach (char c in line)
            {
                dialogText.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void DialogCharacter(string name)
    {
        if (characterPortrait != null)
        {
            string path = "";
            Sprite sprite;
            if (name.Contains(NPC.name))
            {
                path = characterPortraitPath + NPC.name;
            }
            else if (name.Contains("Alicia"))
            {
                path = characterPortraitPath + "Alicia";
            }
            else if (name.Contains("Eris"))
            {
                path = characterPortraitPath + "Eris";
            }
            else if (name.Contains("Yuto"))
            {
                path = characterPortraitPath + "Yuto";
            }
            else 
            {
                Debug.Log("Character name doesn't match");
            }

            sprite = Resources.Load<Sprite>(path);
            
            if (sprite != null)
            {
                characterPortrait.sprite = sprite;
            }
            else
            {
                Debug.LogWarning("Sprite not found");
            }
        }
        else
        {
            Debug.Log("Character Image is null");
        }
    }
}
