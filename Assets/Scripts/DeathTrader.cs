using UnityEngine;
using TMPro;
using System.Collections;
using TriggerNamespace; // ���������� ������������ ���� � TriggerHandler

public class DeathTrader : MonoBehaviour
{
    public string[] phrases = {
        "���� ������ ��� ������.",
        "�� �������, ��� ����� ����? ����������.",
        "�� ������� � �����, ��������� ��������.",
        "�� �������, ��� �� ��������? �� ���� ����� � ������ �����.",
        "���, ��� �� ����, ������ ������.",
        "������ ���� ������ ����� ����.",
        "������ � ��������? � ���� �����, ��� ��.",
        "��������� ������� �� �����, ��� ����.",
        "���� ����� � ��� ����.",
        "������ � ��� ����� ���� ������ ����� �������."
    }; // ������ ����
    private int currentPhraseIndex = 0; // ������ ������� �����
    public TMP_Text dialogueText; // ������ �� TextMeshPro ��������� ����

    public float phraseDelay = 10f; // �������� ����� ������ ����
    private Transform playerTransform; // ������ �� ��������� ������

    void Start()
    {
        // ������� ������� �� ����� � �����
        GameObject trigger = GameObject.Find("TriggerDialogDD");
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
            Debug.LogError("Trigger 'TriggerDialogDD' or its Collider2D not found!");
        }

        // ������� ������ �� ����
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found!");
        }
    }

    private void OnTriggerEntered(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowPhrasesWithDelay());
        }
    }

    IEnumerator ShowPhrasesWithDelay()
    {
        while (true)
        {
            ShowNextPhrase();
            FlipTowardsPlayer();
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

    private void FlipTowardsPlayer()
    {
        if (playerTransform != null)
        {
            Vector3 direction = playerTransform.position - transform.position;
            if (direction.x >= 0.1f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (direction.x <= -0.1f)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }
}

// ��������� ����� � ��������� ������������ ����
namespace TriggerNamespace
{
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
}
