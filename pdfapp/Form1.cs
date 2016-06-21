using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdfapp
{
    public partial class MainWindow : Form
    {
        OpenFileDialog openPDF_Dialog;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bSelectPDF_Click(Object sender, EventArgs e)
        {

            openPDF_Dialog = new OpenFileDialog();
            
            openPDF_Dialog.Filter = "pdf files (*.pdf)|*.pdf";
            openPDF_Dialog.RestoreDirectory = false;

            if (openPDF_Dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lPathPDF.Text = openPDF_Dialog.FileName.ToString();
                    tb_pages.Enabled = true;
                    bCreatePDF.Enabled = true;
                    pdfViewer.src = openPDF_Dialog.FileName;
                    pdfViewer.setShowScrollbars(false);
                    pdfViewer.setShowToolbar(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        private void bCreatePDF_Click(Object sender, EventArgs e)
        {

            Match match = Regex.Match(tb_pages.Text, @"^(\d+|\d+-\d+)(,(\d+|\d+-\d+))*$");

            if (match.Success)
            {
                
                // Grab pages from text box
                List<int> pages = getNums(tb_pages.Text);

                PdfReader pdfReader = new PdfReader(openPDF_Dialog.FileName);
                int numberOfPages = pdfReader.NumberOfPages;
                bool page_validates = true;

                foreach (int p in pages)
                {
                    if (p > numberOfPages)
                    {
                        page_validates = false;
                    }
                }

                if (pages.Any() && page_validates)
                {

                    SaveFileDialog savePDF_Dialog = new SaveFileDialog();
                    savePDF_Dialog.Filter = "pdf files (*.pdf)|*.pdf";
                    savePDF_Dialog.FilterIndex = 2;
                    savePDF_Dialog.RestoreDirectory = false;

                    string save_path = "";

                    if (savePDF_Dialog.ShowDialog() == DialogResult.OK)
                    {
                        save_path = savePDF_Dialog.FileName;
                    }

                    pages.Sort();

                    PdfReader reader = null;
                    Document document = null;
                    PdfCopy pdfCopyProvider = null;
                    PdfImportedPage importedPage = null;

                    try
                    {
                        reader = new PdfReader(openPDF_Dialog.FileName);
                        
                        string extracted_pdf_name = "";
                        if (String.IsNullOrEmpty(save_path))
                        {
                            // User willfully canceled saving... do nothing
                        }
                        else
                        {
                            extracted_pdf_name = save_path;
                            
                            Console.Out.WriteLine(extracted_pdf_name);
                            document = new Document(reader.GetPageSizeWithRotation(pages[0]));
                            pdfCopyProvider = new PdfCopy(document, new FileStream(extracted_pdf_name, FileMode.Create));
                            document.Open();

                            foreach (int p in pages)
                            {
                                importedPage = pdfCopyProvider.GetImportedPage(reader, p);
                                pdfCopyProvider.AddPage(importedPage);
                            }

                            document.Close();
                            reader.Close();

                            tb_pages.Clear();

                            tb_pages.Enabled = false;
                            bCreatePDF.Enabled = false;
                            lPathPDF.Text = "No PDF File Selected...";

                            MessageBox.Show($"PDF Created at: {extracted_pdf_name}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: Invalid format in Pages entry.\n\nOnly numbers, dashes, and commas are accepted.\nCheck your date ranges to make sure they're correct.\nMake sure pages entered fall within source PDF page range.");
                }
            }
            else
            {
                MessageBox.Show("ERROR: Invalid format in Pages entry.\n\nOnly numbers, dashes, and commas are accepted.\nCheck your date ranges to make sure they're correct.\nMake sure pages entered fall within source PDF page range.");
            }
            
        }

        static int sep(string s, string st)
        {

            char[] delChars = { '-' };
            List<string> test = new List<string>(s.Split(delChars));

            if (st == "before")
            {
                return Int32.Parse(test[0]);
            }
            else
            {
                return Int32.Parse(test[1]);
            }

        }

        static List<int> getNums(string input_text)
        {

            char[] delChars = { ',' };

            List<string> str_pages = new List<string>(input_text.Split(delChars));
            List<int> pages = new List<int>();
            
            foreach (string s in str_pages)
            {
                Match match = Regex.Match(s, @"^[0-9]+$");

                if (match.Success)
                {
                    pages.Add(Int32.Parse(s));
                }
                
            }

            foreach (string t in str_pages)
            {
                Match match = Regex.Match(t, @"^\d+-+\d+$");

                if (match.Success)
                {
                    int num1 = sep(t, "before");
                    int num2 = sep(t, "after");

                    if (num1 >= num2)
                    {
                        // FAIL PROCESS, ALERT USER
                        pages.Clear();
                        return pages;
                    }
                    else
                    {
                        foreach (int num in Enumerable.Range(num1, num2 - num1 + 1))
                        {
                            pages.Add(num);
                        }
                    }
                }
            }

            return pages;

        }

        private void menu_help_click(Object sender, EventArgs e)
        {
            MessageBox.Show("1) Click Select PDF Button to browse to the PDF you wish to extract pages from" + "\n" +
                            "2) In Pages text box, enter the page numbers, separated by commas, that you wish to extract (including ranges). For Example: 1,4,5-10"+ "\n" +
                            "3) Click Create PDF and choose a save location and file name for your new PDF");
        }

        private void menu_close_click(Object sender, EventArgs e)
        {
            bSelectPDF.Focus();
            Application.Exit();
        }

        private void bNextPage_Click(object sender, EventArgs e)
        {
            pdfViewer.gotoNextPage();
        }

        
        private void closing(object sender, FormClosedEventArgs e)
        {
            bSelectPDF.Focus();
            Console.Out.WriteLine("Form Closing!");
        }

    }
}
