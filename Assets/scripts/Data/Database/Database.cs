using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : SingleMono<Database> {

    CharacterBaseCollection characterDatas;

    private void Awake()
    {
        characterDatas = new CharacterBaseCollection();
        
    }

    public CharacterBase GetCharacter(int index)
    {
        return characterDatas.Get(index);
    }
}
