﻿using System.Drawing.Imaging;
using System.IO;

namespace MPO.Code.Common
{
    /// <summary>
    /// Bacode128
    /// </summary>
    public class Stk_Barcode_R2
    {
        public MemoryStream GenBarCode128(string data)
        {
            var memStream = new System.IO.MemoryStream();
            //Read in the parameters
            string strData = data;

            //  string strData = "AaaRGaaaaaaaaaa11103020215/02";
            const int imageHeight = 150;
            const int imageWidth = 400;
            string Forecolor = "";
            string Backcolor = "";
            bool bIncludeLabel = true;
            const string strImageFormat = "png";
            string strAlignment = "";//Request.QueryString["align"].ToLower().Trim();
            string BarType = "Code 128";

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            switch (BarType)
            {
                case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
                case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
                case "UPC 2 Digit Ext": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                case "UPC 5 Digit Ext": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
                case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
                case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
                case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
                case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
                case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
                case "Bookland-ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
                case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
                case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
                case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
                case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
                case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
                case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
                case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
                case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
                case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
                case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
                case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
                case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
                case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
                case "FIM (Facing Identification Mark)": type = BarcodeLib.TYPE.FIM; break;
                case "Pharmacode": type = BarcodeLib.TYPE.PHARMACODE; break;
                default: break;
            }//switch

            System.Drawing.Image barcodeImage = null;

            try
            {
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();

                if (type != BarcodeLib.TYPE.UNSPECIFIED)
                {
                    b.IncludeLabel = bIncludeLabel;

                    b.Alignment = BarcodeLib.AlignmentPositions.CENTER;

                    if (Forecolor.Trim() == "" && Forecolor.Trim().Length != 6)
                        Forecolor = "000000";
                    if (Backcolor.Trim() == "" && Backcolor.Trim().Length != 6)
                        Backcolor = "FFFFFF";

                    //===== Encoding performed here =====
                    barcodeImage = b.Encode(type, strData.Trim(), System.Drawing.ColorTranslator.FromHtml("#" + Forecolor), System.Drawing.ColorTranslator.FromHtml("#" + Backcolor), imageWidth, imageHeight);

                    //===== Static Enoding performed here =====
                    //barcodeImage = BarcodeLib.Barcode.DoEncode(type, this.txtData.Text.Trim(), this.chkGenerateLabel.Checked, this.btnForeColor.BackColor, this.btnBackColor.BackColor);
                    //==========================================

                    // Response.ContentType = "image/" + strImageFormat;
                    //System.IO.MemoryStream MemStream = new System.IO.MemoryStream();

                    switch (strImageFormat)
                    {
                        case "gif": barcodeImage.Save(memStream, ImageFormat.Gif); break;
                        case "jpeg": barcodeImage.Save(memStream, ImageFormat.Jpeg); break;
                        case "png": barcodeImage.Save(memStream, ImageFormat.Png); break;
                        case "bmp": barcodeImage.Save(memStream, ImageFormat.Bmp); break;
                        case "tiff": barcodeImage.Save(memStream, ImageFormat.Tiff); break;
                        default: break;
                    }//switch

                    barcodeImage.Save(memStream, ImageFormat.Png);
                    // MemStream.WriteTo(Response.OutputStream);

                    // return MemStream;
                }//if
                return memStream;
            }//try
            catch (System.Exception ex)
            {
                // Response.Write(e.ToString());
                throw ex;
                //TODO: find a way to return this to display the encoding error message
            }//catch
            finally
            {
                if (barcodeImage != null)
                {
                    //Clean up / Dispose...
                    barcodeImage.Dispose();
                }
            }//finally
        }//if
    }
}