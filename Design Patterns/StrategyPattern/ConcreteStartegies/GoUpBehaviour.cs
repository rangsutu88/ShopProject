﻿using ShopProject.Design_Patterns.StrategyPattern.StrategyBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopProject.Design_Patterns.StrategyPattern.ConcreteStartegies
{
    public class GoUpBehaviour : IPlayerBehaviour
    {
        public void MoveSlower(ref PictureBox player)
        {
            if(player.Top > 200) player.Top = player.Top - 40;
        }

        public void Move(ref PictureBox player)
        {
            if (player.Top > 200) player.Top = player.Top - 20;
        }
    }
}
