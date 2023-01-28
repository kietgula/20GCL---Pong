using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip pong;
    public AudioSource audioSource;
    // Start is called before the first frame update
    public void playPong()
    {
        audioSource.PlayOneShot(pong);
    }
}
