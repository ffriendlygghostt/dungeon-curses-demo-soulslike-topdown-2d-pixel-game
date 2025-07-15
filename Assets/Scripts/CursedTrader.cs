using UnityEngine;
using TMPro;
using System.Collections;

public class CursedTrader : MonoBehaviour
{
    public string[] phrases = {
        "���� ������� ������ ���������, �������� ���� � ���� �������",
        "�� ������ � ������� �� ����� ��������.",
        "���� ���� ����� ����, ������ �� ����� ��� ���.",
        "�� ������ �� ���� ������������ �����, ��� ���� ��� �������� ����",
        "����� �� ����� ������ �����, �� �� ������ �����������.",
        "����� �� �������, ��� ��� ������ �������� ����.",
        "����������� � ������� � ����������.",
        "����� ���� ����� ������������ � �������.",
        "� � ��������� �������� ����� ������ ����.",
        "��� �������� ������ ���� �������, �� ������ ����� ��������� �������."
    }; // ������ ����
    private int currentPhraseIndex = 0; // ������ ������� �����
    public TMP_Text dialogueText; // ������ �� TextMeshPro ��������� ����

    public float phraseDelay = 7f; // �������� ����� ������ ����

    public Transform player; // ������ �� ���������

    public Animator animator; // ������ �� �������� �����

    public float moveSpeed = 2f; // �������� �������� �����
    public float attackDistance = 1.5f; // ��������� �� ������ ��� �����

    public int damageAmount = 200; // ����, ��������� ������

    public float attackDelay = 2f; // �������� ����� �������
    private bool canAttack = true; // ����, ����������� �����
    private bool isAttacking = false; // ���� ����� �����

    private bool isFlying = false; // ���� ������ �����
    private bool shouldAttack = false; // ����, �����������, ������ �� ���� ���������

    void Start()
    {
        // ������� ������� �� ����� � �����
        GameObject trigger = GameObject.Find("DeathComming");
        // �������� ��������� Collider2D � ��������
        Collider2D triggerCollider = trigger.GetComponent<Collider2D>();
        // ���������, ��� ������� � ��� ��������� �������
        if (trigger != null && triggerCollider != null)
        {
            // ������ ���������� �� ������� ����� � �������
            triggerCollider.isTrigger = true;
            triggerCollider.gameObject.AddComponent<TriggerHandler>().OnTriggerEnterEvent += OnTriggerEntered;
        }
        else
        {
            Debug.LogError("Trigger 'DeathComming' or its Collider2D not found!");
        }
    }

    private void OnTriggerEntered(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowPhrasesWithDelay());
            isFlying = true;
            animator.SetBool("Flying", true);
            shouldAttack = true; // �������� �����, ����� ����� ������ � �������
        }
    }

    IEnumerator ShowPhrasesWithDelay()
    {
        while (true)
        {
            ShowNextPhrase();
            yield return new WaitForSeconds(phraseDelay);
        }
    }

    public void ShowNextPhrase()
    {
        if (phrases.Length > 0)
        {
            // ���������� ����� � UI
            dialogueText.text = phrases[currentPhraseIndex];

            // ������� � ��������� �����
            currentPhraseIndex = (currentPhraseIndex + 1) % phrases.Length;
        }
    }

    void Update()
    {
        if (player != null && isFlying)
        {
            // ���������� ����������� � ���������
            Vector3 direction = (player.position - transform.position).normalized;
            float distance = Vector3.Distance(player.position, transform.position);

            // ��������� � ������, ���������� �� ���������� �� ������
            transform.position += direction * moveSpeed * Time.deltaTime;
            // ������������� �������� ��������
            animator.SetBool("isMoving", true);

            // ������� �������� � ������� ���������, ���� �� ��������� �����
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            // �����, ���� �������� ������, ��������� ��� ���������
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            // ������� ������, ���� ����� ���������
            if (!isAttacking && canAttack && shouldAttack)
            {
               
                isAttacking = true;
                animator.SetTrigger("Attack1");
                StartCoroutine(ResetAttack());
            }
        }
    }

    // �����, ���������� �������� �������� ��� ��������� �����
    public void DealDamage()
    {
        if (player == null)
        {
            // ���� ����� ���������, ������� �� ������
            isAttacking = false;
            return;
        }

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= attackDistance)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damageAmount);
            }
        }
    }

    IEnumerator ResetAttack()
    {
        // ���� �������� ��������
        yield return new WaitForSeconds(attackDelay);
        // ���������� ���� ����� � ��������� ����� �����
        isAttacking = false;
        canAttack = true;
    }
}

// ����� ��� ��������� ������� ��������
public class TriggerHandler : MonoBehaviour
{
    // ������� ����� � �������
    public event System.Action<Collider2D> OnTriggerEnterEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �������� ������� ����� � �������
        OnTriggerEnterEvent?.Invoke(other);
    }
}
