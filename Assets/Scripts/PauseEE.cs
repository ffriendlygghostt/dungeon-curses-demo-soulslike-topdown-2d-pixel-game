using UnityEngine;
using UnityEngine.SceneManagement; // ��� ���������� �������

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        // ������ ���� ����� ��� ������� ����
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // ���� ������ ������� Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // �������� ���� �����
        Time.timeScale = 1f; // ������������ ����
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); // ���������� ���� �����
        Time.timeScale = 0f; // ������������� ������� �������
        GameIsPaused = true;
    }

    public void ReloadScene() // ����� ��� ������������ �����
    {
        Time.timeScale = 1f; // ���������� ���������� ������� �������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������������� ������� �����
    }

    public void QuitGame() // ����� ��� ������ �� ����
    {
        // ��������� ���������
#if UNITY_EDITOR
        // � ��������� Unity ������ ������������� ����
        Debug.Log("���� ��������� (��� �������� ������ � ���������)");
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // � ��������� ������ ���� ������� �� ����������
        Debug.Log("����� �� ����");
        Application.Quit();
#endif
    }
}
