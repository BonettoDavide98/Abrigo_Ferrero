using QVLEGSCOG2362.Class;
using QVLEGSCOG2362.DataType;
using QVLEGSCOG2362.DBL;

namespace QVLEGSCOG2362.Pagine
{
    public interface IUCPaginaOnLine
    {
        void ActivateDisplay();
        void Init(AppManager appManager, int idStazione, Impostazioni impostazioni, object repaintLock);
        void SetShowMode(UCPaginaOnLine.ShowMode showMode);
        void Translate(LinguaManager linguaManager);
    }
}