using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GunSelectionManager : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private TextMeshProUGUI descriptionText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSO.currentCharacter == 0)
        {
            descriptionText.SetText("Revolver:<br>The classic. Can hold an unrealistically high 12 bullets in a single cylinder. Also my favourite Beatle's album.");
        }
        else if (playerSO.currentCharacter == 1)
        {
            descriptionText.SetText("Shotgun:<br>Spread shot.");
        }
        else if (playerSO.currentCharacter == 2)
        {
            descriptionText.SetText("Minigun:");
        }
    }

    public void ChangeGun(int changeAmount)
    {
        playerSO.currentCharacter += changeAmount;
        CheckGunIsInBounds();

    }
    public void SetGun(int gunID)
    {
        playerSO.currentCharacter = gunID;
        CheckGunIsInBounds();

    }
    private void CheckGunIsInBounds()
    {
        if (playerSO.currentCharacter > playerSO.totalCharacters - 1)
        {
            playerSO.currentCharacter = 0;
        }
        else if (playerSO.currentCharacter < 0)
        {
            playerSO.currentCharacter = playerSO.totalCharacters - 1;
        }
    }

}
