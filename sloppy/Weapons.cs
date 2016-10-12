using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace sloppy
{
    // 戦術兵器クラス
    class Weapons
    {
        // 全兵器のリスト
        public static List<WeaponModel> allList = new List<WeaponModel>();

        public static WeaponStatusModel getNextStatus(string WeaponName, WeaponStatusModel currentStatus,int nowTime)
        {
            foreach (WeaponModel weapon in allList)
            {

                if (weapon.label != WeaponName) continue;

                WeaponStatusModel[] statusArray = weapon.statusList.ToArray();

                // 同じステータス名を持つstatusArrayの要素のIndexを取り出す
                var n = weapon.statusList.Select((item, index) => new { Index = index, Value = item })
                        .Where(item => item.Value.name == currentStatus.name)
                        .Select(item => item.Index)
                        .FirstOrDefault();
                // 一つ進める
                n++;
                // 配列の最大を超えていたら0個目をレスポンスとする
                if (n > weapon.statusList.Count - 1) return weapon.statusList[0];

                weapon.statusList[n].setEndingTime(nowTime);
                return weapon.statusList[n];
            }
            // 見つからない場合は自分を返す
            return currentStatus;
        }

        public static WeaponStatusModel getStatus(string inputWeaponLabel,string inputName, int nowTime)
        {
            foreach(WeaponModel wm in allList)
            {
                if (wm.label != inputWeaponLabel) continue;
                foreach (WeaponStatusModel wsm in wm.statusList)
                {
                    if (wsm.name != inputName) continue;
                    wsm.setEndingTime(nowTime);
                    return wsm;
                }
            }
            return null;
        }

        public static void initialize()
        {
            // プリセットステータス
            WeaponStatusModel readyStatus = new WeaponStatusModel("ready", "待機中", Color.Yellow);

            // 索敵
            List<WeaponStatusModel> searchWeaponStatuses = new List<WeaponStatusModel>();
            searchWeaponStatuses.Add(readyStatus);
            searchWeaponStatuses.Add(new WeaponStatusModel("coolTime", 30, Color.Red));
            WeaponModel searchWeapon = new WeaponModel(searchWeaponStatuses, "索敵");

            // ミノフスキー粒子
            List<WeaponStatusModel> minovskyWeaponStatuses = new List<WeaponStatusModel>();
            minovskyWeaponStatuses.Add(readyStatus);
            minovskyWeaponStatuses.Add(new WeaponStatusModel("active", 60));
            minovskyWeaponStatuses.Add(new WeaponStatusModel("coolTime", 90, Color.Red));
            WeaponModel minovskyWeapon = new WeaponModel(minovskyWeaponStatuses, "ﾐﾉﾌｽｷｰ粒子");

            // 補給艦
            List<WeaponStatusModel> supplyVesselWeaponStatuses = new List<WeaponStatusModel>();
            supplyVesselWeaponStatuses.Add(readyStatus);
            supplyVesselWeaponStatuses.Add(new WeaponStatusModel("coolTime", 150, Color.Red));
            WeaponModel supplyVesselWeapon = new WeaponModel(supplyVesselWeaponStatuses, "補給艦");

            // 爆撃
            List<WeaponStatusModel> bombingWeaponStatuses = new List<WeaponStatusModel>();
            bombingWeaponStatuses.Add(readyStatus);
            bombingWeaponStatuses.Add(new WeaponStatusModel("coolTime", 20, Color.Red));
            WeaponModel bombingWeapon = new WeaponModel(bombingWeaponStatuses, "爆撃");

            // 絨毯爆撃
            List<WeaponStatusModel> carpetBombingStatuses = new List<WeaponStatusModel>();
            carpetBombingStatuses.Add(readyStatus);
            carpetBombingStatuses.Add(new WeaponStatusModel("active", 30));
            carpetBombingStatuses.Add(new WeaponStatusModel("coolTime", 40, Color.Red));
            WeaponModel carpetBombingWeapon = new WeaponModel(carpetBombingStatuses, "絨毯爆撃");

            // エース要請
            List<WeaponStatusModel> AceRequestStatuses = new List<WeaponStatusModel>();
            AceRequestStatuses.Add(readyStatus);
            AceRequestStatuses.Add(new WeaponStatusModel("coolTime", 180, Color.Red));
            WeaponModel AceRequestWeapon = new WeaponModel(AceRequestStatuses, "エース要請");

            // 戦略兵器
            List<WeaponStatusModel> strategicArmsStatuses = new List<WeaponStatusModel>();
            strategicArmsStatuses.Add(readyStatus);
            strategicArmsStatuses.Add(new WeaponStatusModel("setup", "範囲設定可能"));
            strategicArmsStatuses.Add(new WeaponStatusModel("preparationTimeSec", 180));
            strategicArmsStatuses.Add(new WeaponStatusModel("resetup", "範囲再設定可能"));
            strategicArmsStatuses.Add(new WeaponStatusModel("active", 11));
            strategicArmsStatuses.Add(new WeaponStatusModel("coolTime", 300, Color.Red));
            WeaponModel strategicArmsWeapon = new WeaponModel(strategicArmsStatuses, "戦略兵器");

            // 試作戦略兵器
            List<WeaponStatusModel> prototypeStrategicArmsStatuses = new List<WeaponStatusModel>();
            prototypeStrategicArmsStatuses.Add(readyStatus);
            prototypeStrategicArmsStatuses.Add(new WeaponStatusModel("coolTime", 120, Color.Red));
            WeaponModel prototypeStrategicArmsWeapon = new WeaponModel(prototypeStrategicArmsStatuses, "試作戦略兵器");

            // 補給艦ビーコン
            List<WeaponStatusModel> supplyVesselBeaconStatuses = new List<WeaponStatusModel>();
            supplyVesselBeaconStatuses.Add(readyStatus);
            supplyVesselBeaconStatuses.Add(new WeaponStatusModel("coolTime", 30, Color.Red));
            WeaponModel supplyVesselBeaconWeapon = new WeaponModel(supplyVesselBeaconStatuses, "補給艦ﾋﾞｰｺﾝ");

            // 戦艦
            List<WeaponStatusModel> battleshipStatuses = new List<WeaponStatusModel>();
            battleshipStatuses.Add(readyStatus);
            battleshipStatuses.Add(new WeaponStatusModel("preparationTimeSec", 120, "戦艦準備中"));
            battleshipStatuses.Add(new WeaponStatusModel("active", "戦艦出撃中",Color.GreenYellow));
            battleshipStatuses.Add(new WeaponStatusModel("coolTime", 180, Color.Red));
            WeaponModel battleshipWeapon = new WeaponModel(battleshipStatuses, "戦艦");

            // サブフライトシステム
            List<WeaponStatusModel> subFlightSystemStatuses = new List<WeaponStatusModel>();
            subFlightSystemStatuses.Add(readyStatus);
            subFlightSystemStatuses.Add(new WeaponStatusModel("coolTime", 150, Color.Red));
            WeaponModel subFlightSystemWeapon = new WeaponModel(subFlightSystemStatuses, "ｻﾌﾞﾌﾗｲﾄｼｽﾃﾑ");

            // 特務エース
            List<WeaponStatusModel> secretMilitarySystemStatuses = new List<WeaponStatusModel>();
            secretMilitarySystemStatuses.Add(readyStatus);
            secretMilitarySystemStatuses.Add(new WeaponStatusModel("coolTime", 60, Color.Red));
            WeaponModel secretMilitarySystemWeapon = new WeaponModel(secretMilitarySystemStatuses, "特務エース");

            allList.Add(searchWeapon);                        // 索敵
            allList.Add(minovskyWeapon);                      // ミノフスキー粒子
            allList.Add(supplyVesselWeapon);                  // 補給艦
            allList.Add(bombingWeapon);                       // 爆撃
            allList.Add(carpetBombingWeapon);                 // 絨毯爆撃
            allList.Add(AceRequestWeapon);                    // エース要請
            allList.Add(strategicArmsWeapon);                 // 戦略兵器
            allList.Add(prototypeStrategicArmsWeapon);        // 試作戦略兵器
            allList.Add(supplyVesselBeaconWeapon);            // 補給艦ビーコン
            allList.Add(battleshipWeapon);                    // 戦艦
            allList.Add(subFlightSystemWeapon);               // サブフライトシステム
            allList.Add(secretMilitarySystemWeapon);          // 特務エース
        }
    }

}
