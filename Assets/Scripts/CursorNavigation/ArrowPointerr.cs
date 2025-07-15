using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ArrowCircle : MonoBehaviour
{
    [SerializeField] private Transform center; // ������ player
    [SerializeField] private float radius = 1f;

    private Camera mainCam;
    private Vector3 originalScale;
    private SpriteRenderer spriteRend;

    void Start()
    {
        mainCam = Camera.main;
        originalScale = transform.localScale;
        spriteRend = GetComponent<SpriteRenderer>();
        // ��� Debug.Log ������
    }

    void Update()
    {
        // 1. ������� ���� (������� ����������)
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f;

        // 2. direction: (���� - �����)
        Vector3 direction = mouseWorldPos - center.position;
        float distToMouse = direction.magnitude;

        // ���� �����, ��� radius � ������ �������
        if (distToMouse < radius)
        {
            spriteRend.enabled = false;
            return;
        }
        else
        {
            spriteRend.enabled = true;
        }

        // 3. ����������� �����������
        if (direction.sqrMagnitude < 0.001f)
            direction = Vector3.right;
        direction.Normalize();

        // 4. ������ ������� �� ����������:
        //    ����� + (����������� * radius)
        Vector3 arrowPos = center.position + direction * radius;
        transform.position = arrowPos;

        // 5. ���� + 180�
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 180f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 6. �������� angle � -180..180
        float normalizedAngle = Mathf.DeltaAngle(0f, angle);

        // 7. ����
        if (normalizedAngle > 90f || normalizedAngle < -90f)
        {
            transform.localScale = new Vector3(originalScale.x, -originalScale.y, originalScale.z);
        }
        else
        {
            transform.localScale = originalScale;
        }
    }
}
