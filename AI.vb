Public Class AI
    Inherits Gameplay

    Private potentialMill As New Mills
    Private isThirdPhase As Boolean = False

    Public Sub phaseOneMoveAI()
        Dim highestPriorityButton As Integer
        Dim highestPriorityNum As Integer = 0
        Dim i As Integer
        For i = 1 To 24 Step 1
            If (allPiecesDict(i) = "blank") Then
                Dim almostAiMill As Integer = potentialMill.isAlmostMill(i, "ai")
                Dim almostAlmostAiMill As Integer = potentialMill.isAlmostAlmostMill(i, "ai")
                Dim almostPlayerMill As Integer = potentialMill.isAlmostMill(i, "player")
                Dim priority As Integer = (1 * almostPlayerMill) + (0.75 * almostAiMill) + (0.25 * almostAlmostAiMill)
                If (priority >= highestPriorityNum) Then
                    highestPriorityButton = i
                    highestPriorityNum = priority
                End If
            End If
        Next
        Buttons.aiButtons(highestPriorityButton, True)
        addAiPiece()
        potentialMill.aiMillCheck(highestPriorityButton)
    End Sub

    Public Sub phaseTwoMoveAI()
        Dim highestPriorityButton As Integer
        Dim highestPriorityNum As Integer = 0
        Dim i As Integer
        Dim neighbor As Integer
        For i = 1 To 24 Step 1
            If (allPiecesDict(i) = "ai") Then
                For Each num In adjacentElements(i - 1)
                    If (allPiecesDict(num) = "empty") Then
                        Dim almostAiMill As Integer = potentialMill.isAlmostMill(i, "ai")
                        Dim almostAlmostAiMill As Integer = potentialMill.isAlmostAlmostMill(i, "ai")
                        Dim almostPlayerMill As Integer = potentialMill.isAlmostMill(i, "player")
                        Dim priority As Integer = (1 * almostPlayerMill) + (0.85 * almostAiMill) + (0.15 * almostAlmostAiMill)
                        If (priority >= highestPriorityNum) Then
                            highestPriorityButton = i
                            highestPriorityNum = priority
                            neighbor = num
                        End If
                    End If
                Next
            End If
        Next
        Buttons.aiButtons(highestPriorityButton, False)
        Buttons.aiButtons(neighbor, True)
        potentialMill.aiMillCheck(neighbor)
    End Sub

    Public Sub phaseThreeMoveAI()
        Dim highestPriorityButton As Integer
        Dim highestPriorityNum As Integer = 0
        Dim i As Integer
        Dim j As Integer
        Dim moveTo As Integer
        For i = 1 To 24 Step 1
            If (allPiecesDict(i) = "ai") Then
                For j = 1 To 24 Step 1
                    If (allPiecesDict(i) = "empty") Then
                        Dim almostAiMill As Integer = potentialMill.isAlmostMill(i, "ai")
                        Dim almostPlayerMill As Integer = potentialMill.isAlmostMill(i, "player")
                        Dim priority As Integer = (1 * almostPlayerMill) + (0.5 * almostAiMill)
                        If (priority >= highestPriorityNum) Then
                            highestPriorityButton = i
                            highestPriorityNum = priority
                            moveTo = j
                        End If
                    End If
                Next
            End If
        Next
        Buttons.aiButtons(highestPriorityButton, False)
        Buttons.aiButtons(moveTo, True)
        potentialMill.aiMillCheck(moveTo)
    End Sub

    Public Function getThirdPhaseStatus()
        Return isThirdPhase
    End Function

    Public Sub thirdPhaseCheck()
        If (aiPieces <= 3) Then
            isThirdPhase = True
        End If
    End Sub
End Class
