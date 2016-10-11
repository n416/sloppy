using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sloppy
{
    public class WeaponStatusModel
    {
        public string name { set; get; }
        public int time { set; get; }
        public string specialText { set; get; }
        public Boolean infinityFlag { set; get; }
        public int endingTime { set; get; }
        public Color forColor { set; get; }

        public void setEndingTime(int alltime)
        {
            endingTime = alltime - time;
        }
        public void setForColor(Color inputColor)
        {
            forColor = inputColor;
        }

        // A
        public WeaponStatusModel()
        {
            name = "";
            time = 0;
            specialText = "";
            infinityFlag = true;
            forColor = Settings.Instance.DumpTextBoxForeColor;
        }
        // A,B
        public WeaponStatusModel(string inputName) : this()
        {
            name = inputName;
        }

        // A,B,X
        public WeaponStatusModel(string inputName, string inputSpecialText) : this(inputName)
        {
            specialText = inputSpecialText;
        }

        // A,B,C
        public WeaponStatusModel(string inputName, Boolean inputinfinityFlag) : this(inputName)
        {
            infinityFlag = inputinfinityFlag;
        }
        // A,B,C,D
        public WeaponStatusModel(string inputName, Boolean inputinfinityFlag, int inputTime) : this(inputName, inputinfinityFlag)
        {
            time = inputTime;
        }
        // A,B,C,D,E
        private WeaponStatusModel(string inputName, Boolean inputinfinityFlag, int inputTime, string inputFormat) : this(inputName, inputinfinityFlag, inputTime)
        {
            specialText = inputFormat;
        }

        // A,B,F
        public WeaponStatusModel(string inputName, int inputTime) : this(inputName)
        {
            time = inputTime;
            infinityFlag = false;
        }
        // A,B,F,G
        public WeaponStatusModel(string inputName, int inputTime, string inputFormat) : this(inputName, inputTime)
        {
            specialText = inputFormat;
        }

        // A
        public WeaponStatusModel(Color inputColor) : this()
        {
            forColor = inputColor;
        }
        // A,B
        public WeaponStatusModel(string inputName, Color inputColor) : this(inputColor)
        {
            name = inputName;
        }

        // A,B,X
        public WeaponStatusModel(string inputName, string inputSpecialText, Color inputColor) : this(inputName, inputColor)
        {
            specialText = inputSpecialText;
        }

        // A,B,C
        public WeaponStatusModel(string inputName, Boolean inputinfinityFlag, Color inputColor) : this(inputName, inputColor)
        {
            infinityFlag = inputinfinityFlag;
        }
        // A,B,C,D
        public WeaponStatusModel(string inputName, Boolean inputinfinityFlag, int inputTime, Color inputColor) : this(inputName, inputinfinityFlag, inputColor)
        {
            time = inputTime;
        }
        // A,B,C,D,E
        private WeaponStatusModel(string inputName, Boolean inputinfinityFlag, int inputTime, string inputFormat, Color inputColor) : this(inputName, inputinfinityFlag, inputTime, inputColor)
        {
            specialText = inputFormat;
        }

        // A,B,F
        public WeaponStatusModel(string inputName, int inputTime, Color inputColor) : this(inputName, inputColor)
        {
            time = inputTime;
            infinityFlag = false;
        }
        // A,B,F,G
        public WeaponStatusModel(string inputName, int inputTime, string inputFormat, Color inputColor) : this(inputName, inputColor)
        {
            specialText = inputFormat;
        }

    }
}
