using SlimeEvolution.Character;
using SlimeEvolution.Character.Player;
using SlimeEvolution.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolution.GameSystem
{
    public class DungeonSystem : MonoBehaviour
    {
        Player player;
        DungeonPresenter dungeonPresenter;

        void Start()
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            dungeonPresenter = GameObject.Find("DungeonUIPresenter").GetComponent<DungeonPresenter>();
            
        }

        public CharacterStat RequestCharacterStat()
        {
            Debug.Log(player.CharacterStat.AttackSpeed);

            return player.CharacterStat;
        }


    }
}