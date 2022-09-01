using UnityEngine;
using UnityEngine.UI;

namespace gameSaveData{
    public class CallSaveSystem : MonoBehaviour {
        [SerializeField] private GameObject _slotsPanel; 
        [SerializeField] private GameObject _levelPanel;
        
        public void SetActiveLevel(int _activeLevel) 
        {
            SaveSystem.ActiveLevel = _activeLevel;
        }

        public void SetActiveSlot(int _activeSlot) 
        {
            SaveSystem.ActiveSaveSlot = _activeSlot;
        }

        public void CheckSaveSlots () 
        {
            for (int i = 1; i <= 3; i++) {
                if (SaveSystem.LoadGameData(i) != null) {
                    _slotsPanel.transform.Find($"Slot {i}").GetComponent<Image>().color = Color.white;
                    _slotsPanel.transform.Find($"Slot {i}").transform.Find("DeleteButton").GetComponent<Button>().interactable = true;
                } else {
                    _slotsPanel.transform.Find($"Slot {i}").GetComponent<Image>().color = new Color(0.2F, 0.2F, 0.2F, 1);
                    _slotsPanel.transform.Find($"Slot {i}").transform.Find("DeleteButton").GetComponent<Button>().interactable = false;
                }
            }
        }

        public void CheckSaveLevel () 
        {
            GameData _gameData = SaveSystem.LoadGameData(SaveSystem.ActiveSaveSlot);
            if (_gameData != null) {
                for (int i = 1; i <= 3; i++) {
                    _levelPanel.transform.Find($"Level{i}").transform.Find("Button").GetComponent<Button>().interactable = _gameData.level >= i;
                }
            } else {
                for (int i = 1; i <= 3; i++) {
                    _levelPanel.transform.Find($"Level{i}").transform.Find("Button").GetComponent<Button>().interactable = true;
                }
            }
        }

        public void DeleteSlot (int slotToDelete) 
        {
            SaveSystem.DeleteFile(slotToDelete);
        }
    }
}