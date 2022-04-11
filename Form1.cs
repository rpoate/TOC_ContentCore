namespace TOC_ContentCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.htmlEditControl1.CSSText = "body {font-family: Arial} div {border: 1px green solid; margin: 5px}";
            this.htmlEditControl1.DocumentHTML = "<div><h1 id=\"ch1\">Chapter 1</h1><p>	Some Text</p></div><div><h1 id=\"ch2\">Chapter 2</h1><p>	Some More Text</p></div><div><h1 id=\"ch3\">Chapter 3</h1><p>	Some more text again</p></div>";
            this.listBox1.Items.AddRange(new String[] { "One", "Two", "Three" });

            var CopyBotton = this.htmlEditControl1.ToolStripItems.Add("Copy Parent DIV");
            CopyBotton.Padding = new Padding(3);
            CopyBotton.Click += CopyBotton_Click;
        }

        private void CopyBotton_Click(object? sender, EventArgs e)
        {
            // Find Parent DIV and Copy
            var oDIV = FindParentDIV(htmlEditControl1.CurrentWindowsFormsElement);

            if (oDIV != null)
            {
                Clipboard.SetData("HTML Format", oDIV.InnerHtml);
                MessageBox.Show(oDIV.InnerHtml);
            }
        }

        private HtmlElement? FindParentDIV(HtmlElement Element)
        {

            if (Element.TagName == "BODY") return null;

            if (Element.TagName == "DIV")
            {
                return Element;
            }
            else
            {
                return FindParentDIV(Element.Parent);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HtmlElement oChapterHeading = this.htmlEditControl1.GetItemsByAttributeValue("id", "ch" + (this.listBox1.SelectedIndex + 1))[0];

            this.htmlEditControl1.MoveCursorToElement(oChapterHeading, Zoople.HTMLEditControl._ELEM_ADJACENCY.ELEM_ADJ_BeforeBegin);
            this.htmlEditControl1.SetFocus();
        }
    }
}