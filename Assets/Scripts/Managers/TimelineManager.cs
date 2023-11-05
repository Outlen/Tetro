using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public GameObject elementChoice;

    void Start()
    {
        StartCoroutine("WaitForCutscene");
    }

    IEnumerator WaitForCutscene()
    {
        yield return new WaitForSeconds(44);
        elementChoice.SetActive(true);
    }
}
