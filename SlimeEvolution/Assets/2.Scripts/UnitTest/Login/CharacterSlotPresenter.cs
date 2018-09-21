using SlimeEvolution.GameSystem;
using SlimeEvolution.GlobalVariable;
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

        [Header("PopUp")]
        [SerializeField]
        Text SelectionPopupText;

        int slotNumber;

        public void SetUpCharacterSlot()
        {
            PlayerData[] playerList = DataManager.Instance.GameData.PlayerList;
            for(int i = 0; i< playerList.Length; i ++)
            {
                if (playerList[i].Level == 0)
                    emptySlot[i].SetActive(!emptySlot[i].activeSelf);
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

        public void OnClickedPlayButton()
        {
            DataManager.Instance.ChoicePlayer(slotNumber, false);
            StageManager.Instance.ChangeStage(Stage.TestVillageScene);
            //StageManager.Instance 로 스테이지 변경 요청.
        }

        public void OnClickedCharacterSlotButton(string PopupText)
        {
            SelectionPopupText.text = PopupText;
        }

        public void DisplayCharacterSlot(int index, PlayerData[] playerList)
        {
            emptySlot[index].SetActive(false);
            characterSlotList[index].Slot.SetActive(!emptySlot[index].activeSelf);
            characterSlotList[index].LevelText.text = "LV : " + playerList[index].Level.ToString();
            characterSlotList[index].GoldText.text = "Gold : " + playerList[index].Gold.ToString();
            characterSlotList[index].HpText.text = "HP : " + playerList[index].statData.HealthPoint.ToString();
            characterSlotList[index].MpText.text = "MP : " + playerList[index].statData.ManaPoint.ToString();
            characterSlotList[index].StrText.text = "STR : " + playerList[index].statData.StrikingPower.ToString();
        }    
    }
}