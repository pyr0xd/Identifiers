

   

   namespace ContactApp.Interfaces;

    public interface nterfaceInfoNames
    {
        void LäggTillInfoNames(InfoNames InfoNames);
        void TaBortInfoNames(string epostadress);
        InfoNames HämtaInfoNames(string epostadress);
        List<InfoNames> HämtaAllaInfoNameser();
    }

    public interface IInfoNamesStorage
    {
        void SparaInfoNameser(List<InfoNames> InfoNameser);
        List<InfoNames> LäsInfoNameser();
    }



