Public Class AvgUnitsSold

    'Intialize Variables
    Dim day As Integer = 1
    Dim unitsShipped() As Integer = New Integer(6) {}

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Close the form
        Close()
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click

        'Test if the input is a number
        If Integer.TryParse(txtInput.Text, unitsShipped(day - 1)) Then 'Input is a number
            'Test if the input is between 0 and 1000 inclusive
            If unitsShipped(day - 1) >= 0 AndAlso unitsShipped(day - 1) <= 1000 Then 'Input is in range

                'Display the input value on screen
                lblRecord.Text += unitsShipped(day - 1).ToString & vbCrLf

                'increment day by one
                day += 1

                'Test if day is equal to 8
                If day = 8 Then 'Day is equal to 8

                    'Disable enter button and input text box
                    btnEnter.Enabled = False
                    txtInput.Enabled = False

                    'Initialize sum and average variables
                    Dim sum As Integer = 0
                    Dim average As Double = 0

                    'Total the values in the array
                    For i As Integer = 0 To unitsShipped.Length - 1

                        sum += unitsShipped(i)

                    Next

                    'Find the average
                    average = Math.Round(sum / unitsShipped.Length, 2)

                    'Display output
                    lblOutput.Text = "Average Per Day: " & average.ToString

                Else 'Day is not equal to 8
                    'Change display to show current day
                    lblDay.Text = "Day " & day.ToString & ":"
                End If
                'Prepare text box for more values to be entered
                txtInput.Text = ""
                txtInput.Focus()
            Else 'Input is out of range
                'Show error message box
                MessageBox.Show("Please Enter A Number Between 0 and 1000", "Error", MessageBoxButtons.OK)

                'Highlight all text in input box
                txtInput.Focus()
                txtInput.SelectAll()
            End If

        Else 'Input is non-numeric
            'Show error message box
            MessageBox.Show("Please Enter A Whole Number", "Error", MessageBoxButtons.OK)

            'Highlight all text in input box
            txtInput.Focus()
            txtInput.SelectAll()
        End If



    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        'Reset everything to defaults
        txtInput.Text = ""
        day = 1
        lblDay.Text = "Day " & day.ToString & ":"
        lblRecord.Text = ""
        lblOutput.Text = ""
        btnEnter.Enabled = True
        txtInput.Enabled = True
        txtInput.Focus()

        For i As Integer = 0 To unitsShipped.Length - 1

            unitsShipped(i) = 0

        Next
    End Sub
End Class
