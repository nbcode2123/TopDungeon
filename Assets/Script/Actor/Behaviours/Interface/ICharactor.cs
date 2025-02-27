using UnityEngine;

public interface ICharactor
{
    public string Name { set; get; }
    public int Health { set; get; }
    public int Speed { set; get; }
    public int AttackSpeed { set; get; }
    public Rigidbody2D rigidbody2D { set; get; }





}
