using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField]
    int currentExperience, maxExperience, currentLevel;

    public GameObject player;
    public UnitStats playerStats;

    void Start()
    {
        playerStats = player.GetComponent<UnitStats>();
    }

    private void OnEnable()
    {
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    }

    private void OnDisable()
    {
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }

    private void HandleExperienceChange(int newExperience)
    {
        currentExperience += newExperience;
        if (currentExperience >= maxExperience)
        {
            playerStats.LevelUp();
            currentLevel++;
            currentExperience = 0;
            maxExperience += 100;
        }
    }



}
