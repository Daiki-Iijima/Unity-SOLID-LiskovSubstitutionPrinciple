using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public override void TakeDamage(int amount) {
        //  ダメージ倍率を変更
        int damage = amount * 5;

        base.TakeDamage(damage);
    }
}
