using UnityEngine;

public class TabSwitcher : MonoBehaviour
{
    [Header("������ �� ������")]
    public GameObject panelMenu;       // ������, ������� �� ������ ���������� ��� "����"
    public GameObject panelTasks;      // ������ ��� "�������"
    public GameObject panelMap;        // ������ ��� "�����"
    public GameObject panelInventory;  // ������ ��� "���������"

    // ������ ��� ������:

    public void ShowMenuPanel()
    {
        panelMenu.SetActive(true);
        panelTasks.SetActive(false);
        panelMap.SetActive(false);
        panelInventory.SetActive(false);
    }

    public void ShowTasksPanel()
    {
        panelMenu.SetActive(false);
        panelTasks.SetActive(true);
        panelMap.SetActive(false);
        panelInventory.SetActive(false);
    }

    public void ShowMapPanel()
    {
        panelMenu.SetActive(false);
        panelTasks.SetActive(false);
        panelMap.SetActive(true);
        panelInventory.SetActive(false);
    }

    public void ShowInventoryPanel()
    {
        panelMenu.SetActive(false);
        panelTasks.SetActive(false);
        panelMap.SetActive(false);
        panelInventory.SetActive(true);
    }
}
