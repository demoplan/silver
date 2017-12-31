using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement.Utils
{
    class MiscUtils
    {
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static bool SavePictureToFile(Image stkImage, string fileDirectory, int fileID)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            try
            {
                if (stkImage == null)
                    return false;

                Bitmap bitmap;
                Image imgThumb;
                int thumbsize = 0;
                int newWidth = 0;
                int newHeight = 0;
                //string.Format("{0}{1}\\{2}.jpg",rootPath,relativePath,model.TID)

                //check for folder
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }
                string fileName = String.Format(@"{0}{1}.jpg", fileDirectory, fileID);
                thumbsize = 50;

                if (stkImage.Height > stkImage.Width)
                {
                    newHeight = Convert.ToInt32(thumbsize);
                    newWidth = Convert.ToInt32(stkImage.Width * thumbsize / stkImage.Height);
                }
                else
                {
                    newWidth = Convert.ToInt32(thumbsize);
                    newHeight = Convert.ToInt32(stkImage.Height * thumbsize / stkImage.Width);
                }

                imgThumb = stkImage.GetThumbnailImage(newWidth, newHeight, null, new IntPtr());
                bitmap = new Bitmap(imgThumb);
                bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                bitmap = null;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + System.Environment.NewLine + ex.StackTrace);
                throw new ArgumentException("Exception Occured : Image Saving Error");
            }
            finally
            {
                ms.Close();
            }
        }

        public static Image LoadImage(string path)
        {
            string imgPath = Application.StartupPath + path;
            Image img = null;
            if (!File.Exists(imgPath))
                return null;
            using (FileStream stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
            {
                img = Image.FromStream(stream);
                stream.Dispose();
            }
            return img;
        }
    }
}
