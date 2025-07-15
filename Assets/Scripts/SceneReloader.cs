using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    // �����, ������� ����� ���������� ��� ������� ������
    public void ReloadSceneOnButtonPress()
    {
        // �������� ������ ������� �������� �����
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // ������������� ����� �� �� �������
        SceneManager.LoadScene(activeSceneIndex);
    }
}