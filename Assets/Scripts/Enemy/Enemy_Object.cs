using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a scriptable object script, where it allows the creation of any type of enemy based on it's attributes.
[CreateAssetMenu(fileName = "New Enemy", menuName = ("Create Enemy"))]
public class Enemy_Object : ScriptableObject
{
    //Assign the default enemy values, however these can be changed based on what the enemy type is.
    public new string name;
    public int Health = 100;
    public int DropXp = 2;
    public int damage = 10;
    public int speed = 5;
    public int range = 2;
    public float attackCooldown = 1;
    public Sprite gem;
}
