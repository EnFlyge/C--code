using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace gameSaveData{
    public static class SaveSystem {
        private static int _activeLevel;
        private static int _activeSaveSlot;

        public static void SaveGameData () {
            BinaryFormatter _formatter = new BinaryFormatter();
            
            string path = Application.persistentDataPath + $"/SaveSystem{_activeSaveSlot}.save";

            GameData _gameData = LoadGameData(_activeSaveSlot);

            if (_gameData == null || _gameData.level < ActiveLevelForSaving) {
                FileStream stream = new FileStream(path, FileMode.Create);
                GameData _data = new GameData();
                _formatter.Serialize(stream, _data);
                stream.Close();
            }
        }

        public static GameData LoadGameData(int slotToLoad) {
            string path = Application.persistentDataPath + $"/SaveSystem{slotToLoad}.save";
            if (!File.Exists(path))
                return null;
            BinaryFormatter _formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData _data = _formatter.Deserialize(stream) as GameData;
            stream.Close();
            return _data;
        }

        public static void DeleteFile (int slotToDelete) {
            File.Delete(Application.persistentDataPath + $"/SaveSystem{slotToDelete}.save");
        }

        public static int ActiveLevelForSaving {
            get {
                switch (_activeLevel) {
                    case 0:
                        return 1;
                    case 1:
                        return 2;
                    case 2:
                    case 3:
                        return 3;
                    default:
                        return 0;
                }
            }
        }

        public static int ActiveLevel { 
            set { _activeLevel = value; }
            get { return _activeLevel; }
        }

        public static int ActiveSaveSlot {
            set { _activeSaveSlot = value; }
            get { return _activeSaveSlot; }
        }
    }
}