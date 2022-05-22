using System;
using UnityEngine;
using UnityEngine.Events;


namespace QuestsSystem
{
    public class QuestGetComponent : MonoBehaviour
    {
        [SerializeField] private QuestsOnObject[] _listOfLocalObjectQuests;
        private int _numberOfQuest = 0;

        public void StartQuest()
        {
            int CurrentNumberOfQuests = _listOfLocalObjectQuests.Length;
            if (CurrentNumberOfQuests - 1 >= _numberOfQuest)
            {
                string questName = _listOfLocalObjectQuests[_numberOfQuest].QuestName;
                QuestListComponent questList = _listOfLocalObjectQuests[_numberOfQuest].QuestListComponent;
                Debug.Log($"Quest {questName} was sent");
                questList.ShowQuests(questName);
                _numberOfQuest++;
            }
            else
            {
                Debug.Log("We are already have enough quests");
            }
            
        }
    }

    [Serializable]
    public class QuestsOnObject
    {
        [SerializeField] private string _questName;        
        [SerializeField] private bool _allowNextQuest;
        [SerializeField] private UnityEvent _activateQuestScript;
        [SerializeField] private QuestListComponent _questListComponent;

        public string QuestName => _questName;
        public bool AllowNextQuest => _allowNextQuest;
        public UnityEvent ActivateQuestScript => _activateQuestScript;

        public QuestListComponent QuestListComponent => _questListComponent;
    }
}

