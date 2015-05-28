using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data;
using System.Data.SqlClient;





namespace StudentGradeManagementSystem
{
    /// <summary>
    /// TeacherControlPage.xaml 的交互逻辑
    /// </summary>


    public partial class TeacherControlPage : Window
    {

        const int Num = 12;


        public TeacherControlPage()
        {
            InitializeComponent();
        }


        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//显示全部数据
        {
            DBcontrolDataContext db = new DBcontrolDataContext();
            var query = from s in db.Student集
                        join c in db.Grade集 on s.studentID equals c.Student_studentID
                        join b in db.Subject集 on c.Subject_subjectID equals b.subjectID
                        orderby s.studentID
                        select new
                        {
                            studentID = s.studentID,
                            studentName = s.studentName,
                            subjectID = b.subjectID,
                            subjectName = b.subjectName,
                            score = c.score,
                            credit = b.credit,
                            subjectType = b.subjectType
                        };

            dataGrid1.ItemsSource = query;

            dataGrid1.CanUserAddRows = true;

            Binding(Num, 1);


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


        }

        List<int> selectFID = new List<int>();  //保存选中要删除行的FID值  

        private void CheckBox_Click(object sender, RoutedEventArgs e)//判断选中的FID
        {
            CheckBox dg = sender as CheckBox;
            int FID = int.Parse(dg.Tag.ToString());   //获取该行的FID  
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectFID.Add(FID);         //如果选中就保存FID  
            }
            else
            {
                selectFID.Remove(FID);  //如果选中取消就删除里面的FID  
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//删除数据
        {
            System.Windows.Forms.MessageBoxButtons messButton = System.Windows.Forms.MessageBoxButtons.OKCancel;
            // MessageBox.Show("Sure to Delete?");
            System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Sure to Delete?", "exit", messButton);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {

                DBcontrolDataContext db = new DBcontrolDataContext();
                foreach (int FID in selectFID)
                {
                    Student集 st = db.Student集.Single(c1 => c1.studentID == FID);
                    Grade集 gd = db.Grade集.Single(c2 => c2.Student_studentID == FID);
                    Subject集 sj = db.Subject集.Single(o => o.subjectID == gd.Subject_subjectID);
                    db.Student集.DeleteOnSubmit(st);
                    db.Grade集.DeleteOnSubmit(gd);
                    db.Subject集.DeleteOnSubmit(sj);
                    db.SubmitChanges();
                }

                var query = from s in db.Student集
                            join c in db.Grade集 on s.studentID equals c.Student_studentID
                            join b in db.Subject集 on c.Subject_subjectID equals b.subjectID
                            orderby s.studentID
                            select new
                            {
                                studentID = s.studentID,
                                studentName = s.studentName,
                                subjectID = b.subjectID,
                                subjectName = b.subjectName,
                                score = c.score,
                                credit = b.credit,
                                SubjectType = b.subjectType

                            };

                dataGrid1.ItemsSource = query;

                dataGrid1.CanUserAddRows = true;
            }
            else
                ;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)//保存数据
        {
          

            //  int.TryParse(StudentID.Text, out i);
         

            if (!((StudentID.Text == "") || (SubjectID.Text == "") || (Credit.Text == "") || (Grade.Text == "") || (StudentName.Text == "") || (SubjectName.Text == "") || (SubjectType.Text == "")))
            {
                
                int studentid = Convert.ToInt32(StudentID.Text.ToString());
                int subjectid = Convert.ToInt32(SubjectID.Text.ToString());
               int credit1 = Convert.ToInt32(Credit.Text.ToString());
               int grade = Convert.ToInt32(Grade.Text.ToString());

           
                DBcontrolDataContext db = new DBcontrolDataContext();

                var st = new Student集() { studentID = studentid, studentName = StudentName.Text.ToString(), password = StudentID.Text.ToString() };
                db.Student集.InsertOnSubmit(st);

                var sb = new Subject集()
                {
                    subjectID = subjectid,
                    subjectName = SubjectName.Text.ToString(),
                    subjectType = SubjectType.Text.ToString(),
                    credit = credit1
                };
                db.Subject集.InsertOnSubmit(sb);
                db.SubmitChanges();

                db.Grade集.InsertOnSubmit(new Grade集() { score = grade, Student_studentID = st.studentID, Subject_subjectID = sb.subjectID });
                db.SubmitChanges();

                DBcontrolDataContext db1 = new DBcontrolDataContext();
                var query = from s in db1.Student集
                            join c in db1.Grade集 on s.studentID equals c.Student_studentID
                            join b in db1.Subject集 on c.Subject_subjectID equals b.subjectID
                            orderby s.studentID
                            select new
                            {
                                studentID = s.studentID,
                                studentName = s.studentName,
                                subjectID = b.subjectID,
                                subjectName = b.subjectName,
                                score = c.score,
                                credit = b.credit,
                                subjectType = b.subjectType

                            };

                dataGrid1.ItemsSource = query;
                dataGrid1.CanUserAddRows = true;

                //因为完成了添加操作 所以设置DataGrid不能自动生成新行了  
                Binding(Num, 1);
            }
            else
                MessageBox.Show("Please Input Data!");
        }

        private void Binding(int number, int currentSize)//分页函数
        {
            DBcontrolDataContext db1 = new DBcontrolDataContext();//获得总的数据个数
            var query = from s in db1.Student集
                        join c in db1.Grade集 on s.studentID equals c.Student_studentID
                        join b in db1.Subject集 on c.Subject_subjectID equals b.subjectID
                        orderby s.studentID
                        select new
                        {
                            studentID = s.studentID,
                            studentName = s.studentName,
                            subjectID = b.subjectID,
                            subjectName = b.subjectName,
                            score = c.score,
                            credit = b.credit,
                            SubjectType = b.subjectType

                        };
            int count = 0;
            foreach (var item in query)
            {
                count++;
            }

            int pageSize = 0;            //pageSize表示总页数  
            if (count % number == 0)
            {
                pageSize = count / number;
            }
            else
            {
                pageSize = count / number + 1;
            }
            tbkTotal.Text = pageSize.ToString();
            var qw = query.ToList();
            tbkCurrentsize.Text = currentSize.ToString();
            qw = qw.Take(number * currentSize).Skip(number * (currentSize - 1)).ToList();   //刷选第currentSize页要显示的记录集  
            dataGrid1.ItemsSource = qw;        //重新绑定dataGrid1  

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)//上一页
        {
            int currentsize = int.Parse(tbkCurrentsize.Text); //获取当前页数  
            if (currentsize > 1)
            {
                Binding(Num, currentsize - 1);   //调用分页方法  
            }

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)//下一页
        {
            int total = int.Parse(tbkTotal.Text); //总页数  
            int currentsize = int.Parse(tbkCurrentsize.Text); //当前页数  
            if (currentsize < total)
            {
                Binding(Num, currentsize + 1);   //调用分页方法  
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Binding(Num, 1);   //调用分页方法  显示第一页  
            dataGrid1.LoadingRow += new EventHandler<DataGridRowEventArgs>(dataGrid_LoadingRow);    //自动添加序号的事件  调用下面的dataGrid_LoadingRow  
        }

        public void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;    //设置行表头的内容值  
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)//人一页跳转
        {
            int pageNum = int.Parse(tbxPageNum.Text);
            int total = int.Parse(tbkTotal.Text); //总页数  
            if (pageNum >= 1 && pageNum <= total)
            {
                Binding(Num, pageNum);     //调用分页方法  
            }
        }


    }
}
