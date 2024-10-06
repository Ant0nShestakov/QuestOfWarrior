public interface IAttackStateVisitor : IIdleStateVisitor
{
    public bool Visit(Block state);
    public bool Visit(AutoAttack state);
    public bool Visit(FirstSpecialAttack state);
    public bool Visit(SecondSpecialAttack state);
    public bool Visit(ThridSpecialAttack state);
    public bool Visit(FourthSpecialAttack state);
    public bool Visit(FifthSpecialAttack state);
    public bool Visit(SixSpecialAttack state);
    public bool Visit(SeventhSpecialAttack state);
} 