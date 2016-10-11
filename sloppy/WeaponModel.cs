using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sloppy
{
    class WeaponModel
    {
        public string label { set; get; }
        public int limit;

        public List<WeaponStatusModel> statusList { set; get; }

        public WeaponModel(List<WeaponStatusModel> inputActions)
        {
            label = "";
            limit = 0;
            statusList = inputActions;
        }

        public WeaponModel(List<WeaponStatusModel> inputActions, string inputLabel) : this(inputActions)
        {
            label = inputLabel;
        }

    }
}
