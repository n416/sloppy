using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace sloppy
{
    // ログコンテナクラス
    public class logContainer
    {
        public List<string> _timeList = new List<string>();
        public List<string> _ownerList = new List<string>();
        public List<string> _echoList = new List<string>();
        public int _count = 0;

        public logContainer(String source)
        {
            String[] delimiter = { Constants.TranslationLogDelimiter };
            String[] sourceArray = source.Split(delimiter, StringSplitOptions.None); //これで1行づつになる
            foreach (string value in sourceArray)
            {
                Regex regex = new Regex(@"^\[(?<time>\d{2}:\d{2}\.\d{2})\] (?<owner>[^：].*?)：(?<echo>.*)", RegexOptions.Singleline | RegexOptions.ExplicitCapture);
                GroupCollection groups = regex.Match(value).Groups;
                // 時刻
                _timeList.Add(groups["time"].Value);
                // 発言者
                _ownerList.Add(groups["owner"].Value);
                // 発言
                _echoList.Add(groups["echo"].Value);
                // 所有数
                _count++;
            }
            return;
        }
    }
}
