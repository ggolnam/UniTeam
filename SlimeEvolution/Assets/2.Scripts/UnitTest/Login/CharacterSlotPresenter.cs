using SlimeEvolution.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolution.UI
{
    [System.Serializable]
    public struct CharacterSlot
    {
        public GameObject Slot;
        public Text LevelText;
        public Text HpText;
        public Text MpText;
        public Text GoldText;
        public Text StrText;
    }

    public class CharacterSlotPresenter : MonoBehaviour
    {
        [Header("EmptySlot")]
        [SerializeField]
        GameObject[] emptySlot;

        [Header ("CharacterSlot")]
        [SerializeField]
        CharacterSlot[] characterSlotList;

        int slotNumber;

        public void SetUpCharacterSlot()
        {
            PlayerData[] playerList = DataManager.Instance.GameData.PlayerList;
            for(int i = 0; i< playerList.Length; i ++)
            {
                if (playerList[i].Level == 0)
                    emptySlot[i].SetActive(true);
                else
                {
                    DisplayCharacterSlot(i, playerList);
                }
            }
        }

        public void OnClickedEmptySlotButton(int slotNumber)
        {
            this.slotNumber = slotNumber;
        }

        public void OnClickedCreateConfirmationButton()
        {
            DataManager.Instance.ChoicePlayer(slotNumber, true);
            DisplayCharacterSlot(slotNumber, DataManager.Instance.GameData.PlayerList);
            DataManager.Instance.SaveGameDataInDB();
        }
        
        public void OnClickedCharacterSlotButton(int slotNumber)
        {
            DataManager.Instance.ChoicePlayer(slotNumber, false);
        } 

        public void DisplayCharacterSlot(int index, PlayerData[] playerList)
        {
            emptySlot[index].SetActive(false);
            characterSlotList[index].Slot.SetActive(true);
            characterSlotList[index].LevelText.text = "LV : " + playerList[index].Level.ToString();
            characterSlotList[index].GoldText.text = "Gold : " + playerList[index].Gold.ToString();
            characterSlotList[index].HpText.text = "HP : " + playerList[index].statData.HealthPoint.ToString();
            characterSlotList[index].MpText.text = "MP : " + playerList[index].statData.ManaPoint.ToString();
            characterSlotList[index].StrText.text = "STR : " + playerList[index].statData.StrikingPower.ToString();
        }
    }
}