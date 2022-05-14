using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnvironmentChange : MonoBehaviour
{
    public AudioMixerSnapshot bigRoomSnapshot;
    public AudioMixerSnapshot smallRoomSnapshot;
    public AudioMixerSnapshot bathroomSnapshot;
    public AudioMixerSnapshot hallSnapshot;

    public float transitionTime = 0.2f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Small")
            smallRoomSnapshot.TransitionTo(transitionTime);
        if (collider.gameObject.tag == "Hall")
            hallSnapshot.TransitionTo(transitionTime);
        if (collider.gameObject.tag == "Bathroom")
            bathroomSnapshot.TransitionTo(transitionTime);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Small"
            || collider.gameObject.tag == "Hall"
            || collider.gameObject.tag == "Bathroom")
            bigRoomSnapshot.TransitionTo(transitionTime);
    }
}
