using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteButton : MonoBehaviour
{
    public GameObject Note;
    public GameObject TextBox;
    public GameObject TutorialButton;

    public void ShowNote()
    {
        Note.SetActive(true);
        TextBox.SetActive(false);
        TutorialButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
