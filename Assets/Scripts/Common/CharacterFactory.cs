using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory
{
    public static Character CreateCharacter(CharacterDataSO dataSO)
    {
        return new Character(dataSO);
    }
}
