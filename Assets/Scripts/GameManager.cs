using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���������� ��� ������������ ���������� ������
    public static int enemyCount = 0;

    // ����� ��� ���������� ���������� ������
    public static void DecreaseEnemyCount()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            // ��� ��� ��� �������� ������ ��� ��������� ������� ��������
        }
    }
}
