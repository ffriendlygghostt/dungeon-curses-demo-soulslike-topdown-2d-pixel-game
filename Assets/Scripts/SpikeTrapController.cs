using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
    public float delay = 2.0f; // ����� �������� ����� ����������� �����
    public float duration = 1.0f; // �����, � ������� �������� ���� ��������� � �������� ���������
    public int damageAmount = 10; // ���������� �����, ���������� ������

    private bool isActive = false;
    private float timer = 0.0f;

    private Animator animator;
    private Collider2D spikeCollider; // ��������� �����

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        spikeCollider = GetComponentInChildren<Collider2D>();

        // ���������, ��� ��������� ���������� ��������
        if (spikeCollider != null)
        {
            spikeCollider.enabled = false;
        }

        SetActiveState(false);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isActive)
        {
            if (timer >= duration)
            {
                SetActiveState(false);
                timer = 0.0f;
            }
        }
        else
        {
            if (timer >= delay)
            {
                SetActiveState(true);
                timer = 0.0f;
            }
        }
    }

    private void SetActiveState(bool active)
    {
        isActive = active;

        if (animator != null)
        {
            animator.SetBool("IsActive", isActive);
        }

        if (spikeCollider != null)
        {
            spikeCollider.enabled = isActive; // �������� ��� ��������� ���������
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �������� ���������� ���������, ����� �������, ��� ����������
        Debug.Log($"Trigger detected with {other.gameObject.name}");

        // ��������, ���� ������ - �����
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by spikes!");

            // ���������� ����� ��������� PlayerController �� ������� ������ � ������� ����
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damageAmount); // ���������� � ������, ������� � ���� �������� �� ��������� �����
            }
            else
            {
                Debug.LogError("PlayerController component not found on player.");
            }
        }
    }
}
