using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnvironmentChange : MonoBehaviour
{
    public AudioMixerSnapshot mainHallSnapshot;
    public AudioMixerSnapshot bigRoomSnapshot;
    public AudioMixerSnapshot midRoomSnapshot;
    public AudioMixerSnapshot smallRoomSnapshot;
    public AudioMixerSnapshot bathroomSnapshot;
    public AudioMixerSnapshot gymSnapshot;

    public float transitionTime = 0.2f;

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Big":
                bigRoomSnapshot.TransitionTo(transitionTime);
                break;
            case "Mid":
                midRoomSnapshot.TransitionTo(transitionTime);
                break;
            case "Small":
                smallRoomSnapshot.TransitionTo(transitionTime);
                break;
            case "Bathroom":
                bathroomSnapshot.TransitionTo(transitionTime);
                break;
            case "Gym":
                gymSnapshot.TransitionTo(transitionTime);
                break;
            default:
                mainHallSnapshot.TransitionTo(transitionTime);
                break;
        }
    }
}