using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasStagiaire
{
    public class MyPageHeader : PdfPageEventHelper
    {

        public PdfPTable header = new PdfPTable(2);
       

        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            if (doc.PageNumber == 1)
            {

            }
            else 
            {
                header.HorizontalAlignment = Element.ALIGN_LEFT;
                header.TotalWidth = doc.PageSize.Width - 20f;
                header.LockedWidth = true;
                Phrase cell1 = new Phrase("ceci est un test");
                Phrase cell2 = new Phrase("text");

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
                header.WriteSelectedRows(0, 1, doc.Left, doc.Top+40, writer.DirectContent);
            }
        }
    }
}
