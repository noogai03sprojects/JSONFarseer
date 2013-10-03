using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace JSONFarseer
{
    static class LevelManager
    {
        static Level CurrentLevel;

        public static void LoadLevel(string path)
        {
            LevelData data;
            string rawData;

            try
            {
                StreamReader reader = new StreamReader(path);

                using (reader)
                {
                    rawData = reader.ReadToEnd();
                }

                data = JsonConvert.DeserializeObject<LevelData>("rawData");

            }
            catch (Exception e)
            {
                //GameRoot
                throw new Exception("An error occured: " + e.Message);
            }

            Art.LoadTileset(data.Tileset);


            CurrentLevel = new Level();
            
        }
    }
}
