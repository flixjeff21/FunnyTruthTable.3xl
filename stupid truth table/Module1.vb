Imports System.IO
Imports System.Text

Module Module1
    Sub Main()
        Dim inputLabels() As String = {"A0", "A1", "A2", "B0", "B1", "B2", "C0", "C1", "C2"}
        Dim totalInputs As Integer = inputLabels.Length
        Dim totalRows As Integer = 2 ^ totalInputs
        Dim csvContent As New StringBuilder()
        csvContent.AppendLine(String.Join(",", inputLabels) & ",Q")

        For i As Integer = 0 To totalRows - 1
            Dim binaryString As String = Convert.ToString(i, 2).PadLeft(totalInputs, "0"c)
            Dim inputs(totalInputs - 1) As Integer
            For j As Integer = 0 To totalInputs - 1
                inputs(j) = CInt(binaryString(j).ToString())
            Next
            Dim A() As Integer = {inputs(0), inputs(1), inputs(2)}
            Dim B() As Integer = {inputs(3), inputs(4), inputs(5)}
            Dim C() As Integer = {inputs(6), inputs(7), inputs(8)}
            Dim Z As Integer = If(A.SequenceEqual(B) AndAlso B.SequenceEqual(C), 1, 0)
            csvContent.AppendLine(String.Join(",", inputs) & "," & Z)
        Next

        Dim filePath As String = "truth_table.csv"
        File.WriteAllText(filePath, csvContent.ToString())
        Console.WriteLine("Truth table CSV generated: " & filePath)
        Console.ReadLine()
    End Sub
End Module

