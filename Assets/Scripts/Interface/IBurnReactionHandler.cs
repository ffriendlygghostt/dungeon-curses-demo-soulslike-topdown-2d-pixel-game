public interface IBurnReaction
{
    /// <summary>
    /// ���������� true, ���� ��������� ������� ���������, � ����������� ���� �� �����.
    /// </summary>
    bool OnBurnTick(Burnable burnable, ref int damage);
}
