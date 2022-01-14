using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnDoorClose : MonoBehaviour
{
    public UnityEvent onDoorClose;
    public Begone slidingDoors;

    public void SendEvent()
    {
        slidingDoors.eventGone = onDoorClose;
    }
}
