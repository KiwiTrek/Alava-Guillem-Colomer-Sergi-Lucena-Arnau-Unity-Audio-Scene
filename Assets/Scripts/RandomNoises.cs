using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoises : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] noises;
    public AudioSource source;
    public Transform player;
    public bool randomPitch;
    public bool insideSource;
    public float maxDistance;

    float timerDt = 0.0f;
    float randomCD = 0.0f;
    void Start()
    {
        timerDt = 0.0f;
        randomCD = Random.Range(1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timerDt += Time.deltaTime;
        if (timerDt >= randomCD)
        {
            timerDt = 0.0f;
            randomCD = Random.Range(1.0f, 2.0f);

            int diceRoll = Random.Range(1, 4);
            if (diceRoll == 3)
            {
                if (randomPitch)
                {
                    source.pitch = Random.Range(0.9f, 1.1f);
                }
                else
                {
                    source.pitch = 1.0f;
                }

                if (insideSource)
                {
                    if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= maxDistance)
                    {
                        Debug.Log("Inside a Source");
                        source.PlayOneShot(noises[Random.Range(0, noises.Length)]);
                    }
                }
                else
                {
                    source.PlayOneShot(noises[Random.Range(0, noises.Length)]);
                }
            }
            else
            {
                Debug.Log("miss");
            }
        }
    }
}
