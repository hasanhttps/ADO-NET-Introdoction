using System;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using ADO.NET_ConnectedMode_Homework.Commands;
using System.Diagnostics.Metrics;

namespace ADO.NET_ConnectedMode_Homework.ViewModels;

public class MainViewModel {

    // Private Fields

    ComboBox authorscb;
    DataGrid booksGrid;
    ComboBox categoriescb;
    SqlConnection connection;
    DataRowView? dataRowView;
    string? _categoryname = null;

    // Properties

    public DataRowView? DataRowView { get => dataRowView;
        set {
            dataRowView = value;
        }
    }
    public ICommand? searchButtonCommand { get; set; }
    public ICommand? deleteButtonCommand { get; set; }
    public ICommand? insertButtonCommand { get; set; }
    public string categoryname { get { return _categoryname!; } 
        set {
            _categoryname = value;
            AuthorsSelectionChanged();
        }
    }

    // Constructor

    public MainViewModel(ComboBox authorscb, ComboBox categoriescb, DataGrid booksGrid) {

        searchButtonCommand = new RelayCommand(SearchButtonClicked);
        deleteButtonCommand = new RelayCommand(DeleteButtonClicked);
        insertButtonCommand = new RelayCommand(InsertButtonClicked);

        string constr = "Data Source=ASUSTUFGAMING\\SQLEXPRESS;Integrated Security=True;Initial Catalog=Library;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        this.categoriescb = categoriescb;
        this.authorscb = authorscb;
        this.booksGrid = booksGrid;

        connection = new SqlConnection(constr);
        ReadCategoriesFromSql(categoriescb);
    }

    // Functions

    public void AuthorsSelectionChanged() {
        authorscb!.Items.Clear();
        ReadAuthorsViaCategoryFromSql();
    }

    public void InsertButtonClicked(object? param) {
        connection?.Open();

        object[]? ItemArray = dataRowView!.Row.ItemArray!;
        string insertQuery = $"INSERT INTO Books (Id, [Name], Pages, YearPress, Id_Themes, Id_Category, Id_Author, Id_Press, Comment, Quantity) VALUES ({ItemArray[0]}, '{ItemArray[1] as string}',  {ItemArray[2]}, {ItemArray[3]}, {ItemArray[4]}, {ItemArray[5]}, {ItemArray[6]}, {ItemArray[7]}, '{ItemArray[8] as string}', {ItemArray[9]})";

        using SqlCommand cmd = new SqlCommand(insertQuery, connection);
        cmd.ExecuteNonQuery();

        connection?.Close();
    }

    public void DeleteButtonClicked(object? param) {
        connection.Open();

        int id = Convert.ToInt32(dataRowView!.Row.ItemArray[0]);
        using SqlCommand command = new($"DELETE FROM Books Where Id = {id}", connection);

        try {
            command.ExecuteNonQuery();  
        }
        catch (Exception ex) {
            try {
                using SqlCommand cmd0 = new($"ALTER TABLE S_Cards DROP Constraint FK_S_Cards_Book; DELETE FROM Books Where Id = {id}", connection);
                cmd0.ExecuteNonQuery();
                using SqlCommand cmd1 = new($"ALTER TABLE T_Cards DROP Constraint FK_T_Cards_Book; DELETE FROM Books Where Id = {id}", connection);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex2) {
                using SqlCommand cmd2 = new($"ALTER TABLE T_Cards DROP Constraint FK_T_Cards_Book; DELETE FROM Books Where Id = {id}", connection);
                cmd2.ExecuteNonQuery();
            }
        }
        dataRowView.Delete();

        connection.Close();
    }

    public void ReadCategoriesFromSql(ComboBox? authorscb = null) {

        try {
            connection!.Open();
            SqlDataReader? reader = null;
            string readData = "SELECT * FROM Categories";

            using SqlCommand cmd = new SqlCommand(readData, connection);

            reader = cmd.ExecuteReader();

            while (reader.Read()) {
                authorscb!.Items.Add(reader["Name"]);
            }
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message, "");
        }
        finally {
            connection!.Close();
        }
    }


    public void SearchButtonClicked(object? param) {
        connection?.Open();

        string? bookName = param as string;

        SqlDataReader? reader = null;
        string query = $"SELECT * FROM Books WHERE [Name] = '{bookName}'";

        using SqlCommand cmd = new(query, connection);
        reader = cmd.ExecuteReader();

        DataTable dataTable = new DataTable("Books");
        dataTable.Columns.Add("Id", typeof(int));
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Pages", typeof(int));
        dataTable.Columns.Add("YearPress", typeof(int));
        dataTable.Columns.Add("Id_Themes", typeof(int));
        dataTable.Columns.Add("Id_Category", typeof(int));
        dataTable.Columns.Add("Id_Author", typeof(int));
        dataTable.Columns.Add("Id_Press", typeof(int));
        dataTable.Columns.Add("Comment", typeof(string));
        dataTable.Columns.Add("Quantity", typeof(int));

        while (reader.Read()) {
            dataTable.Rows.Add(reader["Id"], reader["Name"], reader["Pages"], reader["YearPress"], reader["Id_Themes"], reader["Id_Category"], reader["Id_Author"], reader["Id_Press"], reader["Comment"], reader["Quantity"]);
        }
        reader.Close();

        booksGrid.ItemsSource = dataTable.DefaultView;

        connection?.Close();
    }

    public void ReadAuthorsViaCategoryFromSql() {
        try {
            connection!.Open();

            SqlDataReader? authorIdReader = null, categoryIdReader = null, authorNameReader = null;
            List<string> authorsNameQueries = new();
            string? authorsIdQuery = null;
            string selectedCategoryId = $"SELECT Id FROM Categories WHERE Name = '{categoryname}'";

            using SqlCommand cmdCategoryId = new SqlCommand(selectedCategoryId, connection);
            categoryIdReader = cmdCategoryId.ExecuteReader();

            while (categoryIdReader.Read()) {
                authorsIdQuery = $"SELECT DISTINCT Id_Author FROM Books WHERE Id_Category = {categoryIdReader["Id"]}";
            }
            categoryIdReader.Close();

            using SqlCommand cmdAuthorsId = new SqlCommand(authorsIdQuery, connection);
            authorIdReader = cmdAuthorsId.ExecuteReader();

            while (authorIdReader.Read()) {
                authorsNameQueries.Add($"SELECT FirstName, LastName FROM Authors WHERE Id = {authorIdReader["Id_Author"]}");
            }
            authorIdReader.Close();

            foreach(var authorsNameQuery in authorsNameQueries) {
                using SqlCommand cmdAuthorsName = new SqlCommand(authorsNameQuery, connection);
                authorNameReader = cmdAuthorsName.ExecuteReader();

                while (authorNameReader.Read()) {
                    authorscb!.Items.Add(authorNameReader["FirstName"] + " " + authorNameReader["LastName"]);
                }
                authorNameReader.Close();
            }
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message, "");
        }
        finally {
            connection!.Close();
        }
    }
}
