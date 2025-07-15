using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationScript : MonoBehaviour
{
    public Transform[] teleportPoints; // ������ ����� ���������
    public GameObject[] doors; // ������ ������
    public int enemyCount = 0; // ����������� ���������� ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && enemyCount == 0)
        {
            // ���������� ������ �����, � ������� ����� �����
            int doorIndex = System.Array.IndexOf(doors, gameObject);

            // ���� ����� �� ������� � �������, ������� �� ������
            if (doorIndex == -1)
            {
                Debug.LogError("Door not found in the doors array!");
                return;
            }

            // ������������� ������ � ��������������� ����� ���������
            if (doorIndex < teleportPoints.Length)
            {
                other.transform.position = teleportPoints[doorIndex].position;
            }
            else
            {
                Debug.LogError("Teleport point not found for door index: " + doorIndex);
            }
        }
    }

    // ����� ��� ���������� ���������� ������
    public void DecreaseEnemyCount()
    {
        enemyCount--;

        // ���������, ���� ���������� ������ �������� ����, ������������ ������ � ������ � ����������
        if (enemyCount == 0)
        {
            UnlockDoorsAndTeleporters();
        }
    }

    // ����� ��� ������������� ������ � ����������
    private void UnlockDoorsAndTeleporters()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Collider>().enabled = true;
        }
    }
}