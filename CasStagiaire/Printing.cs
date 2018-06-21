using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using classesMetierStagiaires;

namespace CasStagiaire
{
/*
    public class MyPageHeader : PdfPageEventHelper
    {

        PdfPTable header = new PdfPTable(2);
        header.HorizontalAlignment = Element.ALIGN_LEFT;
 header.TotalWidth = doc.PageSize.Width - 20f;
 header.LockedWidth = true;
 Phrase cell1 = new Phrase(signal.ProformaType);
        Phrase cell2 = new Phrase("text" + Environment.NewLine + "text"
            + Environment.NewLine + signal.Signal);

        PdfPCell c1 = new PdfPCell(cell1);
        c1.Border = iTextSharp.text.Rectangle.NO_BORDER;
 c1.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
 c1.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
 header.AddCell(c1);

 PdfPCell c2 = new PdfPCell(cell2);
        c2.Border = iTextSharp.text.Rectangle.NO_BORDER;
 c2.VerticalAlignment = iTextSharp.text.Element.ALIGN_TOP;
 c2.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;             
 header.AddCell(c2);
    public override void OnEndPage(PdfWriter writer, Document document)
        {
            header.WriteSelectedRows(0, -1, document.Left, document.Top, writer.DirectContent);
        }
    }



    */


    public class Printing
    {
        private static int pageCount = 0;

       public static void PrintReceipt()
        {
            try
            {
              
                #region Common Part 
                PdfPTable pdfTableBlank = new PdfPTable(1);

                //Footer Section 
                PdfPTable pdfTableFooter = new PdfPTable(1);
                pdfTableFooter.DefaultCell.BorderWidth = 0;
                pdfTableFooter.WidthPercentage = 100;
                pdfTableFooter.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                Chunk cnkFooter = new Chunk("DEMO ENTERPRISE", FontFactory.GetFont("Times New Roman"));
                //cnkFooter.Font.SetStyle(1); 
                cnkFooter.Font.Size = 10;
                pdfTableFooter.AddCell(new Phrase(cnkFooter));
                //End Of Footer Section 

                pdfTableBlank.AddCell(new Phrase(" "));
                pdfTableBlank.DefaultCell.Border = 0;
                #endregion

                #region Page 
                #region Section-1

                PdfPTable pdfTable1 = new PdfPTable(1);//Here 1 is Used For Count of Column 
                PdfPTable pdfTable2 = new PdfPTable(1);
                PdfPTable pdfTable3 = new PdfPTable(2);

                //Font Style 
                System.Drawing.Font fontH1 = new System.Drawing.Font("Currier", 16);

                //pdfTable1.DefaultCell.Padding = 5; 
                pdfTable1.WidthPercentage = 80;
                pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                //pdfTable1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170); 
                pdfTable1.DefaultCell.BorderWidth = 0;


                //pdfTable1.DefaultCell.Padding = 5; 
                pdfTable2.WidthPercentage = 80;
                pdfTable2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable2.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                //pdfTab2e1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170); 
                pdfTable2.DefaultCell.BorderWidth = 0;

                pdfTable3.DefaultCell.Padding = 5;
                pdfTable3.WidthPercentage = 80;
                pdfTable3.DefaultCell.BorderWidth = 0.5f;


                Chunk c1 = new Chunk("DEMO ENTERPRISE", FontFactory.GetFont("Times New Roman"));
                c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c1.Font.SetStyle(0);
                c1.Font.Size = 14;
                Phrase p1 = new Phrase();
                p1.Add(c1);
                pdfTable1.AddCell(p1);
                Chunk c2 = new Chunk("28/3, XXX Narayan XXXXXX, Kolkata - 7XXXXXX", FontFactory.GetFont("Times New Roman"));
                c2.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c2.Font.SetStyle(0);//0 For Normal Font 
                c2.Font.Size = 11;
                Phrase p2 = new Phrase();
                p2.Add(c2);
                pdfTable2.AddCell(p2);
                Chunk c3 = new Chunk("Customer Care : 033-XXXX-XXXX, 98300 56947 / XXXXX XXXXX", FontFactory.GetFont("Times New Roman"));
                c3.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c3.Font.SetStyle(0);
                c3.Font.Size = 11;
                Phrase p3 = new Phrase();
                p3.Add(c3);
                pdfTable2.AddCell(p3);

                #endregion
                #region Section-1 
                PdfPTable pdfTable4 = new PdfPTable(4);
                pdfTable4.DefaultCell.Padding = 5;
                pdfTable4.WidthPercentage = 80;
                pdfTable4.DefaultCell.BorderWidth = 0.0f;

                pdfTable4.AddCell(new Phrase("Bill No "));
                pdfTable4.AddCell(new Phrase("B001"));
                pdfTable4.AddCell(new Phrase("Date "));
                pdfTable4.AddCell(new Phrase("01-01-2017"));
                pdfTable4.AddCell(new Phrase("Vendor "));
                pdfTable4.AddCell(new Phrase("Demo Vendor"));
                pdfTable4.AddCell(new Phrase("Address "));
                pdfTable4.AddCell(new Phrase("Kolkata"));
                #endregion
                #region Section-Image 

                string imageURL = "C:\\Users\\Thierry\\Desktop\\info.jpg";
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

                //Resize image depend upon your need 
                jpg.ScaleToFit(140f, 120f);
                //Give space before image 
                jpg.SpacingBefore = 10f;
                //Give some space after the image 
                jpg.SpacingAfter = 1f;

                jpg.Alignment = Element.ALIGN_CENTER;
                #endregion

                #region section Table 
                pdfTable3.AddCell(new Phrase("COMPANY NAME "));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase("JOB TITLE "));
                pdfTable3.AddCell(new Phrase(""));

                pdfTable3.AddCell(new Phrase("ADDRESS"));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase("CONTACT NO "));
                pdfTable3.AddCell(new Phrase(""));
                #endregion

                #endregion


                #region Pdf Generation 
                string folderPath = "D:\\PDF\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                //File Name 
                int fileCount = Directory.GetFiles("D:\\PDF").Length;
                string strFileName = "DescriptionForm" + (fileCount + 1) + ".pdf";

                using (FileStream stream = new FileStream(folderPath + strFileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfWriter.PageEvent = new MyPageHeader();
                    pdfDoc.Open();
                    #region PAGE-1 
                    pdfDoc.Add(pdfTable1);
                    pdfDoc.Add(pdfTable2);
                    pdfDoc.Add(pdfTableBlank);
                    pdfDoc.Add(jpg);
                    pdfDoc.Add(pdfTable3);
                    pdfDoc.Add(pdfTableFooter);
                    pdfDoc.NewPage();
                    #endregion

                    // pdfDoc.Add(jpg); 

                    //pdfDoc.Add(pdfTable2); 
                    pdfDoc.Close();
                    stream.Close();
                }
                #endregion

                #region Display PDF 
                System.Diagnostics.Process.Start(folderPath + "\\" + strFileName);
                #endregion

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void PrintReceipt(MSections Sections)
        {
            


            try
            {
                #region Common Part 
                PdfPTable pdfTableBlank = new PdfPTable(1);

                //Footer Section 
                PdfPTable pdfTableFooter = new PdfPTable(1);
                pdfTableFooter.DefaultCell.BorderWidth = 0;
                pdfTableFooter.WidthPercentage = 100;
                pdfTableFooter.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                Chunk cnkFooter = new Chunk("DEMO ENTERPRISE", FontFactory.GetFont("Times New Roman"));
                //cnkFooter.Font.SetStyle(1); 
                cnkFooter.Font.Size = 10;
                pdfTableFooter.AddCell(new Phrase(cnkFooter));
                //End Of Footer Section 

                pdfTableBlank.AddCell(new Phrase(" "));
                pdfTableBlank.DefaultCell.Border = 0;
                #endregion

                #region Page 
                #region Section-1

                PdfPTable pdfTable1 = new PdfPTable(1);//Here 1 is Used For Count of Column 
                PdfPTable pdfTable2 = new PdfPTable(1);
                PdfPTable pdfTable3 = new PdfPTable(10);

                //Font Style 
                System.Drawing.Font fontH1 = new System.Drawing.Font("Currier", 16);

                pdfTable1.DefaultCell.Padding = 15; 
                pdfTable1.WidthPercentage = 80;
                pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                //pdfTable1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170); 
                pdfTable1.DefaultCell.BorderWidth = 0;
               

                pdfTable2.DefaultCell.Padding = 15; 
                pdfTable2.WidthPercentage = 80;
                pdfTable2.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfTable2.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfTable2.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170); 
                pdfTable2.DefaultCell.BorderWidth = 0;

                pdfTable3.DefaultCell.Padding = 5;
                pdfTable3.WidthPercentage = 100;
                pdfTable3.DefaultCell.BorderWidth = 0.5f;


                Chunk c1 = new Chunk("Sql or Nosql", FontFactory.GetFont("Times New Roman") );
                c1.Font.Color = new iTextSharp.text.BaseColor(64, 134, 170);
                c1.Font.SetStyle(0);
                c1.Font.Size = 28;
              
                Phrase p1 = new Phrase();
                p1.Add(c1);
                pdfTable1.AddCell(p1);
                Chunk c2 = new Chunk("Thierry,Johanna,Moussa,Bourama,Hamid", FontFactory.GetFont("Times New Roman"));
                c2.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c2.Font.SetStyle(0);//0 For Normal Font 
                c2.Font.Size = 11;
                Phrase p2 = new Phrase();
                p2.Add(c2);
                pdfTable2.AddCell(p2);
                Chunk c3 = new Chunk("Customer Care : 033-XXXX-XXXX, 98300 56947 / XXXXX XXXXX", FontFactory.GetFont("Times New Roman"));
                c3.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c3.Font.SetStyle(0);
                c3.Font.Size = 11;
                Phrase p3 = new Phrase();
                p3.Add(c3);
                pdfTable2.AddCell(p3);

                #endregion
                #region Section-1 
                PdfPTable pdfTable4 = new PdfPTable(4);
                pdfTable4.DefaultCell.Padding = 5;
                pdfTable4.WidthPercentage = 80;
                pdfTable4.DefaultCell.BorderWidth = 0.0f;

                pdfTable4.AddCell(new Phrase("Bill No "));
                pdfTable4.AddCell(new Phrase("B001"));
                pdfTable4.AddCell(new Phrase("Date "));
                pdfTable4.AddCell(new Phrase("01-01-2017"));
                pdfTable4.AddCell(new Phrase("Vendor "));
                pdfTable4.AddCell(new Phrase("Demo Vendor"));
                pdfTable4.AddCell(new Phrase("Address "));
                pdfTable4.AddCell(new Phrase("Kolkata"));
                #endregion
                #region Section-Image 

                string imageURL = "C:\\Users\\Thierry\\Desktop\\info.jpg";
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

                //Resize image depend upon your need 
                jpg.ScaleToFit(140f, 120f);
                //Give space before image 
                jpg.SpacingBefore = 10f;
                //Give some space after the image 
                jpg.SpacingAfter = 1f;

                jpg.Alignment = Element.ALIGN_CENTER;
                #endregion

                #region section Table 
                for (int  i= 0; i < 50; i++){ 
                pdfTable3.AddCell(new Phrase("COMPANY NAME "));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase("JOB TITLE "));
                pdfTable3.AddCell(new Phrase(""));

                pdfTable3.AddCell(new Phrase("ADDRESS"));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase("CONTACT NO "));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase(""));
                pdfTable3.AddCell(new Phrase(""));
                }
                #endregion

                #endregion


                #region Pdf Generation 
                string folderPath = "D:\\PDF\\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                //File Name 
                int fileCount = Directory.GetFiles("D:\\PDF").Length;
                string strFileName = "DescriptionForm" + (fileCount + 1) + ".pdf";

                using (FileStream stream = new FileStream(folderPath + strFileName, FileMode.Create))
                {


                   int  i = 2;


                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 50f, 50f);

                    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfWriter.PageEvent = new MyPageHeader();
                    pdfDoc.Open();
                    #region PAGE-1 
                    pdfDoc.Add(pdfTable1);
                    pdfDoc.Add(pdfTable2);
                    pdfDoc.Add(pdfTableBlank);
                    pdfDoc.Add(jpg);
                    pdfDoc.Add(pdfTable3);
                    pdfDoc.Add(pdfTableFooter);
                    pdfDoc.NewPage();
                    #endregion
                    #region PAGE-+(string)i ;
                    pdfDoc.Add(pdfTable4);
                    pdfDoc.NewPage();
                    #endregion
                    // pdfDoc.Add(jpg); 

                    //pdfDoc.Add(pdfTable2); 
                    pdfDoc.Close();
                    stream.Close();
                }
                #endregion

                #region Display PDF 
                System.Diagnostics.Process.Start(folderPath + "\\" + strFileName);
                #endregion

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
    
