using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName ="Player Inventory", menuName = "Player Data/Player Inventory")]
public class PlayerDB : ScriptableObject
{
    [SerializeField]
    private int player_gene;
    [SerializeField]
    private List<Sprite> player_clothes_inventory;
    [SerializeField]
    private Sprite player_current_clothes;
    [SerializeField]
    private AudioSource player_current_bgm;
    [SerializeField]
    private float player_bgm_volume;
    [SerializeField]
    private float player_sfx_volume;
    public int GetPlayerGene() { return player_gene; }
    public List<Sprite> GetPlayerClothesInventory() { return player_clothes_inventory; }
    public Sprite GetPlayerCurrentClothes() { return player_current_clothes; }
    public AudioSource GetPlayerCurrentBGM() { return player_current_bgm; }
    public float GetPlayerBGMVolume() { return player_bgm_volume; }
    public float GetPlayerSFXVolume() { return player_sfx_volume; }
    public void SetPlayerCurrentClothes(Sprite s) { player_current_clothes = s; }
    public void SetPlayerCurrentBGM(AudioSource a) { player_current_bgm = a; }
    public void SetPlayerBGMVolume(float f) { player_bgm_volume = f; }
    public void SetPlayerSFXVolume(float f) { player_sfx_volume = f; }

    public void ClosetClear()
    {
        player_clothes_inventory.Distinct().ToList();
    }

}
