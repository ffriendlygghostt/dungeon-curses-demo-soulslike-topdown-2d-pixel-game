using System.Collections;
using UnityEngine;

public class CoinPref : MonoBehaviour
{
    public float flySpeed = 5f; // �������� ������ ������
    public float hangTime = 1f; // �����, ������� ������ ����� � ������� ����� ��� ��� ������ � ������

    private Transform playerTransform; // ������ �� ��������� ������
    private bool isFlying = false; // ���� ��� �����������, ����� �� ������ � ������
    private Collider2D coinCollider; // ��������� ������

    private void Start()
    {
        // ������� ������ �� ���� "Player" � �������� ������ �� ��� ���������
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // ���� ����� �� ������, ������� ��������� �� ������
        if (playerTransform == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'Player' tag assigned.");
        }
        else
        {
            // ��������� ��������, ����� ������ ������� � ������� �� ��������� �����, � ����� ������ ������ � ������
            StartCoroutine(HangThenFly());
        }

        // ���������� ������ ������ 
        gameObject.SetActive(true);

        // �������� ��������� ������
        coinCollider = GetComponent<Collider2D>();
        if (coinCollider == null)
        {
            Debug.LogError("Collider2D not found on the coin prefab.");
        }
    }

    private void Update()
    {
        // ���� ������ � ������ � ������
        if (isFlying)
        {
            // ��������� ����������� � ������
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            // ���������� ������ � ���� ����������� � �������� ���������
            transform.Translate(direction * flySpeed * Time.deltaTime, Space.World);
        }
    }

    private IEnumerator HangThenFly()
    {
        // ��������, ����� ������ ������� � �������
        yield return new WaitForSeconds(hangTime);

        // ������������� ���� � true, ����� ������ ������ ������ � ������
        isFlying = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���� ������ ����������� � �������
        if (other.CompareTag("Player"))
        {
            // ���������� ������
            Destroy(gameObject);

            // ��������� ���� ���� � �������
            CoinWallet.AddCoins(1);
        }
    }
}
