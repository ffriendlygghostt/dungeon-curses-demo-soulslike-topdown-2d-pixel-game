using UnityEngine;

public class RoomTransitionSeller : MonoBehaviour
{
    public Transform nextRoomSpawnPoint; // ����� ������ � ��������� �������
    private bool playerInTrigger = false; // ���������� ��� ������������ ��������� ������

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E)) // ���������, ��� ����� � �������� � ����� ������� E
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = nextRoomSpawnPoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ���������, ��� ��� �����
        {
            playerInTrigger = true; // ������������� ����, ��� ����� � ��������
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ���������, ��� ��� �����
        {
            playerInTrigger = false; // ���������� ����, ��� ����� ����� �� ��������
        }
    }
}
