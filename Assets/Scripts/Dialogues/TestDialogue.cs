using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TestDialogue : MonoBehaviour
{
    public NPCConversation myConversation;

    void Start ()
    {
        ConversationManager.Instance.StartConversation(myConversation);
        Debug.Log("Начался первый диалог");
    }
}
