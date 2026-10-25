using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    [SerializeField] private float changeDelay;
    [SerializeField] private string sceneName;
    private void Update()
    {
        if (changeDelay > 0)
        {
            changeDelay -= Time.deltaTime;
        }
        else if (changeDelay < 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    public void ChangeScene(float delay)
    {
        changeDelay = delay;
    }
}
