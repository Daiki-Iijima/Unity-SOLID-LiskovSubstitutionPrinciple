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

        //  ��肠�� : NPC�^�Ɉˑ�����`�ɂȂ��Ă���
        //  ��ԋ߂��̂�NPC�̏ꍇ
        if(nearestCharacter is NPC) {
            damageToDeal *= 5;
        }

        //  ��肠�� : �_���[�W���ꗥ�ł͂Ȃ��̂ł���΁ATakeDamage�ɓn���l��ς���K�v���o�Ă���
        //  = ���X�R�t�̒u�����������Ă��Ȃ�(�ق��̃N���X�ɒu����������_���[�W�����҂����l�ɂȂ�Ȃ��̂Ń_��)
        nearestCharacter.TakeDamage(damageToDeal);
    }
}
