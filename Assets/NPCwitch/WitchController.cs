//using UnityEngine;

//public class WitchControlle : MonoBehaviour
//{
//    public Transform player; // ������ �� ������
//    private SpriteRenderer spriteRenderer;

//    void Start()
//    {
//        spriteRenderer = GetComponent<SpriteRenderer>();
//    }

//    void Update()
//    {
//        // ���������, ���� ����� ����������
//        if (player != null)
//        {
//            // �������� ������ �� ������ � ������
//            Vector3 direction = player.position - transform.position;

//            // ���������� ���� ��������
//            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

//            // ������� ������ � ����������� �� �����������
//            if (direction.x < 0)
//            {
//                spriteRenderer.flipX = true; // ���� �� X, ���� ����� �����
//            }
//            else
//            {
//                spriteRenderer.flipX = false; // ��� �����, ���� ����� ������
//            }
//        }
//    }
//}
