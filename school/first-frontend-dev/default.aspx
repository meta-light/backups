<%@ Page Language="C#" Debug="true" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>

<script language="C#" runat="server">
    int SampleGlobalVariable = 0;
    string StudentID = "";
    public void Page_Load(object sender, EventArgs e)
    {
        StudentID = Request["studentid"];
        Response.Write(StudentID);
        // Page Load Code
        //Response.Write(OpenConnection().ToString());

    }

    private void ShowTranscript()
    { //<tr><td>Spring 2000</td><td>ISYS 123</td><td>3</td><td>A</td></tr>

        double GradePoints = 0;
        double TotalHours = 0;

        if (StudentID == "") return;
        DataTable dtGrades = null;

        if (!FillDataTable_ViaSql(ref dtGrades, "SELECT tbl_Terms.Term, tbl_Students.StudentName, tbl_Colleges.College, tbl_Majors.Major, tbl_Courses.Course, tbl_Grades.Grade FROM tbl_Grades INNER JOIN tbl_Courses ON tbl_Grades.Course = tbl_Courses.CourseID INNER JOIN tbl_Students ON tbl_Grades.Student = tbl_Students.StudentID INNER JOIN tbl_Terms ON tbl_Grades.Term = tbl_Terms.TermID INNER JOIN tbl_Colleges ON tbl_Students.StudentCollege = tbl_Colleges.CollegeID INNER JOIN tbl_Majors ON tbl_Students.StudentMajor = tbl_Majors.MajorID WHERE (tbl_Grades.Student = " + StudentID + ") ORDER BY tbl_Terms.Term, tbl_Courses.Course"))
        {
            Response.Write("<tr><td>Database</td><td>Error</td><td></td><td></td></tr");
            return;
        }

        if (dtGrades == null || dtGrades.Rows.Count < 1)
        {
            Response.Write("<tr><td>DataTable</td><td>Error</td><td></td><td></td></tr");
            return;
        }

        foreach (DataRow dr in dtGrades.Rows)
        {
            Response.Write("<tr><td>" + dr["Term"].ToString() + "</td><td>" + dr["Course"].ToString() + "</td><td>3</td><td>" + dr["Grade"].ToString() + "</td></tr>");

            TotalHours = TotalHours + 3;
            if (dr["Grade"].ToString().ToUpper() == "A")
                GradePoints = GradePoints + (3 * 4);
            else if (dr["Grade"].ToString().ToUpper() == "B")
                GradePoints = GradePoints + (3 * 3);
            else if (dr["Grade"].ToString().ToUpper() == "C")
                GradePoints = GradePoints + (3 * 2);
            else if (dr["Grade"].ToString().ToUpper() == "D")
                GradePoints = GradePoints + (3 * 1);
            else if (dr["Grade"].ToString().ToUpper() == "F")
                GradePoints = GradePoints + (3 * 0);
            else
                GradePoints = GradePoints + (3 * 0);
        }

        Response.Write ("<tr><td></td><td></td><td></b>GPA:</td><td>" + (GradePoints/ TotalHours).ToString("F2") + "</td></tr>");
    }


    private void DropDownOptions()
    {
        DataTable dtStudents = null;
        FillDataTable_ViaSql(ref dtStudents, "SELECT StudentID, StudentName FROM tbl_Students Order By StudentName");
        foreach (DataRow dr in dtStudents.Rows)
        {
            Response.Write("<option value='" + dr["StudentID"].ToString() + "'>" + dr["StudentName"].ToString() + "</option>");
        }
    }

    private void SampleMethod()
    {

    }
    // Database Code Below This Line
    // #############################
    private static bool FillDataTable_ViaSql(ref DataTable ReturnTable, string SqlStr)
    {
        SqlCommand SqlCmd = new SqlCommand(SqlStr);
        return FillDataTable_ViaCmd(ref ReturnTable, ref SqlCmd);
    }

    private static bool FillDataTable_ViaCmd(ref DataTable ReturnTable, ref SqlCommand SqlCmd)
    {
        System.Data.SqlClient.SqlDataAdapter lo_Ada = new System.Data.SqlClient.SqlDataAdapter();
        DataTable Return_DataTable = new DataTable();
        SqlConnection ActiveConn;

        if (!OpenConnection())
            return false;
        else
            ActiveConn = lo_Connection;

        SqlCmd.Connection = ActiveConn;
        SqlCmd.CommandTimeout = CommandTimeOutSeconds;

        int Retry = 2;
        while (Retry >= 0)
        {
            try
            {
                lo_Ada.SelectCommand = SqlCmd;
                lo_Ada.Fill(Return_DataTable);
                lo_Ada.Dispose();
                lo_Ada = null;
                ActiveConn.Close();
                ReturnTable = Return_DataTable;
                return true;
            }
            catch (Exception ex)
            {
                if (Retry >= 1 && ex.Message.Contains("deadlock victim"))
                {
                    System.Threading.Thread.Sleep(3337);
                    Retry -= 1;
                }
                else if (Retry >= 1 && (ex.Message.Contains("INSERT EXEC failed ") || ex.Message.Contains("Schema changed ")))
                {
                    System.Threading.Thread.Sleep(3337);
                    Retry -= 1;
                }
                else
                {
                    ActiveConn.Close();
                    Retry = -1;
                }
            }
        }
        return false;
    }

    private static SqlConnection lo_Connection;
    private const int CommandTimeOutSeconds = 1200;

    private static bool OpenConnection()
    {
        int Retry = 2;
        while (Retry >= 0)
        {
            try
            {
                if (lo_Connection == null)
                {
                    lo_Connection = new SqlConnection();
                    lo_Connection.ConnectionString = "Data Source=isys3393.walton.uark.edu;Initial Catalog=3393_Shipp_Fall2022p;user id=nacarpin;password=BizDevPass10900738!;Persist Security Info=False;";
                }

                if (lo_Connection.State == ConnectionState.Closed)
                    lo_Connection.Open();

                return true;
            }
            catch (Exception ex)
            {
                lo_Connection.Dispose();
                lo_Connection = null;
                if (Retry >= 1 && (ex.Message.Contains("Data Provider error 6") || ex.Message.Contains("An existing connection was forcibly closed") || ex.Message.Contains("The specified network name is no longer available") || ex.Message.Contains("The semaphore timeout period has expired") || ex.Message.Contains("The timeout period elapsed prior to completion of the operation")))
                {
                    // short pause before retrying
                    System.Threading.Thread.Sleep(1337);
                    Retry -= 1;
                }
                else if (Retry >= 1 && (ex.Message.Contains("The server was not found or was not accessible")
                                || ex.Message.Contains("Could not open a connection to SQL Server")))
                {
                    // long pause before retrying
                    System.Threading.Thread.Sleep(91337);
                    Retry -= 1;
                }
                else
                    Retry = -1;
            }
        }
        return false;
    }
</script>

<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Hog Country Student Transcripts</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">
    <link href="signin.css" rel="stylesheet">
</head>
<body class="text-center">
    <main class="form-signin w-100 m-auto">
        <form>
            <img class="mb-4 w-100" src="razorback.svg" alt="">

            <select class="form-select" id="studentid" name="studentid" required>
                <option value="">Choose...</option>
                <% DropDownOptions(); %>
            </select>

            <button class="w-100 btn btn-lg btn-primary" type="submit">Show Transcript</button>
        </form>
    </main>
    <table class="table table-striped table-boardered w-100">
        <thead>
            <tr>
                <th>Term</th>
                <th>Course</th>
                <th>Hours</th>
                <th>Grade</th>
            </tr>
        </thead>
        <tbody>
            <% ShowTranscript(); %>
        </tbody>
    </table>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
</body>
</html>
