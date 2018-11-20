using System;
using System.IO;
using UnityEngine;
using SlimeEvolution.Character.Player;

namespace SlimeEvolution.GameSystem
{

    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    public class TestDataManager : MonoBehaviour
    {
        public static TestDataManager Instance { get; private set; }
    


        public const string DirectoryName = "Data";
        public const string FilePath = DirectoryName + "/AssetBundleData.txt";
        public delegate void LoginResult(string Text);
        public LoginResult LoginResultCallback;
        public delegate void SignUpResult(string Text);
        public LoginResult SignUpResultCallback;
        public int playerNumber { get; private set; }

        public GameData GameData { get; private set; }

        GameDataLoader gameDataLoader;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
            GameData = new GameData();
            gameDataLoader = new GameDataLoader();
            playerNumber = 2;
        }

        /// <summary>
        /// 슬롯 선택시 슬롯에 해당하는 번호를 설정함.
        /// </summary>
        /// <param name="playerNumber"></param>
        public void ChoicePlayer(int slotNumber, bool isNewCharacter)
        {
            if (isNewCharacter)
                GameData.PlayerList[slotNumber] = new PlayerData(slotNumber);

            playerNumber = slotNumber;
        }

        public void CreateNewAccount(string id, string password)
        {
            gameDataLoader.MakeNewAccountInDB(id, password);
        }

        public void Login(string id, string password)
        {
            gameDataLoader.LoadLoginDataFromDB(id, password);
        }

        public void SaveGameData(GameData gameData)
        {
            this.GameData = gameData;
        }

        public void SaveGameDataInDB()
        {
            gameDataLoader.SetUpdateInDB(GameData);
        }

        public void ResetData(int slotNum)
        {
            GameData.PlayerList[slotNum] = new PlayerData();
            gameDataLoader.SetUpdateInDB(GameData);
        }

        public void SaveStatData(StatData statData)
        {
            GameData.PlayerList[playerNumber].Stat = statData;
        }

        public void SaveSkillData(SkillData skillData, PlayerForm form)
        {
            GameData.PlayerList[playerNumber].SkillLevels[(int)form] = skillData;
        }

    }

}


