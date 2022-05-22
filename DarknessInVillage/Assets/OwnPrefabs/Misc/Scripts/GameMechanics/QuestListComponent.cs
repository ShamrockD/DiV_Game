using UnityEngine;
using System.Collections.Generic;


namespace QuestsSystem
{
    public class QuestListComponent : MonoBehaviour
    {
        [SerializeField] private List <string> _listOfQuests;
        private int _allQuestCounter = 0;
        


        public void ShowQuests(string questName)
        {
            int lenghtOfQuestList = _listOfQuests.Count;
            //Debug.Log(lenghtOfQuestList);
            if (questName != null && !_listOfQuests.Contains(questName))
            {
                _listOfQuests.Add(questName);
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

