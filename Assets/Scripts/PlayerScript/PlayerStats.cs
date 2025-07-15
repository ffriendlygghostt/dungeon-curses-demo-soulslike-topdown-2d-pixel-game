using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float dashForce = 1f;
    public float attackImpulse = 0.15f;
    public int maxHealth = 100;
    public int maxStamina = 100;
    public int damageAmount = 25;
    public float attackRange = 1f;
    public float staminaRegenRate = 10f;

    public float critChance = 5f;
    public float critMultiplier = 2f;

    public float fireChance = 0f;
    public float iceChance = 0f;
    public float decayChance = 0f;
    public float bleedChance = 0f;

    [Header("Resistance")]
    [Range(0f, 1f)]
    public float fireResistance = 0f;

    public enum AttackType
    {
        None,
        Fire,
        Ice,
        Blood,
        Rot
    }

    // ������� ��������������� �������� � FIFO, ��� ������� ����������
    private Queue<AttackType> guaranteedEffects = new Queue<AttackType>();

    // --- GETTERS ---
    public int GetDamage() => damageAmount;
    public float GetCritChance() => critChance;
    public float GetCritMultiplier() => critMultiplier;
    public float GetFireChance() => fireChance;
    public float GetIceChance() => iceChance;
    public float GetDecayChance() => decayChance;
    public float GetBleedChance() => bleedChance;

    // --- MODIFIERS ---
    public void AddFireChance(float value) => fireChance += value;
    public void AddIceChance(float value) => iceChance += value;
    public void AddDecayChance(float value) => decayChance += value;
    public void AddBleedChance(float value) => bleedChance += value;

    // --- GUARANTEED EFFECTS ---
    /// <summary>
    /// �������� ��������������� ������ ��������� ���� ��������� ��� � �������.
    /// </summary>
    public void AddGuaranteedEffect(AttackType type, int count)
    {
        for (int i = 0; i < count; i++)
        {
            guaranteedEffects.Enqueue(type);
        }
    }

    /// <summary>
    /// ���������� �������� ��������� ��������������� ������. ���� ��� � ����� None.
    /// </summary>
    public AttackType TryConsumeGuaranteedEffect()
    {
        if (guaranteedEffects.Count > 0)
            return guaranteedEffects.Dequeue();
        return AttackType.None;
    }

    /// <summary>
    /// �������� ��� ��������������� �������.
    /// </summary>
    public void ClearGuaranteedEffects()
    {
        guaranteedEffects.Clear();
    }

    // --- RESETS ---
    public void ResetEffects()
    {
        fireChance = 0f;
        iceChance = 0f;
        decayChance = 0f;
        bleedChance = 0f;
        ClearGuaranteedEffects();
    }



    public void ResetSpeed() => moveSpeed = 2f;
    public void ResetHealth() => maxHealth = 100;


}