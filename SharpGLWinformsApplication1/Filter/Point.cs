using System;

namespace BIMI.PointCloud
{
    /// <summary>
    /// 版权所有: 版权所有(C) 2016，华中科技大学无锡研究院叶片智能制造研究所
    /// 内容摘要: 本类是点云的处理类，包括去噪、精简等点云处理方法。
    /// 完成日期: 2016年4月20日
    /// 版    本: V1.0
    /// 作    者: 望金山
    /// </summary>
    public class Point
    {
        /// <summary>
        /// 点的X坐标
        /// </summary>
        public double X { get;  set; }

        /// <summary>
        /// 点的Y坐标
        /// </summary>
        public double Y { get;  set; }

        /// <summary>
        /// 点的Z坐标
        /// </summary>
        public double Z { get;  set; }

        /// <summary>
        /// 点的法向I分量
        /// </summary>
        public double I { get;  set; }

        /// <summary>
        /// 点的法向J分量
        /// </summary>
        public double J { get;  set; }

        /// <summary>
        /// 点的法向K分量
        /// </summary>
        public double K { get;  set; }

        /// <summary>
        /// 点的误差值
        /// </summary>
        public double E { get;  set; }

        /// <summary>
        /// 默认构造器
        /// </summary>
        public Point()
        {
            X = 0;
            Y = 0;
            Z = 0;
            I = 1;
            J = 0;
            K = 0;
            E = 0;
        }

        /// <summary>
        /// 含参构造器
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
            I = 1;
            J = 0;
            K = 0;
            E = 0;
        }

        /// <summary>
        /// 含参构造器
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            I = 1;
            J = 0;
            K = 0;
            E = 0;
        }

        /// <summary>
        /// 含参构造器
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        public Point(float x, float y, float z, float i, float j, float k)
        {
            X = x;
            Y = y;
            Z = z;
            E = 0;
            float norm = (float)Math.Sqrt(i * i + j * j + k * k);
            if (Math.Abs(norm - 1) < Single.Epsilon)
            {
                I = i;
                J = j;
                K = k;
            }
            else
            {
                I = i / norm;
                J = j / norm;
                K = k / norm;
            }
        }

        /// <summary>
        /// 含参构造器
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        public Point(double x, double y, double z, double i, double j, double k)
        {
            X = x;
            Y = y;
            Z = z;
            E = 0;
            double norm = Math.Sqrt(i * i + j * j + k * k);
            if (Math.Abs(norm - 1) < Single.Epsilon)
            {
                I = i;
                J = j;
                K = k;
            }
            else
            {
                I = i / norm;
                J = j / norm;
                K = k / norm;
            }
        }

        /// <summary>
        /// 含参构造器
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="e"></param>
        public Point(float x, float y, float z, float e)
        {
            X = x;
            Y = y;
            Z = z;
            I = 1;
            J = 0;
            K = 0;
            E = e;
        }

        /// <summary>
        /// 含参构造器
        /// </summary>
        /// <param name="ptsString"></param>
        public Point(string ptsString)
        {
            ptsString = ptsString.Trim();
            string[] ptsStringArray;
            if (ptsString.Contains(","))
            {
                ptsStringArray = ptsString.Split(',');
            }
            else
            {
                ptsStringArray = ptsString.Split(' ');
            }
            Point pt = new Point(ptsStringArray);
            X = pt.X;
            Y = pt.Y;
            Z = pt.Z;
            I = pt.I;
            J = pt.J;
            K = pt.K;
            E = pt.E;
        }

        /// <summary>
        /// 含参构造器
        /// </summary>
        /// <param name="ptsString"></param>
        public Point(string[] ptsStringArray)
        {
            if (ptsStringArray.Length == 3)
            {
                X = Convert.ToSingle(ptsStringArray[0]);
                Y = Convert.ToSingle(ptsStringArray[1]);
                Z = Convert.ToSingle(ptsStringArray[2]);
                I = 1;
                J = 0;
                K = 0;
                E = 0;
            }
            else if (ptsStringArray.Length == 4)
            {
                X = Convert.ToSingle(ptsStringArray[0]);
                Y = Convert.ToSingle(ptsStringArray[1]);
                Z = Convert.ToSingle(ptsStringArray[2]);
                I = 1;
                J = 0;
                K = 0;
                E = Convert.ToSingle(ptsStringArray[3]);
            }
            else if (ptsStringArray.Length == 6)
            {
                Point pt = new Point(Convert.ToSingle(ptsStringArray[0]), Convert.ToSingle(ptsStringArray[1]), Convert.ToSingle(ptsStringArray[2]),
                                     Convert.ToSingle(ptsStringArray[3]), Convert.ToSingle(ptsStringArray[4]), Convert.ToSingle(ptsStringArray[5]));
                X = pt.X;
                Y = pt.Y;
                Z = pt.Z;
                I = pt.I;
                J = pt.J;
                K = pt.K;
                E = 0;
            }
            else if (ptsStringArray.Length == 7)
            {
                Point pt = new Point(Convert.ToSingle(ptsStringArray[0]), Convert.ToSingle(ptsStringArray[1]), Convert.ToSingle(ptsStringArray[2]),
                                     Convert.ToSingle(ptsStringArray[3]), Convert.ToSingle(ptsStringArray[4]), Convert.ToSingle(ptsStringArray[5]));
                X = pt.X;
                Y = pt.Y;
                Z = pt.Z;
                I = pt.I;
                J = pt.J;
                K = pt.K;
                E = Convert.ToSingle(ptsStringArray[6]);
            }
            //else
                //MessageBox.Show("点格式错误！");
        }

        /// <summary>
        /// 计算点的长度
        /// </summary>
        /// <returns></returns>
        public float Norm()
        {
            return (float)Math.Sqrt( X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// 计算三个点构成的向量间的夹角
        /// </summary>
        /// <param name="P1">点</param>
        /// <param name="P2">点</param>
        /// <param name="P3">点</param>
        /// <returns>角度</returns>
        public static double Angle(Point P1, Point P2, Point P3)
        {
            double dot = (P2.X - P1.X) * (P2.X - P3.X) + (P2.Y - P1.Y) * (P2.Y - P3.Y) + (P2.Z - P1.Z) * (P2.Z - P3.Z);
            return Math.Acos(dot / (P2.Distance(P1) * P2.Distance(P3)));
        }

        /// <summary>
        /// 计算该点到另一点的欧氏距离
        /// </summary>
        /// <param name="point">点</param>
        /// <returns></returns>
        public double Distance(Point point)
        {
            return Math.Sqrt((X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y) + (Z - point.Z) * (Z - point.Z));
        }

        /// <summary>
        /// 将点的所有属性转为string输出
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Convert.ToString(X) + "," + Convert.ToString(Y) + "," + Convert.ToString(Z) + "," + Convert.ToString(I) + "," + Convert.ToString(J) + "," + Convert.ToString(K) + "," + Convert.ToString(E);
        }

        /// <summary>
        /// 将点的X、Y、Z属性转为string输出
        /// </summary>
        /// <returns></returns>
        public string ToXYZString()
        {
            return Convert.ToString(X) + "," + Convert.ToString(Y) + "," + Convert.ToString(Z) ;
        }
    }
}
