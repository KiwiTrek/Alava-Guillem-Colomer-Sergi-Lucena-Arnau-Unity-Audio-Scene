using TMPro;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro UseText;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private float MaxUseDistance = 5f;
    [SerializeField]
    private LayerMask UseLayers;

    private void Update()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDistance, UseLayers)
            && hit.collider.TryGetComponent<Door>(out Door door))
        {
            if (door.IsOpen)
            {
                UseText.SetText("Close \"E\"");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    door.Close();
                }
            }
            else
            {
                UseText.SetText("Open \"E\"");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    door.Open(transform.position);
                }
            }
            UseText.gameObject.SetActive(true);
            UseText.transform.position = Player.transform.position + new Vector3(-1.25f,1.5f,0);
            UseText.transform.rotation = Quaternion.LookRotation((hit.point - Camera.position).normalized);
        }
        else
        {
            UseText.gameObject.SetActive(false);
        }
    }
}