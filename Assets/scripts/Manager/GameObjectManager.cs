using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        i = this;
    }

    private static GameObjectManager i = null;
    public static GameObjectManager I { get { return i; } }

    private static string myWarriorPath = "Object/MyWarrior.prefab";
    private static string monsterSlimePath = "Monster/MonsterSlime.prefab";
    public MyWarrior SpawnMyWarrior()
    {
        using (AssetLoader loader = new AssetLoader())
        {
            var mychar = loader.LoadAssetInstance<GameObject>(myWarriorPath);
            return mychar.GetComponent<MyWarrior>();
        }
    }

    public MonsterSlime SpawnMonsterSlime()
    {
        using (AssetLoader loader = new AssetLoader())
        {
            var mychar = loader.LoadAssetInstance<GameObject>(monsterSlimePath);
            var monSlime = mychar.GetComponent<MonsterSlime>();

            return monSlime;
        }
    }
}
