using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] foostepsOnTile;
    public AudioClip[] foostepsOnWood;
    public AudioClip[] foostepsOnRug;

    public string material;

    void PlayFootstepSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = Random.Range(0.9f, 1.0f);
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        switch (material)
        {
            case "Tile":
                if (foostepsOnTile.Length > 0)
                    audioSource.PlayOneShot(foostepsOnTile[Random.Range(0, foostepsOnTile.Length)]);
                break;

            case "Wood":
                if (foostepsOnWood.Length > 0)
                    audioSource.PlayOneShot(foostepsOnWood[Random.Range(0, foostepsOnWood.Length)]);
                break;

            case "Rug":
                {
                    audioSource.volume = Random.Range(0.4f, 0.6f);
                    if (foostepsOnRug.Length > 0)
                        audioSource.PlayOneShot(foostepsOnRug[Random.Range(0, foostepsOnRug.Length)]);
                    break;

                }
            default:
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Tile":
            case "Wood":
            case "Rug":
                material = collision.gameObject.tag;
                break;

            default:
                break;
        }
    }
}
