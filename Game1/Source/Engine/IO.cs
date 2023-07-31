using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameProject
{
    public class IO
    {
        public static void WriteTime(float time)
        {
            File.WriteAllText("../../../../completionTime.txt", time.ToString());
        }

        public static void WriteDefeated(int defeated)
        {
            File.WriteAllText("../../../../enemiesDefeated.txt", defeated.ToString());
        }

        public static float ReadTime()
        {
            var textTime = File.ReadAllText("../../../../completionTime.txt");

            return float.Parse(textTime);
        }

        public static int ReadDefeated()
        {
            var textDefeated = File.ReadAllText("../../../../enemiesDefeated.txt");

            return int.Parse(textDefeated);
        }
    }
}
