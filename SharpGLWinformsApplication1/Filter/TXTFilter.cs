using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BIMI.PointCloud
{
    /// <summary>
    /// 版权所有: 版权所有(C) 2016，华中科技大学无锡研究院叶片智能制造研究所
    /// 内容摘要: 本类是TXT文件类，包括从TXT文件加载点云数据方法。
    /// 完成日期: 2016年4月20日
    /// 版    本: V1.0
    /// 作    者: 望金山
    /// </summary>
    class TXTFilter
    {
        /// <summary>
        /// 从TXT文件加载点云数据
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Point> LoadFromFile(string fileName)
        {
            List<Point> newListPts = new List<Point>();
            StreamReader SR = File.OpenText(fileName);

            // 分成行字符串
            string[]pointsRead = (SR.ReadToEnd()).Split('\n');

            // 读点
            for (int i = 0; i < pointsRead.Length; i++)
            {
                if (pointsRead[i].Trim() != "")
                {
                    newListPts.Add(new Point(pointsRead[i]));
                }
            }

            SR.Close();
            return newListPts;
        }

        public static List<List<Point>> LoadFromScanFile(string fileName)
        {
            List<List<Point>> newListPts = new List<List<Point>>();
            StreamReader SR = File.OpenText(fileName);

            // 分成行字符串
            //string[] pointsRead = (SR.ReadToEnd()).Split('\n');

            //// 读点
            //for (int i = 0; i < pointsRead.Length; i++)
            //{
            //    if (pointsRead[i].Trim() != "")
            //    {
            //        newListPts[i].Add(new Point(pointsRead[i]));
            //    }
            //}

            List<Point> line = new List<Point>();
            while (!SR.EndOfStream)
            {
                string str = SR.ReadLine().Trim();
                if (str.Contains("Line"))
                {
                    if (line.Count != 0)
                    {
                        newListPts.Add(new List<Point>(line));
                        line.Clear();
                    }
                }
                else
                {
                    if (str != "")
                    {
                        line.Add(new Point(str));
                    }
                }
            }
            //补上最后一条线的数据
            newListPts.Add(line);
            SR.Close();
            return newListPts;
        }

        /// <summary>
        /// 保存点文件
        /// </summary>
        /// <param name="ptsList"></param>
        public static void SavePointList(List<Point> ptsList)
        {
            string[] allPtsStr = new string[ptsList.Count];
            int pointIndex = 0;
            foreach (Point pt in ptsList)
            {
                allPtsStr[pointIndex] = pt.ToString();
                pointIndex++;
            }
            SaveFileDialog openFileDlg = new SaveFileDialog();
            openFileDlg.Filter = "文本文件|*.txt";
            openFileDlg.Title = "选择点保存路径";
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(openFileDlg.FileName, allPtsStr);
            }
        }
    }
}
