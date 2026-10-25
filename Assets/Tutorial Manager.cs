using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameStateSO gameStateSO;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject scoreKeepers;
    [SerializeField] private GameObject pinkSlime;
    [SerializeField] private GameObject dummy;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject restartButton;

    [SerializeField] private Image image;
    [SerializeField] private List<Sprite> tutorialSteps;

    // Start is called before the first frame update
    void Start()
    {
        gameStateSO.isPlayerAlive = true;
        gameStateSO.tutorialStep = 0;
        gameStateSO.tutorialComplete = false;
        enemySpawner.SetActive(false);
        gameStateSO.slimesKilled = 0;
        gameStateSO.score = 0;
        gameStateSO.shotsLanded = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        button.SetActive(false);
        image.sprite = tutorialSteps[gameStateSO.tutorialStep];
        if (gameStateSO.shotsLanded > 0 && gameStateSO.tutorialStep == 0)
        {
            scoreKeepers.SetActive(false);
            button.SetActive(true);
        }
        if (gameStateSO.slimesKilled > 2 && gameStateSO.tutorialStep == 1)
        {
            scoreKeepers.SetActive(false);
            button.SetActive(true);
        }
        if (gameStateSO.tutorialStep == 2)
        {
            button.SetActive(false);
            gameStateSO.tutorialComplete = true;
            dummy.SetActive(false);
            enemySpawner.SetActive(true);
            if (!scoreKeepers.activeInHierarchy)
            {
                scoreKeepers.SetActive(true);
            }
        }
        if (!gameStateSO.isPlayerAlive)
        {
            gameStateSO.tutorialStep = 3;
            restartButton.SetActive(true);
            if (!scoreKeepers.activeInHierarchy)
            {
                scoreKeepers.SetActive(true);
            }
        }
    }
    public void ContinueTutorial()
    {
        gameStateSO.tutorialStep++;
        button.SetActive(false);
        if (gameStateSO.tutorialStep == 1)
        {
            Instantiate(pinkSlime, new Vector2(6,0), Quaternion.identity);
            Instantiate(pinkSlime, new Vector2(-6, 0), Quaternion.identity);
            Instantiate(pinkSlime, new Vector2(0, 3), Quaternion.identity);

            dummy.SetActive(false);
        }
        gameStateSO.score = 0;

    }
}
