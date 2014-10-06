
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

    Sub UpdateRolesFromList()

        ' Dim roleListItem As ListItem

        'For Each roleListItem In RoleList.Items

        'Dim roleName As String = roleListItem.Value
        'Dim userName As String = TxtUserName.Text
        'Dim enableRole As Boolean = roleListItem.Selected

        'If (enableRole = True) And (Roles.IsUserInRole(userName, roleName) = False) Then
        'Roles.AddUserToRole(userName, roleName)
        ' ElseIf (enableRole = False) And (Roles.IsUserInRole(userName, roleName) = True) Then
        'Roles.RemoveUserFromRole(userName, roleName)
        'End If

        'Next

    End Sub

    Sub LookupBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LookupBtn.Click



        Dim u As MembershipUser = Membership.GetUser(Me.TxtUserName.Text)
        If Not (u Is Nothing) Then

            PopulateRoleList(TxtUserName.Text)
            'UpdateBtn.Visible = True
            obj.GetRecords(TxtUserName.Text)
            Me.GridView1.DataBind()
        End If



    End Sub

    ' Sub UpdateBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateBtn.Click
    'UpdateRolesFromList()
    'PopulateRoleList(TxtUserName.Text)
    'Me.MultiView1.ActiveViewIndex = -1
    'End Sub

    'Protected Sub Crear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Crear.Click
    '  PopulateRoleLista()
    'End Sub
    Public Sub PopulateRoleLista()

        ' ListaRoles.Items.Clear()


        'Dim roleNames() As String
        'Dim roleName As String

        'roleNames = Roles.GetAllRoles()

        'For Each roleName In roleNames

        'Dim roleListItem As New ListItem
        'roleListItem.Text = roleName
        'ListaRoles.Items.Add(roleListItem)

        'Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = "Administración de Roles"
        Me.SetTitulo()
        '       Me.MultiView1.ActiveViewIndex = -1
        Me.btnAct.Visible = False
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        PopulateRoleList(GridView1.SelectedValue)
        Me.TxtUserName.Text = GridView1.SelectedValue
        'UpdateBtn.Visible = True
        Dim obj As New DBMenu
        obj.GetOpcionesPorUser(Me.Tvw, GridView1.SelectedValue)
        '        Me.MultiView1.ActiveViewIndex = 0
        Me.btnAct.Visible = True


    End Sub

    Protected Sub btnAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAct.Click
        Dim obj As New DBMenu
        obj.AsigPermisosAUser(Me.Tvw, GridView1.SelectedValue)
        'Me.MultiView1.ActiveViewIndex = -1
        Me.GridView1.DataBind()
    End Sub


End Class

