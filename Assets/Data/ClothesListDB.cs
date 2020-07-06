using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clothes List Data", menuName = "Player Data/Clothes List Data")]
public class ClothesListDB : ScriptableObject
{
    [SerializeField]
    private List<Sprite> clothes_listDB;
    [SerializeField]
    private List<bool> clothes_accese;
    public List<Sprite> GetClothesListDB() { return clothes_listDB; }
    public List<bool> GetClothesAccese() { return clothes_accese; }
}
