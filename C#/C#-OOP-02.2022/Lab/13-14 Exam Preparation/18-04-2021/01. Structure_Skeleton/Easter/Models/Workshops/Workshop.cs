﻿using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }
        public void Color(IEgg egg, IBunny bunny)
        {
            if (bunny.Energy >= 0 && bunny.Dyes.Where(x=>x.Power>0).Count()>0)
            {
                while (true)
                {
                    bunny.Work();
                    egg.GetColored();
                    IDye dye = bunny.Dyes.Where(x=>x.Power>0).FirstOrDefault();
                    
                    dye.Use();
                    
                    if (egg.IsDone())
                    {
                        break;
                    }

                    if (bunny.Energy == 0)
                    {
                        break;
                    }

                    if (bunny.Dyes.Where(x => x.Power > 0).Count() == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
