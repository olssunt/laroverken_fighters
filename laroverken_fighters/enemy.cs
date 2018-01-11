using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laroverken_fighters
{    //En class funkar som en beskrivning av någonting
    //Här beskriver vi hur en fiende fungerar och vilka
    //egenskaper den har
    class Enemy
    {
        public int hp;
        public int dmg;
        public string name;
        //Initiaize, sätt värden på variablerna
        public void Setup()
        {
            Random randomness = new Random();
            hp = randomness.Next(6, 15);
            dmg = randomness.Next(2, 6);

            string[] namesToPick =
            {
                "Christina", //0
                "Dan Nordell", //1
                "Skolverket", //2
                "CSN" //3

            };

            name = namesToPick[randomness.Next(0, namesToPick.Length)];

        }        
    }
}
