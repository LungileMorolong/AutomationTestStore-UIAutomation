using ClosedXML.Excel;

namespace AutomationTestStore.Utils
{
    public class ExcelDataReader
    {
        public static string ReadData(string filePath, string sheetName, string cellAddress)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(sheetName);
                    var cell = worksheet.Cell(cellAddress);
                    return cell.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Logs.Info($"Error reading Excel file: {ex.Message}");
                throw;
            }
        }
    }
}
