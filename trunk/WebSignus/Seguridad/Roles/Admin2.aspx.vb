Partial Class admin_admin
    Inherits PaginaComun
    Dim obj As Usuarios = New Usuarios

    Sub PopulateRoleList(ByVal userName As String)

        ' RoleList.Items.Clear()

        Dim roleNames() As String
        Dim roleName As String

        roleNames = Roles.GetAllRoles()

        For Each roleName In roleNames

            Dim roleListItem As New ListItem
            roleListItem.Text = roleName
            roleListItem.Selected = Roles.IsUserInRole(userName, roleName)

            'RoleList.Items.Add(roleListItem)

        Next

    End Sub

    Sub LookupBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LookupBtn.Click
        Dim u As MembershipUser = Membership.GetUser(Me.TxtUserName.Text)
        If Not (u Is Nothing) Then
            PopulateRoleList(TxtUserName.Text)
            obj.GetRecords(TxtUserName.Text)
            Dim objM As New DBMenu
            objM.GetOpcionesPorUser(Me.Tvw, TxtUserName.Text)
            '        Me.MultiView1.ActiveViewIndex = 0
            Me.btnAct.Visible = True
        Else
            Me.btnAct.Visible = False
        End If





    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = "Administración de Roles"
        Me.SetTitulo()
        Me.btnAct.Visible = False
    End Sub


    Protected Sub btnAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAct.Click
        Dim obj As New DBMenu
        obj.AsigPermisosAUser(Me.Tvw, Me.TxtUserName.Text)
    End Sub


End Class

