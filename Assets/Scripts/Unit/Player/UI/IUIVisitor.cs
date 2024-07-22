public interface IUIVisitor
{
    public void Visit(DoorManager door);
    public void Visit(ChestManager chest);
    public void Visit(LoadLvL loader);
    public void Visit();
}