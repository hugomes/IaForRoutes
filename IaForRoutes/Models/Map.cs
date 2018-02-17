using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IaForRoutes.Models
{
    public class Map
    {
        public City PortoUniao { get; set; }
        public City PauloFrontin { get; set; }
        public City Canoinhas { get; set; }
        public City Irati { get; set; }
        public City Palmeira { get; set; }
        public City CampoLargo { get; set; }
        public City Curitiba { get; set; }
        public City BalsaNova { get; set; }
        public City Araucaria { get; set; }
        public City SaoJose { get; set; }
        public City Contenda { get; set; }
        public City Mafra { get; set; }
        public City Tijucas { get; set; }
        public City Lapa { get; set; }
        public City SaoMateus { get; set; }
        public City TresBarras { get; set; }

        public Map()
        {
            PortoUniao = new City("Porto União", 203);
            PauloFrontin = new City("Paulo Frontin", 172);
            Canoinhas = new City("Canoinhas", 141);
            Irati = new City("Irati", 139);
            Palmeira = new City("Palmeira", 59);
            CampoLargo = new City("Campo Largo", 27);
            Curitiba = new City("Curitiba", 0);
            BalsaNova = new City("Balsa Nova", 41);
            Araucaria = new City("Araucária", 23);
            SaoJose = new City("São José", 13);
            Contenda = new City("Contenda", 39);
            Mafra = new City("Mafra", 94);
            Tijucas = new City("Tijucas", 56);
            Lapa = new City("Lapa", 74);
            SaoMateus = new City("São Mateus", 123);
            TresBarras = new City("Três Barras", 131);

            PortoUniao.AddRelatedCities(new RelatedCity(PauloFrontin, 46));
            PortoUniao.AddRelatedCities(new RelatedCity(Canoinhas, 78));
            PortoUniao.AddRelatedCities(new RelatedCity(SaoMateus, 87));
            PauloFrontin.AddRelatedCities(new RelatedCity(Irati, 75));
            PauloFrontin.AddRelatedCities(new RelatedCity(PortoUniao, 46));
            Canoinhas.AddRelatedCities(new RelatedCity(TresBarras, 12));
            Canoinhas.AddRelatedCities(new RelatedCity(Mafra, 66));
            Canoinhas.AddRelatedCities(new RelatedCity(PortoUniao, 78));
            SaoMateus.AddRelatedCities(new RelatedCity(Irati, 57));
            SaoMateus.AddRelatedCities(new RelatedCity(Palmeira, 77));
            SaoMateus.AddRelatedCities(new RelatedCity(Lapa, 60));
            SaoMateus.AddRelatedCities(new RelatedCity(TresBarras, 43));
            SaoMateus.AddRelatedCities(new RelatedCity(PortoUniao, 87));
            Irati.AddRelatedCities(new RelatedCity(SaoMateus, 57));
            Irati.AddRelatedCities(new RelatedCity(Palmeira, 75));
            Irati.AddRelatedCities(new RelatedCity(PauloFrontin, 75));
            TresBarras.AddRelatedCities(new RelatedCity(Canoinhas, 12));
            TresBarras.AddRelatedCities(new RelatedCity(SaoMateus, 43));
            TresBarras.AddRelatedCities(new RelatedCity(Canoinhas, 12));
            Mafra.AddRelatedCities(new RelatedCity(Canoinhas, 66));
            Mafra.AddRelatedCities(new RelatedCity(Lapa, 57));
            Mafra.AddRelatedCities(new RelatedCity(Tijucas,99));
            Lapa.AddRelatedCities(new RelatedCity(SaoMateus, 60));
            Lapa.AddRelatedCities(new RelatedCity(Contenda, 26));
            Lapa.AddRelatedCities(new RelatedCity(Mafra, 57));
            Contenda.AddRelatedCities(new RelatedCity(Lapa, 26));
            Contenda.AddRelatedCities(new RelatedCity(Araucaria, 18));
            Contenda.AddRelatedCities(new RelatedCity(BalsaNova, 19));
            Palmeira.AddRelatedCities(new RelatedCity(Irati, 75));
            Palmeira.AddRelatedCities(new RelatedCity(SaoMateus, 77));
            Palmeira.AddRelatedCities(new RelatedCity(CampoLargo, 55));
            BalsaNova.AddRelatedCities(new RelatedCity(Contenda, 19));
            BalsaNova.AddRelatedCities(new RelatedCity(Curitiba, 51));
            BalsaNova.AddRelatedCities(new RelatedCity(CampoLargo, 22));
            Araucaria.AddRelatedCities(new RelatedCity(Contenda, 18));
            Araucaria.AddRelatedCities(new RelatedCity(Curitiba, 37));
            CampoLargo.AddRelatedCities(new RelatedCity(Palmeira, 55));
            CampoLargo.AddRelatedCities(new RelatedCity(BalsaNova, 22));
            CampoLargo.AddRelatedCities(new RelatedCity(Curitiba, 29));
            Tijucas.AddRelatedCities(new RelatedCity(Mafra, 99));
            Tijucas.AddRelatedCities(new RelatedCity(SaoJose, 49));
            SaoJose.AddRelatedCities(new RelatedCity(Tijucas, 49));
            SaoJose.AddRelatedCities(new RelatedCity(Curitiba, 15));
        }
    }
}