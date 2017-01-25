/* O XML retorna o estado atual em uma estrutura 
 * organizada em SNAPSHOTs (GIT - Like). Todo arquivo que estiver na mesma estrutura do
 * arquivo infectado tambem esta comprometido. Crie uma funcao que retorne o total de
 * cada arquivo comprometidos apenas uma vez (não é para retornar o arquivo infectado original)
  */
  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Training
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<root>" +
                "   <snapshot>" +
                "      <folder>" +
                "         <file fileId=\"1\"/>" +
                "         <file fileId=\"3\"/>" +
                "         <file fileId=\"6\"/>" +
                "         <folder>" +
                "            <file fileId=\"3\"/>" +
                "            <file fileId=\"4\"/>" +
                "            <folder> " +
                "               <file fileId=\"3\"/>" +
                "               <file fileId=\"5\"/>" +
                "               <folder> " +
                "                   <file fileId=\"7\"/>" +
                "                   <file fileId=\"2\"/>" +
                "               </folder>" +
                "            </folder>" +
                "         </folder>" +
                "      </folder>" +
                "   </snapshot>" +
                "   <snapshot>" +
                "      <file fileId=\"1\"/>" +
                "      <file fileId=\"3\"/>" +
                "      <folder>" +
                "         <file fileId=\"2\"/>" +
                "         <file fileId=\"4\"/>" +
                "         <folder>" +
                "            <file fileId=\"3\"/>" +
                "            <file fileId=\"4\"/>" +
                "         </folder>" +
                "      </folder>" +
                "   </snapshot>" +
                "</root>";

            Console.WriteLine(CountCompromised(xml, "3"));
            Console.ReadKey();
        }

        public static int CountCompromised(string xml, string infected)
        {
            XElement xmlElement = XElement.Parse(xml);

            return xmlElement.Descendants("file").Where(e => e.Attribute("fileId").Value == infected).
               SelectMany(i => i.Parent.Elements("file").Where(x => x.Attribute("fileId").Value != infected))
               .Select(j => j.Attribute("fileId").Value).Distinct()
               .Count();
        }
    }
}
