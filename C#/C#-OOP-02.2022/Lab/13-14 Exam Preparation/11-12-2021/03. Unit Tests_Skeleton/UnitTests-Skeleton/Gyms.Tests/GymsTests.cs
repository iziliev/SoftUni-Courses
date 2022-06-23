using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void CheckAthleteIsConstructorSetValue()
        {
            var athlete = new Athlete("Ivo");

            Assert.AreEqual("Ivo", athlete.FullName);
            Assert.IsFalse(athlete.IsInjured);
        }

        [Test]
        public void CheckGymIsConstructorSetValue()
        {
            var gym = new Gym("G1",12);

            Assert.AreEqual("G1", gym.Name);
            Assert.AreEqual(12,gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void CheckGymInvalidNameEmptySpace()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 12));
        }

        [Test]
        public void CheckGymInvalidNameNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 12));
        }

        [Test]
        public void CheckGymInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Gym("D1", -12));
        }
        

        [Test]
        public void CheckGymAddAthlete()
        {
            var gym = new Gym("F1", 4);
            gym.AddAthlete(new Athlete("U1"));
            gym.AddAthlete(new Athlete("U2"));
            gym.AddAthlete(new Athlete("U3"));

            Assert.AreEqual(3, gym.Count);
        }

        [Test]
        public void CheckGymIsFull()
        {
            var gym = new Gym("F1", 2);
            gym.AddAthlete(new Athlete("U1"));
            gym.AddAthlete(new Athlete("U2"));

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("U3")));
        }


        [Test]
        public void CheckGymRemoveAthlete()
        {
            var gym = new Gym("F1", 4);
            gym.AddAthlete(new Athlete("U1"));
            gym.AddAthlete(new Athlete("U2"));
            gym.AddAthlete(new Athlete("U3"));

            gym.RemoveAthlete("U2");

            Assert.AreEqual(2, gym.Count);
            
        }

        [Test]
        public void CheckGymRemoveInvalidAthlete()
        {
            var gym = new Gym("F1", 4);
            gym.AddAthlete(new Athlete("U1"));
            gym.AddAthlete(new Athlete("U2"));
            gym.AddAthlete(new Athlete("U3"));

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("U5"));

        }

        [Test]
        public void CheckGymInjure()
        {
            var gym = new Gym("F1", 4);

            var athlete1 = new Athlete("U1");
            var athlete2 = new Athlete("U2");
            var athlete3 = new Athlete("U3");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            gym.InjureAthlete("U2");
            gym.InjureAthlete("U2");

            Assert.IsTrue(athlete2.IsInjured);
            Assert.AreEqual(3,gym.Count);
        }

        [Test]
        public void CheckGymInjureInvalid()
        {
            var gym = new Gym("F1", 4);
            gym.AddAthlete(new Athlete("U1"));
            gym.AddAthlete(new Athlete("U2"));
            gym.AddAthlete(new Athlete("U3"));

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("U5"));

        }

        [Test]
        public void ChekReport()
        {
            var gym = new Gym("F1", 4);

            var athlete1 = new Athlete("U1");
            var athlete2 = new Athlete("U2");
            var athlete3 = new Athlete("U3");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            gym.InjureAthlete("U2");

            Assert.AreEqual("Active athletes at F1: U1, U3", gym.Report());
            
        }

        [Test]
        public void ChekReport1()
        {
            var gym = new Gym("F1", 4);

            var athlete1 = new Athlete("U1");
            var athlete2 = new Athlete("U2");
            var athlete3 = new Athlete("U3");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            gym.InjureAthlete("U2");
            gym.InjureAthlete("U1");
            gym.InjureAthlete("U3");
            Assert.AreEqual("Active athletes at F1: ", gym.Report());
        }

        [Test]
        public void ChekReport3()
        {
            var gym = new Gym("F1", 4);

            var athlete1 = new Athlete("U1");
            var athlete2 = new Athlete("U2");
            var athlete3 = new Athlete("U3");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);

            gym.InjureAthlete("U2");
            
            Assert.AreEqual(athlete2, gym.InjureAthlete("U2"));
        }
    }
}
