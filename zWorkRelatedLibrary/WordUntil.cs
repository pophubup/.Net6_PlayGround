namespace zWorkRelatedLibrary
{
    public class WordUntil
    {
        public void ValueReplaceBySeed(string path)
        {


            var to = $"{ Directory.GetParent(path).Parent}\\Copy1.docx";
            
            File.Copy(path,to);
            using (WordprocessingDocument wd = WordprocessingDocument.Open(to, true))
            {
                Dictionary<string, string> dataObject = new Dictionary<string, string>();
                dataObject.Add("Name1", "tttt");
                dataObject.Add("Name2", "aaaa");
                dataObject.Add("Name3", "cccc");
                dataObject.Add("title", "ffffffff");

                parse(wd.MainDocumentPart, dataObject);

            }
            static void parse(OpenXmlPart oxp, Dictionary<string, string> dct)
            {
                string xmlString = null;
                using (StreamReader sr = new StreamReader(oxp.GetStream()))
                { xmlString = sr.ReadToEnd(); }
                foreach (string key in dct.Keys)
                { xmlString = xmlString.Replace("[$" + key + "$]", dct[key]); }
                using (StreamWriter sw = new StreamWriter(oxp.GetStream(FileMode.Create)))
                { sw.Write(xmlString); }
            }
        }
        public void RTFFormatToReplaceValue(string path)
        {
            var to = Directory.GetParent(path);
            var fillContent = new Content();
            List<IContentItem> fields = new List<IContentItem>();
            fields.Add(new FieldContent("@title", $"我正在測試"));
            fields.ForEach(f => fillContent.Fields.Add(f as FieldContent));
            //複製 Template 檔案
            System.IO.File.Copy(path, $"{to.Parent}\\Copy2.docx");

            //將Content丟給TemplateProcessor處理，SetRemoveContentControls=true表示要清除標籤內文字，如不要清除則設為false
            using (var outputDocument = new TemplateProcessor($"{to.Parent}\\Copy2.docx").SetRemoveContentControls(true))
            {
                outputDocument.FillContent(fillContent);
                outputDocument.SaveChanges(); //儲存變更檔案
            }
        }
     
    }
}