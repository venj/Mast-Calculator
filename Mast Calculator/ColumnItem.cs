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
        public int CommonCapHeight { get; set; } //通用节高
        public int CommonCapJointHeight { get; set; } //通用节缸配合
        public int TopCapHeight { get; set; } //顶节节高
        public int BottomThickness { get; set; } //焊接底厚
        public int BottomJointHeight { get; set; } //焊接配合
        public int SinglePistonHeight { get; set; } //单圈塞高
        public int SinglePistonJointHeight { get; set; } //单圈塞缸配合
        public int DualPistonHeight { get; set; } //双圈塞高
        public int DualPistonJointHeight { get; set; } //双圈塞缸配合
        public int JoinHeight { get; set; } //重合长度
        public int TheoryLoad { get; set; } //理论负载
        public int ColumnHeightLimit { get; set; } //钢套限长
        public int ColumnHeight { get; set; } //缸套长度

        public ColumnItem(List<string> data)
        {
            ItemID = int.Parse(data[0]);
            ColumnID = int.Parse(data[1]);
            PistonID = int.Parse(data[2]);
            CommonCapHeight = int.Parse(data[3]);
            CommonCapJointHeight = int.Parse(data[4]);
            TopCapHeight = int.Parse(data[5]);
            BottomThickness = int.Parse(data[6]);
            BottomJointHeight = int.Parse(data[7]);
            SinglePistonHeight = int.Parse(data[8]);
            SinglePistonJointHeight = int.Parse(data[9]);
            DualPistonHeight = int.Parse(data[10]);
            DualPistonJointHeight = int.Parse(data[11]);
            JoinHeight = int.Parse(data[12]);
            TheoryLoad = int.Parse(data[13]);
            ColumnHeightLimit = (int)(double.Parse(data[14]) * 1000);
        }
    }
}
