using UnityEngine;
using TriggerNamespace; // ���������� ������������ ���� � TriggerHandler

public class TriggerDialogDD : MonoBehaviour
{
    private void Start()
    {
        // �������� �� ������� ���������� TriggerHandler � ���������� ���, ���� �� �����������
        if (GetComponent<TriggerHandler>() == null)
        {
            gameObject.AddComponent<TriggerHandler>();
        }
    }
}
