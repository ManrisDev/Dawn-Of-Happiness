using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TestDialogue : MonoBehaviour
{
    public NPCConversation myConversation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ConversationManager.Instance.StartConversation(myConversation);
            Destroy(this.gameObject);
        }
    }
}
