namespace TheFantasyOlympics.Domain.Entities.Base
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; } = string.Empty;

        public void UpdateName(string newName)
        {
            Name = newName;
        }
    }
}
