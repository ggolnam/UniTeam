using SlimeEvolution.Character;
using SlimeEvolution.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolution.UI
{
    public class DungeonPresenter : MonoBehaviour
    {
        [SerializeField]
        Image frontAttackImage;
        [SerializeField]
        Button attackButton;
        DungeonSystem dungeonSystem;
        CharacterStat characterStat;


        // Use this for initialization
        void Start()
        {
            dungeonSystem = GameObject.Find("DungeonSystem").GetComponent<DungeonSystem>();
            characterStat = dungeonSystem.RequestCharacterStat();
        }

        public void OnClickedAttackButton()
        {
            StartCoroutine(AttackCooltimeDisplay());
            Debug.Log("Test");
        }

        public IEnumerator AttackCooltimeDisplay()
        {
            Debug.Log(characterStat.AttackSpeed);
            float lefttime = characterStat.AttackSpeed;
            frontAttackImage.gameObject.SetActive(true);
            attackButton.enabled = false;
            while(frontAttackImage.fillAmount > 0)
            {
                if (lefttime > 0)
                {
                    lefttime -= Time.deltaTime;
                    if (lefttime < 0)
                    {
                        lefttime = 0;
                        attackButton.enabled = true;
                    }
                    float ratio = (lefttime / characterStat.AttackSpeed);
                    frontAttackImage.fillAmount = ratio;
                }
                
                if (lefttime < 0)
                    break;
                yield return null;
            }
            frontAttackImage.gameObject.SetActive(false);
            frontAttackImage.fillAmount = 1;
            Debug.Log("Test3");
            yield return null;
        }


    }
}
