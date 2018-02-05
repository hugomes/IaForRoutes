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
            PortoUniao = new City("Porto União");
            PauloFrontin = new City("Paulo Frontin");
            Canoinhas = new City("Canoinhas");
            Irati = new City("Irati");
            Palmeira = new City("Palmeira");
            CampoLargo = new City("Campo Largo");
            Curitiba = new City("Curitiba");
            BalsaNova = new City("Balsa Nova");
            PortoUniao = new City("Porto União");
            Araucaria = new City("Araucária");
            SaoJose = new City("São José");
            Contenda = new City("Contenda");
            Mafra = new City("Mafra");
            Tijucas = new City("Tijucas");
            Lapa = new City("Lapa");
            SaoMateus = new City("São Mateus");
            TresBarras = new City("Três Barras");

            PortoUniao.AddRelatedCities(new RelatedCity(PauloFrontin));
            PortoUniao.AddRelatedCities(new RelatedCity(Canoinhas));
            PortoUniao.AddRelatedCities(new RelatedCity(SaoMateus));
            PauloFrontin.AddRelatedCities(new RelatedCity(Irati));
            PauloFrontin.AddRelatedCities(new RelatedCity(PortoUniao));
            Canoinhas.AddRelatedCities(new RelatedCity(TresBarras));
            Canoinhas.AddRelatedCities(new RelatedCity(Mafra));
            Canoinhas.AddRelatedCities(new RelatedCity(PortoUniao));
            SaoMateus.AddRelatedCities(new RelatedCity(Irati));
            SaoMateus.AddRelatedCities(new RelatedCity(Palmeira));
            SaoMateus.AddRelatedCities(new RelatedCity(Lapa));
            SaoMateus.AddRelatedCities(new RelatedCity(TresBarras));
            SaoMateus.AddRelatedCities(new RelatedCity(PortoUniao));
            Irati.AddRelatedCities(new RelatedCity(SaoMateus));
            Irati.AddRelatedCities(new RelatedCity(Palmeira));
            Irati.AddRelatedCities(new RelatedCity(PauloFrontin));
            TresBarras.AddRelatedCities(new RelatedCity(Canoinhas));
            TresBarras.AddRelatedCities(new RelatedCity(SaoMateus));
            TresBarras.AddRelatedCities(new RelatedCity(Canoinhas));
            Mafra.AddRelatedCities(new RelatedCity(Canoinhas));
            Mafra.AddRelatedCities(new RelatedCity(Lapa));
            Mafra.AddRelatedCities(new RelatedCity(Tijucas));
            Lapa.AddRelatedCities(new RelatedCity(SaoMateus));
            Lapa.AddRelatedCities(new RelatedCity(Contenda));
            Lapa.AddRelatedCities(new RelatedCity(Mafra));
            Contenda.AddRelatedCities(new RelatedCity(Lapa));
            Contenda.AddRelatedCities(new RelatedCity(Araucaria));
            Contenda.AddRelatedCities(new RelatedCity(BalsaNova));
            Palmeira.AddRelatedCities(new RelatedCity(Irati));
            Palmeira.AddRelatedCities(new RelatedCity(SaoMateus));
            Palmeira.AddRelatedCities(new RelatedCity(CampoLargo));
            BalsaNova.AddRelatedCities(new RelatedCity(Contenda));
            BalsaNova.AddRelatedCities(new RelatedCity(Curitiba));
            BalsaNova.AddRelatedCities(new RelatedCity(CampoLargo));
            Araucaria.AddRelatedCities(new RelatedCity(Contenda));
            Araucaria.AddRelatedCities(new RelatedCity(Curitiba));
            CampoLargo.AddRelatedCities(new RelatedCity(Palmeira));
            CampoLargo.AddRelatedCities(new RelatedCity(BalsaNova));
            CampoLargo.AddRelatedCities(new RelatedCity(Curitiba));
            Tijucas.AddRelatedCities(new RelatedCity(Mafra));
            Tijucas.AddRelatedCities(new RelatedCity(SaoJose));
            SaoJose.AddRelatedCities(new RelatedCity(Tijucas));
            SaoJose.AddRelatedCities(new RelatedCity(Curitiba));
        }
    }
}