Imports System.Data.SqlClient

Public Class StudentAttendance
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim id As Integer = TxtStudentId.Text
        Dim name As String = TxtStudentName.Text
        Dim rollNo As String = TxtRollNo.Text
        Dim status As String = TxtStatus.Text

        Dim query As String = ("insert into newtab values (@id,@name,@rollNo,@status)")
        Using con As SqlConnection = New SqlConnection("Data Source= DESKTOP-N9UK4PN;Initial Catalog=StudentAttendanceDB;Integrated Security=True;TrustServerCertificate=True")
            Using cnn As SqlCommand = New SqlCommand(query, con)
                cnn.Parameters.AddWithValue("@Id", id)
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
        Using con As SqlConnection = New SqlConnection("Data Source=DESKTOP-N9UK4PN;Initial Catalog=StudentAttendanceDB;Integrated Security=True;TrustServerCertificate=True ")
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

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim id As Integer = TxtStudentId.Text
        Dim name As String = TxtStudentName.Text
        Dim rollNo As String = TxtRollNo.Text
        Dim status As String = TxtStatus.Text

        Dim query As String = ("update newtab set name=@name,rollNo= @rollNo,status=@status where id = @id")
        Using con As SqlConnection = New SqlConnection("Data Source=DESKTOP-N9UK4PN;Initial Catalog=StudentAttendanceDB;Integrated Security=True;TrustServerCertificate=True ")
            con.Open()

            Using cnn As SqlCommand = New SqlCommand(query, con)
                cnn.Parameters.AddWithValue("@Id", id)
                cnn.Parameters.AddWithValue("@Name", name)
                cnn.Parameters.AddWithValue("@RollNo", rollNo)
                cnn.Parameters.AddWithValue("@Status", status)
                cnn.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Record Updated Successfully")
            End Using

        End Using

    End Sub

    Private Sub StudentAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = ("select * from newtab")
        Using con As SqlConnection = New SqlConnection("Data Source=DESKTOP-N9UK4PN;Initial Catalog=StudentAttendanceDB;Integrated Security=True;TrustServerCertificate=True ")
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

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim Id As Integer = TxtStudentId.Text
        Dim query As String = "delete newtab where id=@id"

        Using con As SqlConnection = New SqlConnection("Data Source=DESKTOP-N9UK4PN;Initial Catalog=StudentAttendanceDB;Integrated Security=True;Trust Server Certificate=True ")
            con.Open()

            Using cnn As SqlCommand = New SqlCommand(query, con)
                cnn.Parameters.AddWithValue("@Id", Id)
                cnn.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Record Deleted Successfully")

            End Using

        End Using

    End Sub
End Class
