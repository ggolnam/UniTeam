using System;
using System.IO;
using UnityEngine;
using SlimeEvolution.Character.Player;

namespace SlimeEvolution.GameSystem
{
    
    /// <summary>
    /// 작성자 : 박준명
    /// </summary>
    public class DataManager : Singleton<DataManager>
    {
        public const string DirectoryName = "Data";
        public const string FilePath = DirectoryName + "/AssetBundleData.txt";
        public delegate void LoginResult(string Text);
        public LoginResult LoginResultCallback;
        public delegate void SignUpResult(string Text);
        public LoginResult SignUpResultCallback;


        GameData gameData;
        int playerNumber;
        public GameData GameData
        {
            get { return gameData; }
        }

        GameDataLoader gameDataLoader;

        void Start()
        {
            gameData = new GameData();
            gameDataLoader = new GameDataLoader();
        }

        /// <summary>
        /// 슬롯 선택시 슬롯에 해당하는 번호를 설정함.
        /// </summary>
        /// <param name="playerNumber"></param>
        public void ChoicePlayer(int slotNumber, bool isNewCharacter)
        {
            if(isNewCharacter)
                gameData.PlayerList[slotNumber] = new PlayerData(slotNumber);

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
            this.gameData = gameData;
        }

        public void SaveGameDataInDB()
        {
            gameDataLoader.SetUpdateInDB(gameData);
        }

        public void ResetData(int slotNum)
        {
            gameData.PlayerList[slotNum] = new PlayerData();
            gameDataLoader.SetUpdateInDB(gameData);
        }

        public void SaveStatData(StatData statData)
        {
            gameData.PlayerList[playerNumber].Stat = statData;
        }

        public void SaveSkillData(SkillData skillData, PlayerForm form)
        {
            gameData.PlayerList[playerNumber].SkillLevels[(int)form] = skillData;
        }


        /// <summary>
        /// AssetBundle의 키 값을 비교하여 업데이트 유무를 Bool형식으로 리턴함.(사용자는 꼭 Enum순서대로 함수를 사용할것. 
        /// ex) Player -> Skill(o) , Player -> Enemy(x))
        /// </summary>
        /// <param name="bundleNumbers"></param>
        /// <param name="assetBundleData"></param>
        /// <returns></returns>
        //public bool CheckedBundleVersion(AssetBundleNumbers bundleNumbers, string assetBundleData)
        //{
        //    if (!Directory.Exists(DirectoryName))
        //    {
        //        Directory.CreateDirectory(DirectoryName);
        //        LogManager.Instance.UserDebug(LogColor.Magenta, GetType().Name, "AssetBundle을 위한 Data폴더 생성");
        //    }

        //    FileInfo fileInfo = new FileInfo(FilePath);
        //    if(!fileInfo.Exists)
        //    {
        //        File.Create(FilePath).Dispose();
        //    }
        //    string[] lines;
        //    lines = File.ReadAllLines(FilePath);
        //    if (lines.Length - 1 < (int)bundleNumbers)
        //    {
        //        using (StreamWriter writer = new StreamWriter(FilePath, true))
        //        {
        //            writer.WriteLine(assetBundleData);
        //            LogManager.Instance.UserDebug(LogColor.Magenta, GetType().Name, "기록된 정보가 없음. 새로 입력.");   
        //        }
        //    return false;
        //    }
        //    else if (!lines[(int)bundleNumbers].Equals(assetBundleData))
        //    {
        //        using (StreamWriter writer = new StreamWriter(FilePath, false))
        //        {
        //            lines[(int)bundleNumbers] = assetBundleData;
        //            for (int i = 0; i < lines.Length; i++)
        //                writer.WriteLine(lines[i]);
        //            LogManager.Instance.UserDebug(LogColor.Magenta, GetType().Name, "기록된 정보와 불일치. 업데이트 필요.");
        //        }
        //    return false;
        //    }
        //    LogManager.Instance.UserDebug(LogColor.Magenta, GetType().Name, "기록된 정보와 일치. 업데이트 필요없음");
        //    return true;
        //}

        //[Serializable]
        //public struct AssetBundleData
        //{
        //    public string Player;
        //    public string Skill;
        //    public string Enemey;
        //    public string FirstBoss;
        //    public string SecondBoss;
        //    public string ThirdBoss;
        //    public string UI;
        //    public string Tile;
        //}
    }

}


