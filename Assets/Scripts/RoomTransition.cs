using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Transform nextRoomSpawnPoint; // ����� ������ � ��������� �������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ���������, ��� ��� �����
        {
            // ���������� ������ � ��������� �������
            collision.transform.position = nextRoomSpawnPoint.position;
        }
    }
}
