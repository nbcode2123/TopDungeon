namespace Script.Actor.Weapon
{
    public interface IWeapon
    {
        public float WeaponDamage { get; set; }
        public float WeaponAttackSpeed { get; set; }
        public void Attack();



    }
}
