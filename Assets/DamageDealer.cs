using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ダメージを与える対象を決定する
/// </summary>
public class DamageDealer : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            DealDamageToNearestCharacter();
        }
    }

    /// <summary>
    /// 最も近いキャラクターにダメージを与える
    /// </summary>
    private void DealDamageToNearestCharacter() {

        Character nearestCharacter = FindObjectsOfType<Character>()
            .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
            .FirstOrDefault();

        int damageToDeal = 1;

        //  問題あり : NPC型に依存する形になっている
        //  一番近いのがNPCの場合
        if(nearestCharacter is NPC) {
            damageToDeal *= 5;
        }

        //  問題あり : ダメージが一律ではないのであれば、TakeDamageに渡す値を変える必要が出てくる
        //  = リスコフの置換原則を守れていない(ほかのクラスに置き換えたらダメージが期待した値にならないのでダメ)
        nearestCharacter.TakeDamage(damageToDeal);
    }
}
