using UnityEngine;
using DialogueEditor;

public class TestDialogue : MonoBehaviour
{
    public NPCConversation[] myConversations;
    private int currentConversation = 1;

    void Start ()
    {
        ConversationManager.Instance.StartConversation(myConversations[0]);
    }

    public void NextDialogue()
    {
        if (currentConversation < myConversations.Length)
        {
            ConversationManager.Instance.StartConversation(myConversations[currentConversation]);
            currentConversation += 1;
        }
    }
}
