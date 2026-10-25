using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPitchShiftScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float range;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.pitch = Random.Range(audioSource.pitch - range, audioSource.pitch + range);
    }

}
