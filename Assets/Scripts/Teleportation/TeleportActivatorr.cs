using UnityEngine;

public class TeleportActivator : MonoBehaviour
{
    private TeleportManager teleportManager;
    private bool playerInTrigger = false;

    private void Start()
    {
        GameObject interfaceObj = GameObject.FindGameObjectWithTag("MainInterface");
        if (interfaceObj != null)
        {
            teleportManager = interfaceObj.GetComponentInChildren<TeleportManager>();
            if (teleportManager == null)
                Debug.LogError("TeleportManager �� ������ ����� �������� ����������� MainInterface.");
        }
        else
        {
            Debug.LogError("�� ������ ������ � ����� 'MainInterface'.");
        }
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E) && teleportManager != null)
        {
            teleportManager.ToggleTeleportPanel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInTrigger = false;
    }
}
