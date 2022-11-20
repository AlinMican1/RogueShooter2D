using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = ("Create Enemy"))]
public class Enemy_Object : ScriptableObject
{
    public new string name;
    public int Health = 100;
    public int DropXp = 2;
    public int damage = 10;
    public int speed = 5;
    public int range = 2;
    public float attackCooldown = 1;
    public Sprite gem;
}
