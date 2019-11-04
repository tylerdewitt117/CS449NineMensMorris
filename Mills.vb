Public Class Mills

    Private button1Int As Integer = -1
    Private button2Int As Integer = -1
    Private button3Int As Integer = -1


    Public Function isMill(ByRef buttonOne As Button, ByRef buttonTwo As Button, ByRef buttonThree As Button, ByVal buttonIntOne As Integer, ByVal buttonIntTwo As Integer, ByVal buttonIntThree As Integer)
        Dim isAMill As Boolean = False
        'Checks to see if the potential mill buttons are a mill
        If (Buttons.turnColor = "white") Then
            If (buttonOne.BackColor = Color.White AndAlso buttonTwo.BackColor = Color.White AndAlso buttonThree.BackColor = Color.White) Then

                button1Int = buttonIntOne
                button2Int = buttonIntTwo
                button3Int = buttonIntThree
                isAMill = True
            End If
        Else
            If (buttonOne.BackColor = Color.Black AndAlso buttonTwo.BackColor = Color.Black AndAlso buttonThree.BackColor = Color.Black) Then

                button1Int = buttonIntOne
                button2Int = buttonIntTwo
                button3Int = buttonIntThree
                isAMill = True
            End If
        End If
        'All values are -1 if it isn't a mill
        If (isAMill = False) Then
            button1Int = -1
            button2Int = -1
            button3Int = -1
        End If
        Return isAMill
    End Function

    Public Function getButton1Int() As Integer
        Return button1Int
    End Function

    Public Function getButton2Int() As Integer
        Return button2Int
    End Function

    Public Function getButton3Int() As Integer
        Return button3Int
    End Function



    Public Sub setUpMill(ByRef buttonArray() As Button)
        'This also has the object problem, this is where it's been crashing. Trying to find a way to iterate through a Button array without it being a bitch
        Dim inMill As Integer = 0

        'Finds opponent's pieces that are in a mill, enables the ones that are not
        If Buttons.turnColor = "white" Then
            For Each button As Integer In Buttons.blackPiecesArr
                If (Array.IndexOf(Buttons.currentBlackMills, button) > -1) Then
                    inMill += 1
                Else
                    buttonArray(button - 1).Enabled = True
                End If
            Next

            'If all opponent pieces are in a mill, activate all of them
            If (inMill = Buttons.blackPieces) Then
                For Each button As Integer In Buttons.blackPiecesArr
                    buttonArray(button - 1).Enabled = True
                Next
            End If
        Else
            For Each button As Integer In Buttons.whitePiecesArr
                If (Array.IndexOf(Buttons.currentWhiteMills, button) > -1) Then
                    inMill += 1
                Else
                    buttonArray(button - 1).Enabled = True
                End If
            Next
            If (inMill = Buttons.whitePieces) Then
                For Each button As Integer In Buttons.whitePiecesArr
                    buttonArray(button - 1).Enabled = True
                Next
            End If
        End If
    End Sub

    Public Sub tearDownMill(ByRef buttonArray() As Button)
        'Same problem as above, idk how to solve it yet, sorry. But this disables the opponent's pieces
        If Buttons.turnColor = "black" Then
            For Each button As Integer In Buttons.blackPiecesArr
                buttonArray(button - 1).Enabled = False
            Next
        Else
            For Each button As Integer In Buttons.whitePiecesArr
                buttonArray(button - 1).Enabled = False
            Next
        End If
    End Sub
End Class
