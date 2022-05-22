using UnityEngine;
using System.Collections.Generic;
using TMPro;


namespace QuestsSystem
{
    public class QuestListComponent : MonoBehaviour
    {
        [SerializeField] private List <string> _listOfQuests;

        public TextMeshProUGUI textComponent;

        private int _allQuestCounter = 0;

        public void ShowQuests(string questName)
        {
            int lenghtOfQuestList = _listOfQuests.Count;
            if (questName != null && !_listOfQuests.Contains(questName))
            {
                _listOfQuests.Add(questName);
                textComponent.text += (questName + "\n");
                Debug.Log($"Quest {questName} accepted");
                _allQuestCounter++;
            }

            else
            {
                Debug.Log("This quest already in list");
            }
        }
    }
}

