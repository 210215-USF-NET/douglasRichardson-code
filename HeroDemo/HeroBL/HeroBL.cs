using System;
using HeroDemoModels;
using System.Collections.Generic;
using HeroDL;

namespace HeroBL
{

    public class HeroBL : IHeroBL
    {
        /// <summary>
        /// business logic
        /// </summary>
        private IHeroRepository repo = new HeroRepoSC();
        public void AddHero(      ){
            //TODO: add bl
            repo.AddHero(newHero);
        }

    }//End of class
}
