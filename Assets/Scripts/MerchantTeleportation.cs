using UnityEngine;
using TMPro; // ��� ������ � �������
using UnityEngine.UI; // ��� ������ � UI

public class MerchantTeleportation : MonoBehaviour
{
    public GameObject teleportConfirmationPanel; // ������ �������������
    public TMP_Text confirmationText; // ������ �� ��������� �������
    private bool isPlayerInRange = false; // ��������, ��������� �� ����� � ���� ���������

    public Transform merchantTeleportTrigger; // ������ �� ������� � ������� ��������

    private void Start()
    {
        teleportConfirmationPanel.SetActive(false); // �������� ������ ������������� ����������
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowTeleportConfirmation();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; // ����� ��������� � ��������
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // ����� ����� �� ����
            HideTeleportConfirmation();
        }
    }

    private void ShowTeleportConfirmation()
    {
        teleportConfirmationPanel.SetActive(true); // ���������� ������ �������������
    }

    public void OnYesButtonPressed()
    {
        TeleportToMerchant(); // ������ ������������
        HideTeleportConfirmation();
    }

    public void OnNoButtonPressed()
    {
        HideTeleportConfirmation();
    }

    private void TeleportToMerchant()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (merchantTeleportTrigger != null)
        {
            player.transform.position = merchantTeleportTrigger.position; // ������������ ������ � ��������
        }
    }

    private void HideTeleportConfirmation()
    {
        teleportConfirmationPanel.SetActive(false); // �������� ������ �������������
    }
}
