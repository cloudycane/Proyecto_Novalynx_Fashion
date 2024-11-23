using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovalynxFashion.Core.Enums
{
    public enum SubtipoRopaEnum
    {
        Camisetas = 0,
        [Display(Name = "Pantalones Jeans")]
        PantalonesDeMezclillaJeans = 1,
        Sudaderas = 2,
        [Display(Name = "Pantalones Deportivos")]
        PantalonesDeportivos = 3,
        Leggings = 4,
        Bermudas = 5,
        [Display(Name = "Camisas De Cuadros")]
        CamisasDeCuadros = 6,
        [Display(Name = "Vestidos Casuales")]
        VestidosCasuales = 7,
        Shorts = 8,
        Abrigos = 9,
        Chaquetas = 10,
        Bufandas = 11,
        Sueteres = 12,
        Gorros = 13,
        Guantes = 14,
        Botas = 15,
        Blazers = 16,
        [Display(Name = "Mini - Faldas")]
        MiniFaldas = 17,
        [Display(Name = "Camisas Clásicas Para Hombres")]
        CamisasClasicasParaHombres = 18,
        [Display(Name = "Camisas Clásicas Para Mujeres")]
        CamisasClasicasParaMujeres = 19,
        [Display(Name = "Zapatos De Tacón")]
        MocasinesZapatosDeTacon = 20,
        [Display(Name = "Pantalones Tipo Chino")]
        PantalonesTipoChinos = 21,
        [Display(Name = "Leggings Deportivo")]
        LeggingsDeportivo = 22,
        [Display(Name = "Camisetas De Secado Rápido")]
        CamisetasDeSecadoRapido = 23,
        [Display(Name = "Sudaderas Con Capucha")]
        SudaderasConCapucha = 24,
        [Display(Name = "Ropa Térmica")]
        RopaTermica = 25,
        [Display(Name = "Pantalones Cortos Deportivos")]
        PantalonesCortosDeportivos = 26,
        [Display(Name = "Camisetas Sin Mangas")]
        CamisetasSinMangas = 27,
        Vestidos = 28,
        Sandalias = 29,
        [Display(Name = "Bañadores y Bikinis")]
        BañadoresYBikinis = 30,
        Sombreros = 31,
        [Display(Name = "Camisas de Manga Corta")]
        CamisasMangaCorta = 32,
        Trajes = 33,
        [Display(Name = "Camisas de Vestir")]
        Camisasdevestir = 34,
        Blusas = 35,
        Faldas = 36,
        [Display(Name = "Vestidos de Noche")]
        VestidosDeNoche = 37,
        [Display(Name = "Corbatas y Moños")]
        CorbatasyMoños = 38,
        [Display(Name = "Abrigos Largos")]
        AbrigosLargos = 39,
        [Display(Name = "Calzoncillos y Boxers")]
        CalzoncillosyBoxers = 40,
        [Display(Name = "Brasieres y Tops")]
        BrasieresyTops = 41,
        Pijamas = 42,
        [Display(Name = "Camisetas Interiores")]
        CamisetasInteriores = 43,
        Pantuflas = 44,
        Gorras = 45,
        Cinturones = 46,
        Bolso = 47,
        Relojes = 48,
        Lentes = 49,
        Gafas = 50,
        [Display(Name = "Salud y Belleza")]
        SaludyBelleza = 51,
        [Display(Name = "Hogar y Cocina")]
        HogaryCocina = 52, 
        Pendientes = 53, 
        Anillos = 54, 
        Otros = 55,


    }
}
