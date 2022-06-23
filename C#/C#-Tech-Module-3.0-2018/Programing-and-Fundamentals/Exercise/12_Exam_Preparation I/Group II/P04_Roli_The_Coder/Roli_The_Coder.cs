using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Roli_The_Coder
{
    class Roli_The_Coder
    {
        static void Main()
        {
            var eventIdToName = new Dictionary<int, string>();
            var eventParticipants = new Dictionary<int, List<string>>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Time for Code")
                {
                    break;
                }

                var commandParts = line
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var eventId = 0;
                if (!int.TryParse(commandParts[0],out eventId))
                {
                    continue;
                }

                var eventName = commandParts[1];
                if (!eventName.StartsWith("#"))
                {
                    continue;
                }

                eventName = eventName.Trim('#');

                var invalidParticipants = false;
                var participants = new List<string>();

                for (int i = 2; i < commandParts.Length; i++)
                {
                    if (!commandParts[i].StartsWith("@"))
                    {
                        invalidParticipants = true;
                        break;
                    }
                    participants.Add(commandParts[i]);
                }

                if (invalidParticipants)
                {
                    continue;
                }

                if (eventIdToName.ContainsKey(eventId))
                {
                    var existingEventName = eventIdToName[eventId];

                    if (existingEventName == eventName)
                    {
                        eventParticipants[eventId].AddRange(participants);
                    }
                }
                else
                {
                    eventIdToName[eventId] = eventName;
                    eventParticipants[eventId] = new List<string>(participants);
                }

            }

            var events = eventParticipants
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => eventIdToName[kvp.Key]);

            foreach (var ev in events)
            {
                var evId = ev.Key;
                var evName = eventIdToName[evId];
                var participants = eventParticipants[evId];
                var sortedParticipants = participants
                    .Distinct()
                    .OrderBy(p => p);

                Console.WriteLine($"{evName} - {sortedParticipants.Count()}");

                foreach (var participient in sortedParticipants)
                {
                    Console.WriteLine(participient);
                }
            }
        }
    }
}
