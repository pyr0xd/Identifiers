namespace Identifiers.Services
{
    using ContactApp.Storage; // Antag att detta är rätt namespace för din storage
    using System.Collections.Generic;
    using System.Linq;

    public class InfoNamesService
    {
        private readonly InfoNamesStorage _storage;

        public InfoNamesService(InfoNamesStorage storage)
        {
            _storage = storage;
        }

        public void LäggTillKontakt(InfoNames kontakt)
        {
            var infoNamesList = _storage.LäsInfoNames();
            infoNamesList.Add(kontakt);
            _storage.SparaInfoNames(infoNamesList);
        }

        public void TaBortKontakt(string epostadress)
        {
            var infoNamesList = _storage.LäsInfoNames();
            infoNamesList.RemoveAll(k => k.Epostadress == epostadress);
            _storage.SparaInfoNames(infoNamesList);
        }

        public InfoNames HämtaKontakt(string epostadress)
        {
            return _storage.LäsInfoNames().FirstOrDefault(k => k.Epostadress == epostadress);
        }

        public InfoNamesStorage Get_storage()
        {
            return _storage;
        }

        public List<InfoNames> HämtaAllaInfoNames(InfoNamesStorage _storage)
        {
            return _storage.LäsInfoNames();
        }
    }
}