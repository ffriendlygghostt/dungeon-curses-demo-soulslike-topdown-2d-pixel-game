using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    public Transform player;                      // �����
    public GameObject miniMapPanel;               // ������ ���������
    public BoxCollider2D worldBounds;             // ������� ���� (BoxCollider2D �� �����)
    public RectTransform mapImageRect;            // �����, ������� ����� ��������� (UI)
    public RectTransform maskRect;                // �����, �� ������ ������� �����

    private bool isMiniMapActive = false;

    void Start()
    {
        if (miniMapPanel != null)
            miniMapPanel.SetActive(isMiniMapActive);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            isMiniMapActive = !isMiniMapActive;
            if (miniMapPanel != null)
                miniMapPanel.SetActive(isMiniMapActive);
        }

        if (isMiniMapActive)
        {
            UpdateMapPosition();
        }
    }

    void UpdateMapPosition()
    {
        if (player == null || worldBounds == null || mapImageRect == null || maskRect == null)
            return;

        // �������� ������� ����
        Vector2 worldMin = worldBounds.bounds.min;
        Vector2 worldMax = worldBounds.bounds.max;
        Vector2 playerPos = player.position;

        // ����������� ������� ������ ������������ ������ ����
        float normX = Mathf.InverseLerp(worldMin.x, worldMax.x, playerPos.x);
        float normY = Mathf.InverseLerp(worldMin.y, worldMax.y, playerPos.y);

        // ������ ����� � UI
        float mapWidth = mapImageRect.rect.width;
        float mapHeight = mapImageRect.rect.height;

        // ��������� ����� ������� �����: �������� ����� ���, ����� ����� �������� � ������ �����
        float posX = Mathf.Lerp(-mapWidth / 2f, mapWidth / 2f, 1 - normX);
        float posY = Mathf.Lerp(-mapHeight / 2f, mapHeight / 2f, 1 - normY);

        mapImageRect.anchoredPosition = new Vector2(posX, posY);
    }
}
