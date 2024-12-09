namespace Script.Actor.Behaviours.Interface
{
    public interface IActorStats
    {
        string ActorName { get; set; }
        float MaxHeath { get; set; }
        float currentHeath { get; set; }
        float MoveSpeed { get; set; }
        float AttackDamage { get; set; }

    }
}
