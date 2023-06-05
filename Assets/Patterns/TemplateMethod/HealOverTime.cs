using UnityEngine;

namespace Patterns.TemplateMethod
{
    [CreateAssetMenu(menuName = "TemplateMethod/Create HealOverTime", fileName = "HealOverTime", order = 0)]
    public class HealOverTime : ActiveSkill
    {
        [SerializeField] private float secondsActive;
        [SerializeField] private int healthToAd;

        private float currentTimeInSeconds;
        private bool isActivate;
        private Hero hero;

        protected override void DoUpdate()
        {
            if (!isActivate)
            {
                return;
            }
            
            hero.AddHealth(healthToAd * Time.deltaTime);
            
            currentTimeInSeconds += Time.deltaTime;
            if (currentTimeInSeconds > secondsActive)
            {
                isActivate = false;
            }
        }

        protected override void DoActivate(Hero heroTemp)
        {
            isActivate = true;
            currentTimeInSeconds = 0;
            this.hero = heroTemp;
        }
    }
}
