using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Begone : MonoBehaviour
{
    public UnityEvent eventGone;
    public void ChangeMenu()
    {
        eventGone.Invoke();
    }

    public void AudioPlayer()
    {
        FindObjectOfType<AudioManager>().Play("closeDoor");
    }
    public void OpenAudio()
    {
        FindObjectOfType<AudioManager>().Play("openDoor");
    }
    public void ClickSound()
    {
        FindObjectOfType<AudioManager>().Play("click");
    }
}
