using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mast_Calculator
{
    public class ColumnItem
    {
        public int ItemID { get; set; } //缸套编号
        public int ColumnID { get; set; } //缸套规格
        public int PistonID { get; set; } //活塞规格
        public double CommonCapHeight { get; set; } //通用节高
        public double CommonCapJointHeight { get; set; } //通用节缸配合
        public double TopCapHeight { get; set; } //顶节节高
        public double BottomThickness { get; set; } //焊接底厚
        public double BottomJointHeight { get; set; } //焊接配合
        public double SinglePistonHeight { get; set; } //单圈塞高
        public double SinglePistonJointHeight { get; set; } //单圈塞缸配合
        public double DualPistonHeight { get; set; } //双圈塞高
        public double DualPistonJointHeight { get; set; } //双圈塞缸配合
        public double JoinHeight { get; set; } //重合长度
        public double TheoryLoad { get; set; } //理论负载
        public double ColumnHeightLimit { get; set; } //钢套限长
        public double ColumnHeight { get; set; } //缸套长度

        public ColumnItem(List<string> data)
        {
            ItemID = int.Parse(data[0]);
            ColumnID = int.Parse(data[1]);
            PistonID = int.Parse(data[2]);
            CommonCapHeight = double.Parse(data[3]);
            CommonCapJointHeight = double.Parse(data[4]);
            TopCapHeight = double.Parse(data[5]);
            BottomThickness = double.Parse(data[6]);
            BottomJointHeight = double.Parse(data[7]);
            SinglePistonHeight = double.Parse(data[8]);
            SinglePistonJointHeight = double.Parse(data[9]);
            DualPistonHeight = double.Parse(data[10]);
            DualPistonJointHeight = double.Parse(data[11]);
            JoinHeight = double.Parse(data[12]);
            TheoryLoad = double.Parse(data[13]);
            ColumnHeightLimit = double.Parse(data[14]) * 1000;
        }
    }
}
