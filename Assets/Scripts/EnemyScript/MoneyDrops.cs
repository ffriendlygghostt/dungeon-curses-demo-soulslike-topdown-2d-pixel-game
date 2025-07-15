using UnityEngine;

public class MoneyDrop : MonoBehaviour
{
    public float initialSpeed = 1.5f;
    public float acceleration = 1f; // �������� ����� (��/���)

    private float currentSpeed;
    private Transform target;

    public void LaunchTo(Transform player)
    {
        target = player;
        currentSpeed = initialSpeed;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // ����������� �������� ������ �� ��������
        currentSpeed += acceleration * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinWallet.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
