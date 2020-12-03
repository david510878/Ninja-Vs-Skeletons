Public Class Form1
    Dim xdir As Integer
    Dim ydir As Integer
    Dim bxdir As Integer
    Dim bydir As Integer
    Dim score As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        MoveTo(PictureBox1, xdir, ydir)
        MoveTo(B1, bxdir, bydir)
        PictureBox2.Location = PictureBox1.Location
    End Sub
    'code AI
    'score
    'game over screen

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode

            Case Keys.W
                MoveTo(PictureBox1, xdir, ydir)
                xdir = 0
                ydir = -10
            Case Keys.S
                MoveTo(PictureBox1, xdir, ydir)
                xdir = 0
                ydir = 10
            Case Keys.A
                MoveTo(PictureBox1, xdir, ydir)
                xdir = -10
                ydir = 0
                PictureBox1.Visible = False
                PictureBox2.Visible = True

            Case Keys.D
                MoveTo(PictureBox1, xdir, ydir)
                xdir = 10
                ydir = 0
                PictureBox1.Visible = True
                PictureBox2.Visible = False

            Case Keys.Space
                B1.Location = PictureBox1.Location
                bxdir = xdir * 5
                bydir = ydir * 5
                B1.Visible = True
        End Select




    End Sub




    'other part



    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(PictureBox1wall.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(p As PictureBox)
        Dim x As Integer
        p = Me.p1win
        p = p2win
        p = p3win
        p = p4win
        If p.Location.X > PictureBox1wall.Location.X Then
            x = -5
        Else
            x = 5
        End If

        MoveTo(p, x, 0)
    End Sub




    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        End If


        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
        score = score + 1
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        Else
            If p.Name = "B1" Then
                p.Visible = False
            End If
        End If
        Dim other As Object = Nothing
        If p.Name = "PictureBox1" And Collision(p, "WIN", other) Then
            Me.BackColor = Color.Black
            other.visible = False
            g1.Visible = True
            L9.Visible = False

            PictureBox1.Visible = False
            PictureBox2.Visible = False
            Return

        End If
    End Sub

End Class
