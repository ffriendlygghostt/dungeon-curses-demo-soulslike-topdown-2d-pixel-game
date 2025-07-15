using UnityEngine;
using TMPro;

public class CurseTrigger : MonoBehaviour
{
    public CursedTrader trader; // ������ �� ������ ��������
    public TMP_Text traderDialogCurse; // ������ �� TextMeshPro ��������� ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trader.dialogueText = traderDialogCurse; // �������� ������ �� ��������� ���� ��������
            trader.ShowNextPhrase(); // ����� ������ ����������� ��������� ����� ��������
        }
    }
}
