using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sloppy
{
    class CSVParser
    {
        public static SortedList<string, string> getList(string filePath)
        {
            SortedList<string, string> resultList = new SortedList<string, string>();
            if (!System.IO.File.Exists(filePath))
            {
                // ファイルが無い場合は空のリストを送る
                return resultList;
            }
            try
            {
                using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("utf-8")))
                {
                    sr.ReadLine(); // 最初の一行分(表のヘッダ部分)を飛ばす
                    while (!sr.EndOfStream)
                    {
                        List<string> addData = new List<string>();
                        string line = sr.ReadLine();//一行ずつ読み込む
                        string[] splitData = line.Split('\t');//タブ区切りで分割したものを配列に追加

                        resultList[splitData[0]] = splitData[1];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return resultList;
        }
    }
}
