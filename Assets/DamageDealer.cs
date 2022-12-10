using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// �_���[�W��^����Ώۂ����肷��
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
    /// �ł��߂��L�����N�^�[�Ƀ_���[�W��^����
    /// </summary>
    private void DealDamageToNearestCharacter() {

        Character nearestCharacter = FindObjectsOfType<Character>()
            .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
            .FirstOrDefault();

        int damageToDeal = 1;

        nearestCharacter.TakeDamage(damageToDeal);
    }
}
