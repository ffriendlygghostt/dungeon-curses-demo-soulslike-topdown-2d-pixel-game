using UnityEngine;

public class EscapeMenuController : MonoBehaviour
{
    [Header("������ � �������� ������� (Menu, Tasks, Map, Inventory)")]
    public GameObject escapeMenuPanel;
    public TabSwitcher tabSwitcher;

    private bool isMenuOpen = false;

    void Start()
    {
        if (escapeMenuPanel != null)
        {
            escapeMenuPanel.SetActive(false);
        } else { Debug.LogWarning("qkaqkqa"); }
        isMenuOpen = false;
    }

    void Update()
    {
        // ��������/�������� ����� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }

        // ��������/�������� ������� ����� �� "M"
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleSpecificTab(tabSwitcher.ShowMapPanel);
        }

        // ��������/�������� ������� ��������� �� "Tab"
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleSpecificTab(tabSwitcher.ShowInventoryPanel);
        }

        // ��������/�������� ������� ������� �� "J"
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToggleSpecificTab(tabSwitcher.ShowTasksPanel);
        }
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        if (escapeMenuPanel != null)
        {
            escapeMenuPanel.SetActive(isMenuOpen);
        }

        if (isMenuOpen)
        {
            if (tabSwitcher != null)
            {
                tabSwitcher.ShowMenuPanel(); // �� ��������� ������ ��������� "Menu"
            }

            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void ToggleSpecificTab(System.Action showTabAction)
    {
        isMenuOpen = !isMenuOpen;
        if (escapeMenuPanel != null)
        {
            escapeMenuPanel.SetActive(isMenuOpen);
        }

        if (isMenuOpen)
        {
            showTabAction?.Invoke(); // ��������� ������ �������
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
