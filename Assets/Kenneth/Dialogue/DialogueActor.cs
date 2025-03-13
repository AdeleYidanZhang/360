using UnityEngine;

public class Actor : MonoBehaviour
{
    public string Name;
    public Dialogue Dialogue;

    public Canvas UI;

    // Trigger dialogue for this actor
    public void SpeakTo()
    {
        DialogueManager.Instance.StartDialogue(Name, Dialogue.RootNode);
        UI.gameObject.SetActive(false);
    }
}