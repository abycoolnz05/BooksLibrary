<%@ Page AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BooksLibrary.Default" Language="C#" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Books</h3> 
        </div>
        <div>
            <asp:GridView ID="gvBooks" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="BooksID" ShowHeaderWhenEmpty="true"
                
                OnRowCommand="gvBooks_RowCommand" OnRowEditing="gvBooks_RowEditing" OnRowCancelingEdit="gvBooks_RowCancelingEdit"
                OnRowUpdating="gvBooks_RowUpdating" OnRowDeleting="gvBooks_RowDeleting">

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

                <Columns>
                    <asp:TemplateField HeaderText="Title">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Title") %>'  runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTitle" Text='<%# Eval("Title") %>'  runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtTitleFooter"  runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Year">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Year") %>'  runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtYear" Text='<%# Eval("Year") %>'  runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtYearFooter"  runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Author">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Author") %>'  runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAuthor" Text='<%# Eval("Author") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAuthorFooter" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Genre">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Genre") %>'  runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGenre" Text='<%# Eval("Genre") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtGenreFooter" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/images/edit-button-128.png" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" runat="server" />
                            <asp:ImageButton ImageUrl="~/images/deletebtn.png" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" runat="server" />
                        </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ImageUrl="~/images/save.png" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" runat="server" />
                                <asp:ImageButton ImageUrl="~/images/cancel.png" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ImageUrl="~/images/add.png" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" runat="server" />
                            </FooterTemplate>                     
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green"/>
             <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red"/>
        </div>
        <br />
        <div>
            <div>
            <h3>Students</h3> 
            </div>
            <asp:GridView ID="gvStudents" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="StudentID" ShowHeaderWhenEmpty="true"
                
                OnRowCommand="gvStudents_RowCommand" OnRowEditing="gvStudents_RowEditing" OnRowCancelingEdit="gvStudents_RowCancelingEdit"
                OnRowUpdating="gvStudents_RowUpdating" OnRowDeleting="gvStudents_RowDeleting">

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

                <Columns>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FirstName") %>'  runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>'  runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFirstNameFooter"  runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("LastName") %>'  runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>'  runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLastNameFooter"  runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contact">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Contact") %>'  runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='<%# Eval("Contact") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtContactFooter" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Email") %>'  runat="server"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %>' runat="server"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtEmailFooter" runat="server"/>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/images/edit-button-128.png" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" runat="server" />
                            <asp:ImageButton ImageUrl="~/images/deletebtn.png" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" runat="server" />
                        </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ImageUrl="~/images/save.png" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" runat="server" />
                                <asp:ImageButton ImageUrl="~/images/cancel.png" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" runat="server" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ImageUrl="~/images/add.png" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" runat="server" />
                            </FooterTemplate>                     
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccess" Text="" runat="server" ForeColor="Green"/>
             <br />
            <asp:Label ID="lblError" Text="" runat="server" ForeColor="Red"/>
        </div>
    </form>
</body>
</html>
