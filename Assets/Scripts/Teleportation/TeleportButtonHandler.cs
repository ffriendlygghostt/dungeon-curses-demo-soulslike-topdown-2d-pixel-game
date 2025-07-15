using UnityEngine;

public class TeleportButtonHandler : MonoBehaviour
{
    [Tooltip("���� ��������������� ������")]
    public Transform teleportTarget;

    [Tooltip("������ � ������ (PanelTeleport)")]
    public GameObject panelTeleport;

    [Tooltip("������� ������ ������")]
    public GameObject arrowObject;  // <-- �������� Arrow �� ��������!

    public void OnTeleportClick()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && teleportTarget != null)
        {
            player.transform.position = teleportTarget.position;
        }

        if (panelTeleport != null)
        {
            panelTeleport.SetActive(false);
            Time.timeScale = 1f;
        }

        if (arrowObject != null)
        {
            arrowObject.SetActive(true);   // <-- �������� ������� ����� ���������!
        }
    }
}
