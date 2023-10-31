using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStage : MonoBehaviour
{
    public GameObject NoteButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitForIntro");
        
    }

    IEnumerator WaitForIntro()
    {
        yield return new WaitForSeconds(15);
        NoteButton.SetActive(true);
    }
}
