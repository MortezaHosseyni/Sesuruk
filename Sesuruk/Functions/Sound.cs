using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Sesuruk.Functions
{
    public class Sound
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        private const string FilePath = "sounds.json";

        public List<Sound> Load()
        {
            if (!File.Exists(FilePath)) return new List<Sound>();

            var jsonData = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Sound>>(jsonData) ?? new List<Sound>();
        }

        public (bool, string) Add(string name, string location)
        {
            try
            {
                var files = Load();

                var newSound = new Sound
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Location = location
                };

                files.Add(newSound);

                SaveSoundData(files);

                return (true, "Sound added to list successfully.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Delete(Guid id)
        {
            try
            {
                var files = Load();

                var fileToRemove = files.FirstOrDefault(f => f.Id == id);

                if (fileToRemove == null) return (false, "Couldn't find any sound with that ID");

                files.Remove(fileToRemove);
                SaveSoundData(files);

                return (true, "Sound removed from list successfully.");

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private static void SaveSoundData(List<Sound> files)
        {
            var jsonData = JsonConvert.SerializeObject(files, Formatting.Indented);
            File.WriteAllText(FilePath, jsonData);
        }
    }
}
