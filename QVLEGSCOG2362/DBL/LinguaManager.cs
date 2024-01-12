using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Resources;

namespace QVLEGSCOG2362.DBL
{
    public class LinguaManager
    {

        private ResourceManager rm = null;
        private CultureInfo culture = null;
        private string datiVisionePath = null;

        private string configCodiceLingua = null;

        public LinguaManager(string path)
        {
            this.datiVisionePath = path;

            rm = ResourceManager.CreateFileBasedResourceManager("res", path, null);
        }

        public void ChangeLanguage(string codiceLingua)
        {
            this.configCodiceLingua = codiceLingua;
            culture = CultureInfo.CreateSpecificCulture(this.configCodiceLingua);
        }

        public string GetTranslation(string value)
        {
            string retvalue = "";
            try
            {
                retvalue = rm.GetString(value, culture);
                if (retvalue == null)
                {
                    retvalue = string.Format("*** MISSING TRANSLATION ({0}) ***", value);
                    Debug.WriteLine(retvalue);
                }
            }
            catch (Exception)
            {
                retvalue = string.Format("*** MISSING TRANSLATION ({0}) ***", value);
                Debug.WriteLine(retvalue);
            }
            return retvalue;
        }

        public string GetBandierinaImg()
        {
            return Path.Combine(datiVisionePath, "Lingue", string.Format("bandiera_{0}.png", this.configCodiceLingua));
        }

        public string GetTastoImg(string[] linguaList, int indice, out string strNewLingua)
        {
            string retValue = "";
            string nuovaLingua = "it";
            if (linguaList != null)
            {
                if (linguaList.Length >= (indice + 1))
                {
                    nuovaLingua = (string)linguaList[indice];
                    retValue = Path.Combine(datiVisionePath, "Lingue", string.Format("bandiera_{0}.png", nuovaLingua));
                }
            }
            strNewLingua = nuovaLingua;
            return retValue;
        }

    }
}
