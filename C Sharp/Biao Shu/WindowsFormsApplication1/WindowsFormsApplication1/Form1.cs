using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*xls*)|*.xls*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = fileDialog.FileName;//返回文件的完整路径 
                tb_fileName.Text = path;
                doAnalysisDate(path);
            }
        }

        /// <summary>
        /// 分析excel数据
        /// </summary>
        /// <param name="path">文件路径</param>
        private void doAnalysisDate(String path)
        {
            differGridView.Rows.Clear();
            dataGridView2.Rows.Clear();

            tb_fileName.Text = path;

            IWorkbook workbook = null;  //新建IWorkbook对象
            FileStream fileStream = null;
            try
            {

                fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                if (path.IndexOf(".xlsx") > 0) // 2007版本  
                {
                    workbook = new XSSFWorkbook(fileStream);  //xlsx数据读入workbook  
                }
                else if (path.IndexOf(".xls") > 0) // 2003版本  
                {
                    workbook = new HSSFWorkbook(fileStream);  //xls数据读入workbook  
                }
                differGridView.Rows.Clear();
                dataGridView2.Rows.Clear();

                ISheet sheet = workbook.GetSheetAt(0);  //获取第一个工作表  
                //进行数据过滤
                List<String[]> allItems = getAllItemsList(sheet);
                textBox_totalNum.Text = allItems.Count.ToString();
                doQuery(allItems);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "异常");
            }
            finally
            {
                if (fileStream != null) {
                    fileStream.Close();
                }
                if(workbook != null)
                {
                    workbook.Close();
                }
                
            }
        }

        private List<String[]> getAllItemsList(ISheet sheet)
        {
            //所有牌号对象
            List<String[]> allItems = new List<String[]>();
            //记录牌号数量存异的信息
            //Object[] everyRowNum = new Object[sheet.LastRowNum-3];  //

            IRow row;
            Console.WriteLine("每行个数！");
            //遍历工作表每一行
            for (int i = 4; i <= sheet.LastRowNum; i++)
            {
                try
                {

                    row = sheet.GetRow(i);   //row读入第i行数据  
                    if (row != null)
                    {
                        if (row.GetCell(9) == null) {
                            continue;
                        }
                        string cellValue = row.GetCell(9).ToString();
                        if (string.IsNullOrEmpty(cellValue))
                        {
                            continue;
                        }
                        cellValue = cellValue.Trim();
                        //把当前单元格的牌号拆分到Object[]里面
                        IList<String[]> rowItems = getRowPhList(i + 1, cellValue);
                        //获取牌号数量
                        int phNum = int.Parse(row.GetCell(8).ToString().Trim());

                        //显示不一样的牌号
                        if (phNum != rowItems.Count)
                        {
                            int index = differGridView.Rows.Add();
                            differGridView.Rows[index].Cells[0].Value = i + 1;
                            differGridView.Rows[index].Cells[1].Value = phNum;
                            differGridView.Rows[index].Cells[2].Value = rowItems.Count;
                        }
                        //合并每行数据
                        MergeList(allItems, rowItems);

                    }
                }
                catch
                {
                    throw new Exception("第" + (i + 1) +"行出现数据错误！");
                }
            }
            return allItems;
        }

        /// <summary>
        /// 将每个单元格的数字，通过逗号拆分后放入数组里面
        /// [0]行数，[1]第几个，[2]值
        /// </summary>
        /// <param name="str">牌号单元格的值</param>
        /// <returns></returns>
        private IList<String[]> getRowPhList(int rowNum, String str)
        {
            //先将每行的中文逗号全部替换为英文的
            str = str.Replace("，", ",");
            //然后通过英文逗号拆分
            String[] array = str.Split(',');
            int itemNum = array.GetLength(0);
            //判断最后一个字符是否为空，如果为空则元素个数减一
            String lastItem = array[array.GetLength(0) - 1];
            if (String.IsNullOrEmpty(lastItem))
            {
                itemNum = itemNum - 1;
            }

            //当前行的对象集合
            IList<String[]> rowObjects = new List<String[]>();
            //遍历每个编号，生成一个带位置的对象
            for (int i = 0; i < itemNum; i++)
            {
                if (!String.IsNullOrEmpty(array[i]))
                {
                    getPh(rowObjects, array[i].Trim(), rowNum, i + 1);
                }
            }

            return rowObjects;
        }

        private Object[] MergeObjects(Object[] First, Object[] Second)
        {
            Object[] result = new Object[First.Length + Second.Length];
            First.CopyTo(result, 0);
            Second.CopyTo(result, First.Length);
            return result;
        }

        private void MergeList(IList<String[]> total, IList<String[]> rows)
        {
            foreach (String[] item in rows)
            {
                total.Add(item);
            }
        }

        private void getPh(IList<String[]> rowObjects, String value, int rowNum, int columnNum)
        {
            //检查是否连续编号
            if (value.IndexOf("~") == -1)
            { //非连续编号
                String[] item = new String[3];
                item[0] = value.Trim();   //值
                item[1] = rowNum.ToString(); //行数
                item[2] = columnNum.ToString(); //第几个
                rowObjects.Add(item);
            }
            else
            { //连续编号
                String[] phs = value.Split('~');
                if (phs.Length != 2)
                {
                    throw new Exception("第" + rowNum + "行的连续编号'" + value + "'有误！");
                }

                if (phs[0].Length != phs[1].Length)
                {
                    throw new Exception("第" + rowNum + "行的连续编号'"
                        + value + "'起止号长度不一致！"); ;
                }

                int index = 0; //记录起止号不一样的字符位置，用于生成连续号。
                Char[] c_start = phs[0].ToCharArray();
                Char[] c_end = phs[1].ToCharArray();
                //找出index
                for (int j = 0; j < c_start.Length; j++)
                {
                    if (c_start[j] != c_end[j])
                    {
                        index = j;
                        break;
                    }
                }
                int start = int.Parse(phs[0].Substring(index));
                int end = int.Parse(phs[1].Substring(index));
                String prefix = phs[0].Substring(0, index);

                //从起始编号到结束编号
                for (int i = start; i <= end; i++)
                {
                    String[] item = new String[3];
                    item[0] = prefix + i.ToString();  //值
                    item[1] = rowNum.ToString(); //行数
                    item[2] = columnNum.ToString(); //第几个
                    rowObjects.Add(item);
                }
            }
        }

        private void doQuery(List<String[]> list)
        {
            //遍历每一个牌号对象          
            for (int i = 0; i < list.Count; i++)
            {
                String[] item = list[i];
                //跳过为空的值
                if (item[0] == "")
                {
                    continue;
                }
                String rowNum = ""; //记录行号，用于列表显示
                //和剩余的牌号对象进行比较
                for (int j = i + 1; j < list.Count; j++)
                {
                    String[] itemAfter = list[j];
                    //是否重复
                    if (item[0].Trim() == itemAfter[0].Trim())
                    {
                        rowNum += "," + itemAfter[1] + "行第" + itemAfter[2] + "个"; //行列
                        itemAfter[0] = "";  //把重复的号置空，以后不比较。
                    }
                }
                if (!string.IsNullOrEmpty(rowNum))
                {
                    String currentItem = item[1] + "行第" + item[2] + "个";
                    int index = dataGridView2.Rows.Add();
                    dataGridView2.Rows[index].Cells[0].Value = item[0];
                    dataGridView2.Rows[index].Cells[1].Value = currentItem + rowNum;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doAnalysisDate(tb_fileName.Text);
        }
    }
}
