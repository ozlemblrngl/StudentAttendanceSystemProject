Imports System.Data.SqlClient

Public Class StudentAttendance
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim studentId As Integer = TxtStudentId.Text
        Dim name As String = TxtStudentName.Text
        Dim rollNo As String = TxtRollNo.Text
        Dim status As String = TxtStatus.Text

        Dim query As String = ("insert into newtab values (@studentID,@name,@rollNo,@status")
        Using con As SqlConnection = New SqlConnection("Data Source= Data Source=DESKTOP-N9UK4PN;Initial Catalog=StudentAttendanceDB;Integrated Security=True;Trust Server Certificate=True")
            Using cnn As SqlCommand = New SqlCommand(query, con)
                cnn.Parameters.AddWithValue("@StudentID", studentId)
                cnn.Parameters.AddWithValue("@Name", name)
                cnn.Parameters.AddWithValue("@RollNo", rollNo)
                cnn.Parameters.AddWithValue("@Status", status)

                con.Open()
                cnn.ExecuteNonQuery()
                con.Close()

                MessageBox.Show("Record Saved Successfully")

            End Using
        End Using



    End Sub

    Private Sub BtnInsert_Click(sender As Object, e As EventArgs) Handles BtnInsert.Click

        Dim query As String = ("select * from newtab")
        Using con As SqlConnection = New SqlConnection("Data Source=Data Source=DESKTOP-N9UK4PN;Initial Catalog=StudentAttendanceDB;Integrated Security=True;Trust Server Certificate=True ")
            Using cnn As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter(cnn)
                    Using table As New DataTable()
                        da.Fill(table)
                        DataGridView1.DataSource = table
                    End Using
                End Using
            End Using

        End Using
    End Sub
End Class
