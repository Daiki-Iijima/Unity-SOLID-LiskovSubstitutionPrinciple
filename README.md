# リスコフの置換原則

## このリポジトリについて

このリポジトリは、SOLID原則の1つ`リスコフの置換原則(LiskovSubstitutionPrinciple)`について、Unityで実践するためにはどのように実装するのかを例にあげて解説しています。

## リスコフの置換原則の概略

この原則は、`サブタイプのオブジェクトはスーパータイプのオブジェクトの仕様に従わなければならない`と表現されています。

オブジェクト指向的に言い換えると、`子クラスは親クラスのオブジェクトの仕様に従わなければならない`ということになります。

## 例 : 近くにいる敵にダメージを与える

- 親クラス

ゲーム内で存在するキャラクターはすべてこのクラスを継承して作成することで、どのキャラクタークラスであってもダメージを与えることができるようになる

```c#
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    private void Awake() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
    }
}
```

```c#
private void DealDamageToNearestCharacter() {
    //  近くの敵を探し出す
    Character nearestCharacter = FindNearestCharacter();

    //  ベースダメージ
    int damageToDeal = 1;

    //  近くのキャラの種類によってダメージを変更
    if(nearestCharacter is NPC) {
        damageToDeal *= 5;
    }

    //  ダメージを与える
    nearestCharacter.TakeDamage(damageToDeal);
}
```

1. 敵が増えた場合に与えるダメージを変更するときに`nearestCharacter`の分岐処理を増やす必要がある
   - これは、`単一責任原則`違反になります。

```c#
//  近くのキャラの種類によってダメージを変更
if(nearestCharacter is NPC) {
    damageToDeal *= 5;
}else if(nearestCharacter is AAA){
    damageToDeal *= 10;
}else if(nearestCharacter is BBB){
    damageToDeal *= 13;
}else if(nearestCharacter is CCC){
    damageToDeal *= 20;
}

//  ダメージを与える
nearestCharacter.TakeDamage(damageToDeal);
```

原因は、親クラスで実装している`TakeDamage`メソッドが親クラスでのみ実装されているので、汎用的な`引数の値をそのまま減算する処理する`ことしかできなくなっていることにあります。

こうなる原因として、`リスコフの置換原則`を守るためにこのような処理になっています。

よって、誘発的に`単一責任原則`違反をしてしまうコードを書かざるを得なくなっています。

## 改善するにはどうするか

TakeDamageメソッドは、親クラスだけで実装するべきではないということがわかりました。なので、子クラスに、ベースダメージに対しての計算を追加できるように変更する必要があります。

具体的には、`TakeDamageをvirtual`メソッド化して、実装を子クラスでもできるようにします。

```c#
```

## 修正したコード
