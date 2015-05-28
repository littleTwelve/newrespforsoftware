using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSWord = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;

namespace StudentGradeManagementSystem
{
    class WordReport
    {
        public void Report(String discription,String id,String name)
        {
            System.DateTime currentTime = new System.DateTime();//设定系统时间的对象
            currentTime = System.DateTime.Now;
            string currenttime = currentTime.ToString("yyyy-MM-dd");//得到系统当前时间
            object path;//规定存储路径
            string strContent = "                申请报告";
            MSWord.Application wordApp;
            MSWord.Document wordDoc;

            path = @"C:\Users\Administrator\Desktop\申请报告.doc";
            wordApp = new MSWord.ApplicationClass();
            if (File.Exists((string)path))//判断文件是否已存在
            {
                File.Delete((string)path);//存在则删除再新建
            }

            Object Nothing = Missing.Value;
            wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

            wordDoc.Paragraphs.First.Range.Font.Name = "宋体";//对标题的字体类型进行设定
            wordDoc.Paragraphs.First.Range.Font.Bold = 0;//对标题的字体粗细进行设定
            wordDoc.Paragraphs.First.Range.Font.Size = 20;//对标题的字体大小进行设定
            wordApp.Selection.Text = strContent;

            object line = MSWord.WdUnits.wdLine;
            wordApp.Selection.MoveDown(ref line, Nothing, Nothing);
            wordApp.Selection.TypeParagraph();//换行
            MSWord.Range range = wordApp.Selection.Range;
            MSWord.Table table = wordDoc.Tables.Add(range, 3, 1, ref Nothing, ref Nothing);//生成表格7行1列
            table.Borders.Enable = 1;//设定表格边框
            table.Range.Font.Size = 12;//设定表格内的字体大小
            table.Range.Font.Bold = 0;//设置表格内字体的粗细
            table.Rows[1].Height = 20f;//表格内每一行的宽度
            table.Rows[2].Height = 20f;
            table.Rows[3].Height = 500f;

            table.Cell(1, 1).Range.Text = " 申请人  "+name;
            table.Cell(2, 1).Range.Text = " 学号    "+id;
            table.Cell(3, 1).Range.Text = " 申请原因" + '\n' + '\n' + discription;
            wordDoc.Paragraphs.Last.Range.Font.Name = "宋体";//对结尾的字体类型进行设定
            wordDoc.Paragraphs.Last.Range.Font.Bold = 0;//对结尾的字体粗细进行设定
            wordDoc.Paragraphs.Last.Range.Font.Size = 11;//对结尾的字体大小进行设定
            range = wordApp.Selection.Range;

            strContent = "                                                申请日期: " + currenttime;
            wordDoc.Paragraphs.Last.Range.Text = strContent;

            object format = MSWord.WdSaveFormat.wdFormatDocumentDefault;
            wordDoc.SaveAs(ref path, ref format, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            wordDoc.Close(ref Nothing, ref Nothing, ref Nothing);//关闭word
            wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);//退出word

        }
    }
}
