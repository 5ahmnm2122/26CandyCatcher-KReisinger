using UnityEngine;

namespace Utility {
    public class Parser
    {
        public static int ParseStringToInt(string id) {
            int ID;
            int.TryParse(id, out ID);
            return ID;
        }

        public static string ParseFloatToString(float value) {
            var rounded = Mathf.Round(value * 100) * 0.01f;
            return rounded.ToString();
        }
    }




}

