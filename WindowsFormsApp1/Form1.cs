using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Configuration;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvOutput.Visible = false;
            dgvOutput.Rows.Clear();
            buttonTeacher.Enabled = false;
            buttonGroup.Enabled = false;
            //Вырубить нижние строки для преподавателей
            //buttonTeacher.Visible = false;
            //comboTeacherList.Visible = false;
            //labelTeacher.Visible = false;
        }

        //Скачать файл и обновить элементы интерфейса
        private void DownloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                DownloadButton.Enabled = false;
                labelOutput.Text = "Подождите, идёт загрузка и обработка файла";
                WebClient webClient = new WebClient();
                string path = "work.xlsx";
                string downloadlink = "https://drive.google.com/uc?export=download&id=" + ConfigurationManager.AppSettings["DownloadlinkId"];
                webClient.DownloadFile(downloadlink, path);
                labelOutput.Text = "Загрузка завершена";   
            }
            catch
            {
                MessageBox.Show("Возникла проблема с загрузкой файла!");
            }
            finally
            {
                DictionarySerach();
                DownloadButton.Enabled = true;
            }     
        }

        //Поиск разписания занятий определенного преподавателя
        public void SelectTeacher()
        {
            FileInfo ExcTable = new FileInfo("work.xlsx");
            using (ExcelPackage ExcTblJob = new ExcelPackage(ExcTable))
            {
                //Ищем номер ячейки по содержимому
                ExcelWorksheet SelectWorksheet = ExcTblJob.Workbook.Worksheets[comboMonthList.Text];

                string selectTeacher = comboTeacherList.Text;
                //Ищем номер конечной строки и столбца
                int endColumnTable = SelectWorksheet.Cells.Last().End.Column;
                int endRowTable = SelectWorksheet.Cells.Last().End.Row;

                string dateGrid = "";
                string timeGrid = "";
                string groupGrid = "";
                string subjectGrid = "";
                string themeGrid = "";
                string hoursGrid = "2";

                DataGridViewTeacher();
                labelOutput.Text = "Учебный план преподавателя " + selectTeacher + " за учебный период - " + comboMonthList.Text;

                for (int i=3;i<= endRowTable; i++) //EndRowTable
                {
                    for (int j = 3; j <= endColumnTable; j++)  //EndColumnTable
                    {
                        if (SelectWorksheet.Cells[i, j].Text.ToString().IndexOf(selectTeacher) >= 0)
                        {
                            dateGrid = GetCellValueFromPossiblyMergedCell(SelectWorksheet, i, 1);
                            if (dateGrid.IndexOf(" ") > 0)
                            {
                                dateGrid = dateGrid.Remove(0, dateGrid.IndexOf(" "));
                            }
                            timeGrid = GetCellValueFromPossiblyMergedCell(SelectWorksheet, i, 2);
                            groupGrid = SelectWorksheet.Cells[2, j].Text.ToString();
                            subjectGrid = SelectWorksheet.Cells[i + 1, j].Text.ToString();

                            dgvOutput.Rows.Add(dateGrid, timeGrid, groupGrid, subjectGrid, themeGrid, hoursGrid);
                        }   
                    }
                }
            }
        }

        //Поиск расписания занятий для определенной группы
        public void SelectGroup()
        {
            FileInfo ExcTable = new FileInfo("work.xlsx");
            using (ExcelPackage ExcTblJob = new ExcelPackage(ExcTable))
            {
                ExcelWorksheet SelectWorksheet = ExcTblJob.Workbook.Worksheets[comboMonthList.Text];
                int selectGroupColumn = 0;
                
                string selectGroup = comboGroupList.Text.ToString();
                //Ищем номер конечной строки и столбца
                int endColumnTable = SelectWorksheet.Cells.Last().End.Column;
                int endRowTable = SelectWorksheet.Cells.Last().End.Row;
                //Ищем номер колонки для выбранной группы
                for (int i = 1;i<= endColumnTable;i++)
                {
                    if (SelectWorksheet.Cells[2, i].Text.ToString().IndexOf(selectGroup) == 0)
                    {
                        selectGroupColumn = i;
                        break;
                    }
                }

                string dateGrid = "";
                string timeGrid = "";
                string subjectGrid = "";
                string placeGrid = "";
                string teacherGrid = "";

                DataGridViewGroup();
                labelOutput.Text = "Расписание занятий группы " + selectGroup + " за учебный период - " + comboMonthList.Text;

                for (int i=3;i<= endRowTable; i++)
                {
                    if ((SelectWorksheet.Cells[i, selectGroupColumn].Text.ToString().IndexOf(selectGroup.Substring(0,3)) < 0)&(SelectWorksheet.Cells[i, selectGroupColumn].Value!=null))
                    {
                        dateGrid = GetCellValueFromPossiblyMergedCell(SelectWorksheet, i, 1);
                        if (dateGrid.IndexOf(" ")>0)
                        {
                            dateGrid = dateGrid.Remove(0, dateGrid.IndexOf(" "));
                        }
                        timeGrid = GetCellValueFromPossiblyMergedCell(SelectWorksheet, i, 2);
                        subjectGrid = SelectWorksheet.Cells[i + 1, selectGroupColumn].Text.ToString();
                        teacherGrid = SelectWorksheet.Cells[i, selectGroupColumn].Text.ToString();
                        placeGrid = SelectWorksheet.Cells[i + 2, selectGroupColumn].Text.ToString();

                        dgvOutput.Rows.Add(dateGrid, timeGrid, subjectGrid, teacherGrid, placeGrid);
                        i = i + 2;
                    }
                }
            }
        }

        //Поиск данных в объединенных ячейках
        static string GetCellValueFromPossiblyMergedCell(ExcelWorksheet wks, int row, int col)
        {
            var cell = wks.Cells[row, col];
            if (cell.Merge)
            {
                var mergedId = wks.MergedCells[row, col];
                return wks.Cells[mergedId].First().Text.ToString();
            }
            else
            {
                return cell.Text.ToString();
            }
        }

        //Процедура заполнения combobox (список в поле)
        public void DictionarySerach()
        {
            //Заполение элементов для дальнейшего выбора
            Dictionary<int,string> comboSourseMonth = new Dictionary<int,string>();
            Dictionary<int, string> comboSourseTeacher = new Dictionary<int, string>();
            Dictionary<int, string> comboSourseGroup = new Dictionary<int, string>();
            FileInfo ExcTable = new FileInfo("work.xlsx");
            
            using (ExcelPackage ExcTblJob = new ExcelPackage(ExcTable))
            {
                //получаем количество и наименования листов в Excel файле
                int countWorksheet = ExcTblJob.Workbook.Worksheets.Count;
                string workSheetName = "";
                if (countWorksheet>0)
                {
                    for (int i = 0; i <= countWorksheet - 1; i++)
                    {
                        workSheetName = ExcTblJob.Workbook.Worksheets[i].ToString().ToLower();
                        if ((workSheetName.IndexOf("сентябрь") >= 0) | (workSheetName.IndexOf("октябрь") >= 0) | (workSheetName.IndexOf("ноябрь") >= 0) |
                            (workSheetName.IndexOf("декабрь") >= 0) | (workSheetName.IndexOf("январь") >= 0) | (workSheetName.IndexOf("февраль") >= 0) |
                            (workSheetName.IndexOf("март") >= 0) | (workSheetName.IndexOf("апрель") >= 0) | (workSheetName.IndexOf("май") >= 0) |
                            (workSheetName.IndexOf("июнь") >= 0) | (workSheetName.IndexOf("июль") >= 0) | (workSheetName.IndexOf("август") >= 0))
                        {
                            comboSourseMonth.Add(i, workSheetName);
                        }
                    }

                    comboMonthList.DataSource = new BindingSource(comboSourseMonth, null);
                    comboMonthList.DisplayMember = "Value";
                    comboMonthList.ValueMember = "Key";

                    //Достаём список преподавателей и групп из листа ЗАГОТОВКИ
                    ExcelWorksheet CommonWorksheet = ExcTblJob.Workbook.Worksheets["ЗАГОТОВКИ"];
                    var endSheet = CommonWorksheet.Dimension.End.Row;

                    for (int i = 6; i <= endSheet; i++)
                    {
                        if (CommonWorksheet.Cells[i, 6].Value == null)
                        {
                            break;
                        }
                        else
                        {
                            comboSourseTeacher.Add(i, CommonWorksheet.Cells[i, 6].Value.ToString());
                        }
                    }
                    comboTeacherList.DataSource = new BindingSource(comboSourseTeacher, null);
                    comboTeacherList.DisplayMember = "Value";
                    comboTeacherList.ValueMember = "Key";

                    for (int i = 6; i <= endSheet; i++)
                    {
                        if (CommonWorksheet.Cells[i, 7].Value == null)
                        {
                            break;
                        }
                        else
                        {
                            comboSourseGroup.Add(i, CommonWorksheet.Cells[i, 7].Value.ToString());
                        }
                    }
                    comboGroupList.DataSource = new BindingSource(comboSourseGroup, null);
                    comboGroupList.DisplayMember = "Value";
                    comboGroupList.ValueMember = "Key";

                    buttonTeacher.Enabled = true;
                    buttonGroup.Enabled = true;                
                }
                else
                {
                    labelOutput.Text = "Нет файла для обработки";
                }       
            }
        }

        //Формирование таблицы для преподавателя
        public void DataGridViewTeacher()
        {
            //Перед созданием таблицы удаляем предыдущие
            int dvgColumnsCount = dgvOutput.Columns.Count - 1;
            for (int i=0;i<=dvgColumnsCount; i++)
            {
                dgvOutput.Columns.Remove(dgvOutput.Columns[0]);
            }
            //Создание шапки для таблицы преподавателей
            dgvOutput.Columns.Add("Date", "Дата");
            dgvOutput.Columns.Add("Time", "Время занятия");
            dgvOutput.Columns.Add("Group", "Группа");
            dgvOutput.Columns.Add("Subject", "Предмет");
            dgvOutput.Columns.Add("Theme", "Тема занятия");
            dgvOutput.Columns.Add("Hours", "Часы");
        }

        //Формирование таблицы для студента
        public void DataGridViewGroup()
        {
            //Перед созданием таблицы удаляем предыдущие
            int dvgColumnsCount = dgvOutput.Columns.Count - 1;
            for (int i = 0; i <= dvgColumnsCount; i++)
            {
                dgvOutput.Columns.Remove(dgvOutput.Columns[0]);
            }
            //Создание шапки для таблицы групп
            dgvOutput.Columns.Add("Date", "Дата");
            dgvOutput.Columns.Add("Time", "Время занятия");
            dgvOutput.Columns.Add("Subject", "Предмет");
            dgvOutput.Columns.Add("Teacher", "Преподаватель");
            dgvOutput.Columns.Add("PlaceGrid", "Место");

        }

        //Кнопка поиска для преподавателя
        private void buttonTeacher_Click(object sender, EventArgs e)
        {
            SelectTeacher();
            dgvOutput.Visible = true;
        }

        //Кнопка поиска для студента
        private void buttonGroup_Click(object sender, EventArgs e)
        {
            SelectGroup();
            dgvOutput.Visible = true;
        }
    }
}
