using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // For dialogue triggering purposes!!!

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        // Returns a value whose type is DialogueManager
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
