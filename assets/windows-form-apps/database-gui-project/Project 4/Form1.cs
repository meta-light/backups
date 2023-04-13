using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_4
{
    public partial class Form1 : Form
    {
        DataTable dtColleges = null;
        DataTable dtMajors = null;
        DataTable dtCourses = null;
        DataTable dtTerms = null;
        DataTable dtStudents = null;


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowMainMenu();
            PopulateCollegeDropDown();
            PopulateTermsDropDown();
            PopulateCoursesDropDown();
            PopulateGradeDropDown();
            PopulateMajorsDataTable();
        }
        private void PopulateMajorsDataTable()
        {
            Walton_DB.FillDataTable_ViaSql(ref dtMajors, "SELECT CollegeID, MajorID, Major FROM tbl_Majors");
        }

        private void PopulateGradeDropDown()
        {
            cboGrade.Items.Clear();
            cboGrade.Items.Add("A");
            cboGrade.Items.Add("B");
            cboGrade.Items.Add("C");
            cboGrade.Items.Add("D");
            cboGrade.Items.Add("F");
        }

        private void PopulateCollegeDropDown()
        {
            Walton_DB.FillDataTable_ViaSql(ref dtColleges, "SELECT CollegeID, College FROM tbl_Colleges order by College");
            cboCollege.Items.Clear();
            if (dtColleges != null && dtColleges.Rows.Count > 0)
            {
                foreach (DataRow dr in dtColleges.Rows)
                {
                    cboCollege.Items.Add(dr["College"]);
                }
            }
        }
        private void PopulateTermsDropDown()
        {
            Walton_DB.FillDataTable_ViaSql(ref dtTerms, "SELECT TermID, Term FROM tbl_Terms order by Term");
            cboTerm.Items.Clear();
            if (dtTerms != null && dtTerms.Rows.Count > 0)
            {
                foreach (DataRow dr in dtTerms.Rows)
                {
                    cboTerm.Items.Add(dr["Term"]);
                }
            }
        }
        private void RefreshStudentDropdown()
        {
            Walton_DB.FillDataTable_ViaSql(ref dtStudents, "SELECT StudentID, StudentName FROM tbl_Students order by StudentName");
            cboStudent.Items.Clear();
            if (dtStudents != null && dtStudents.Rows.Count > 0)
            {
                foreach (DataRow dr in dtStudents.Rows)
                {
                    cboStudent.Items.Add(dr["StudentName"]);
                }
            }
        }
        private void PopulateCoursesDropDown()
        {
            Walton_DB.FillDataTable_ViaSql(ref dtCourses, "SELECT CourseID, Course FROM tbl_Courses order by Course");
            cboCourse.Items.Clear();
            if (dtCourses != null && dtCourses.Rows.Count > 0)
            {
                foreach (DataRow dr in dtCourses.Rows)
                {
                    cboCourse.Items.Add(dr["Course"]);
                }
            }
        }






        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowMainMenu()
        {
            pnlMain.Visible = true;
            pnlStudent.Visible = false;
            pnlGrade.Visible = false;
            pnlMain.Dock = DockStyle.Fill;
        }
        private void ShowStudentMenu()
        {
            pnlMain.Visible = false;
            pnlStudent.Visible = true;
            pnlGrade.Visible = false;
            pnlStudent.Dock = DockStyle.Fill;
        }
        private void ShowGradeMenu()
        {
            pnlMain.Visible = false;
            pnlStudent.Visible = false;
            pnlGrade.Visible = true;
            pnlGrade.Dock = DockStyle.Fill;
        }
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMainMenu();
        }
        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStudentMenu();
            RefreshStudentDGV();
        }
        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowGradeMenu();
            RefreshStudentDropdown();
            RefreshGradeDGV();
        }
        private void cboCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCollege.SelectedIndex == -1) return;
            string CollegeID = "";
            CollegeID = dtColleges.Select("College = '" + cboCollege.Text + "'")[0]["CollegeID"].ToString();
            cboMajor.Items.Clear();
            foreach (DataRow dr in dtMajors.Select("CollegeID = '" + CollegeID + "'"))
            {
                cboMajor.Items.Add(dr["Major"].ToString());
            }
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the student name!");
                return;
            }
            if (cboCollege.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a college!");
                return;
            }
            if (cboMajor.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a major!");
                return;
            }
            string CollegeID = "";
            CollegeID = dtColleges.Select("College = '" + cboCollege.Text + "'")[0]["CollegeID"].ToString();
            string MajorID = "";
            MajorID = dtMajors.Select("Major = '" + cboMajor.Text + "'")[0]["MajorID"].ToString();

            if (Walton_DB.ExecSqlString("INSERT INTO tbl_Students (StudentName, StudentCollege, StudentMajor) VALUES ('" + txtName.Text.Trim() + "'," + CollegeID.ToString() + "," + MajorID.ToString() + ")"))
            {
                string Message =
                    "Student Added: " + txtName.Text + System.Environment.NewLine +
                    "Major: " + MajorID + System.Environment.NewLine +
                    "College: " + CollegeID + System.Environment.NewLine;
                MessageBox.Show(Message);
                RefreshStudentDGV();
            }
            else
            {
                MessageBox.Show("Error - Student Not Added!");
            }
            cboCollege.SelectedIndex = -1;
            cboMajor.SelectedIndex = -1;
            txtName.Text = "";
        }
        private void RefreshStudentDGV()
        {
            DataTable dtDGVStudents = null;
            Walton_DB.FillDataTable_ViaSql(ref dtDGVStudents, "SELECT tbl_Students.StudentID, tbl_Students.StudentName, tbl_Colleges.College, tbl_Majors.Major FROM tbl_Students INNER JOIN tbl_Colleges ON tbl_Students.StudentCollege = tbl_Colleges.CollegeID INNER JOIN tbl_Majors ON tbl_Students.StudentMajor = tbl_Majors.MajorID");
            dgvStudents.DataSource = dtDGVStudents;
            dgvStudents.Refresh();
        }

        private void RefreshGradeDGV()
        {
            DataTable dtDGVGrades = null;
            Walton_DB.FillDataTable_ViaSql(ref dtDGVGrades, "SELECT tbl_Students.StudentName, tbl_Courses.Course, tbl_Terms.Term, tbl_Grades.Grade FROM tbl_Grades INNER JOIN tbl_Students ON tbl_Grades.Student = tbl_Students.StudentID INNER JOIN tbl_Courses ON tbl_Grades.Course = tbl_Courses.CourseID INNER JOIN tbl_Terms ON tbl_Grades.Term = tbl_Terms.TermID");
            dgvGrades.DataSource = dtDGVGrades;
            dgvGrades.Refresh();
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            if (cboTerm.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a term!");
                return;
            }
            if (cboStudent.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a student!");
                return;
            }
            if (cboGrade.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a grade!");
                return;
            }
            if (cboCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a course!");
                return;
            }
            string CourseID = dtCourses.Select("Course = '" + cboCourse.Text + "'")[0]["CourseID"].ToString();
            string StudentID = dtStudents.Select("StudentName = '" + cboStudent.Text + "'")[0]["StudentID"].ToString();
            string TermID = dtTerms.Select("Term = '" + cboTerm.Text + "'")[0]["TermID"].ToString();

            if (Walton_DB.ExecSqlString("INSERT INTO tbl_Grades (Student, Course, Term, Grade) VALUES (" + StudentID.ToString() + "," + CourseID.ToString() + "," + TermID.ToString() + ",'" + cboGrade.Text + "')"))
            {
                string Message =
                    "Grade Sucessfully Added" + System.Environment.NewLine + System.Environment.NewLine +
                    "Name: " + cboStudent.Text + System.Environment.NewLine +
                    "Course: " + cboCourse.Text + System.Environment.NewLine +
                    "Term: " + cboTerm.Text + System.Environment.NewLine +
                    "Grade: " + cboGrade.Text;
                MessageBox.Show(Message);
                cboGrade.SelectedIndex = -1;
                cboCourse.SelectedIndex = -1;
                RefreshGradeDGV();
            }
            else
            {
                MessageBox.Show("Error - Grade Not Added");
            }
        }
    }
}
