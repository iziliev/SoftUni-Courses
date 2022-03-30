using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {

        }
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }

            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            racerOne.Race();
            racerTwo.Race();

            double canceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience;

            double canceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;

            canceOfWinningOne = racerOne.RacingBehavior == "strict" ? (canceOfWinningOne * 1.2) : (canceOfWinningOne * 1.1);

            canceOfWinningTwo = racerTwo.RacingBehavior == "strict" ? (canceOfWinningTwo * 1.2) : (canceOfWinningTwo * 1.1);

            IRacer winner;

            if (canceOfWinningOne>canceOfWinningTwo)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }
            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
        }
    }
}
