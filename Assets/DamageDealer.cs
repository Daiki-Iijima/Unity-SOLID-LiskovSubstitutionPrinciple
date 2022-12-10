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

        nearestCharacter.TakeDamage(damageToDeal);
    }
}
