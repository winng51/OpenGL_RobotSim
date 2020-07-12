using System;

namespace BIMI.PointCloud
{
    /// <summary>
    /// 版权所有: 版权所有(C) 2016，华中科技大学无锡研究院叶片智能制造研究所
    /// 内容摘要: 本类是三角片体类，包括输出标准STL(ASCII)格式方法。
    /// 完成日期: 2016年4月20日
    /// 版    本: V1.0
    /// 作    者: 陈巍
    /// 
    /// 修改记录1: 
    /// 修改日期: 2016年6月14日
    /// 版 本 号: V1.1
    /// 修 改 人: 陈巍
    /// 修改内容:Normal 类型修改为Vector3f
    /// </summary>
    public class Triangle
    {
        /// <summary>
        /// 顶点P1
        /// </summary>
        public Point P1 { get; private set; }//自动实现属性，只读

        /// <summary>
        /// 顶点P2
        /// </summary>
        public Point P2 { get; private set; }

        /// <summary>
        /// 顶点P3
        /// </summary>
        public Point P3 { get; private set; }

        /// <summary>
        /// 法线向量
        /// </summary>
        public Vector3f Normal { get; private set; }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        /// <param name="n"></param>
        public Triangle(Point v1, Point v2, Point v3, Vector3f n)
        {
            P1 = v1;
            P2 = v2;
            P3 = v3;
            if (Math.Abs(n.Norm() - 1) < 1e-3)
            {
                Normal = n;
            }
            else
                Normal = new Vector3f(1, 0, 0);
        }

        /// <summary>
        /// 输出标准STL(ASCII)格式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string normalLine = "facet normal " + Normal.ToString() +"\n";
            string outLoopLine="outer loop"+"\n";
            string p1Line = "vertex " + P1.ToXYZString() + "\n";
            string p2Line = "vertex " + P2.ToXYZString() + "\n";
            string p3Line = "vertex " + P3.ToXYZString() + "\n";
            string endLoopLine = "endloop" + "\n";
            string endFacet = "endfacet" + "\n";
            return normalLine + outLoopLine + p1Line + p2Line + p3Line + endLoopLine + endFacet;
        }
    }
}
