using UnityEngine;
using TMPro;
using System.Collections;

public class TraderController : MonoBehaviour
{
    public Transform playerTransform;
    private SpriteRenderer spriteRenderer;

    public TextMeshProUGUI textMesh;
    public string[] traderDialogue = {
        "������, �������!",
        "�� ��� �� ����?",
        "���� �� ����� ���, ��� �� �����...",
        "��� � ����������� ���������, � ����� �������� ��������� �� ������.",
        "�� ����� ���-��, ��� ��������� ���� ������������ ��������� �������?",
        "���������� ������, ��������, ��� � ���������� - ����������!",
        "����� �� ������� ��, ��� �����, ����� ������. ��, ����� �������. Ÿ �������� ������ ���-�� ���...",
        "����� ��� ������� ������� ��������! ����, ��������, ��������� �� ���� ������� ����� ���� ����������. �� ��� �� �����...",
        "� ������ �������� �� ��������� ���� �� �������! ���, �� ������� ����, ���� �� �� ����� ������� ������...",
        "��� �� ������� ��, ����� ��������. ���, � ���������, ����� ��� ������������.",
        "���� ���� �������, ��� ���� ���� �� ����� � ������ ������� ����� ����������!",
    };
    public float displayTime = 7f;
    public float nextDialogueDelay = 20f;

    private bool playerNearby = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(DisplayDialogue());
    }

    void Update()
    {
        if (playerTransform != null)
        {
            if (playerTransform.position.x < transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            textMesh.text = "";
        }
    }

    IEnumerator DisplayDialogue()
    {
        while (true)
        {
            yield return new WaitUntil(() => playerNearby);

            if (traderDialogue.Length > 0)
            {
                int randomIndex = Random.Range(0, traderDialogue.Length);


                if (randomIndex >= 0 && randomIndex < traderDialogue.Length)
                {
                    textMesh.text = traderDialogue[randomIndex];

                }
                else
                {
                    Debug.LogError("Random index out of bounds!");
                }
            }
            else
            {
                Debug.LogError("Trader dialogue array is empty!");
            }

            yield return new WaitForSeconds(displayTime);

            textMesh.text = "";


            yield return new WaitForSeconds(nextDialogueDelay);

        }
    }
}
