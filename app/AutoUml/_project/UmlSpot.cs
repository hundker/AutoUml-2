﻿namespace AutoUml
{
    public class UmlSpot : IPlantUmlCodeProvider
    {
        public string   InCircle              { get; set; }
        public UmlColor CircleBackgroundColor { get; set; }
        public string   Text                  { get; set; }

        public string PlantUmlCode
        {
            get
            {
                var result = "";
                var s      = InCircle?.Trim();
                if (!string.IsNullOrEmpty(s))
                {
                    result = s;
                    if (!CircleBackgroundColor.IsEmpty)
                        result += "," + CircleBackgroundColor.PlantUmlCode;
                    result = "(" + result + ")";
                }

                s = Text?.Trim();
                if (!string.IsNullOrEmpty(s))
                {
                    if (!string.IsNullOrEmpty(result))
                        result += " ";
                    result += s;
                }

                if (string.IsNullOrEmpty(result))
                    return "";
                result = "<< " + result + " >>";
                return result;
            }
        }
    }
}