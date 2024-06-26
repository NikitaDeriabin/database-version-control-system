﻿using System.Text;

namespace DBGuard.ConsoleApp.Models;

public class QueryResultTable
{
    public string[] ColumnNames { get; set; }
    public List<string[]> Rows { get; set; }
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }

    public QueryResultTable(params string[] columnNames)
    {
        ColumnNames = columnNames;
        ColumnCount = ColumnNames.Length;
        Rows = new List<string[]>();
        RowCount = 0;
    }

    public void AddRow(params string[] row)
    {
        Rows.Add(row);
        RowCount++;
    }

    public override string ToString()
    {
        var res = new StringBuilder(string.Join("  |  ", ColumnNames));
        res.Append("\n---");
        foreach (var item in Rows)
        {
            res.AppendLine("\n" + string.Join("  |  ", item));
        }

        return res.ToString();
    }
}
